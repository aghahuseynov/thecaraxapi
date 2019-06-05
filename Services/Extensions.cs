using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public static class  Extensions
    {
        #region Methods


        public static bool IsNullable(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }


        public static Dictionary<string, object> ToDictionary(this IDataRecord record)
        {
            var result = new Dictionary<string, object>();
            for (var i = 0; i < record.FieldCount; i++)
            {
                result.Add(record.GetName(i), record[i]);
            }
            return result;
        }

        public static T ElementAtOrDefault<T>(this IList<T> list, int index)
        {
            return list.Count < index + 1 || index < 0
                     ? default(T)
                     : list.ElementAt(index);
        }

        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary is ConcurrentDictionary<TKey, TValue> cd)
            {
                cd.AddOrUpdate(key, k => value, (k, v) => value);
                return;
            }

            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        public static byte[] Combine(this byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public static void For<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            using (var enumerator = enumerable.GetEnumerator())
            {
                var counter = 0;
                while (enumerator.MoveNext())
                {
                    action(enumerator.Current, counter++);
                }
            }
        }

        public static byte[] GetRandomSalt()
        {
            byte[] buffer;
            using (var rng = new RNGCryptoServiceProvider())
            {
                buffer = new byte[64];
                rng.GetBytes(buffer);
            }
            return buffer;
        }

        public static byte[] GetSHA512(this string value, byte[] salt)
        {
            var data = Encoding.UTF8.GetBytes(value).Combine(salt);
            using (SHA512 shaM = new SHA512Managed())
            {
                return shaM.ComputeHash(data);
            }
        }



        public static string ReadAndClear(this StringBuilder stringBuilder)
        {
            lock (stringBuilder)
            {
                var ret = stringBuilder.ToString();
                stringBuilder.Length = 0;
                stringBuilder.Capacity = 0;
                return ret;
            }
        }



        public static string FixTheMallCode(this string mallCode)
        {
            mallCode = new string(mallCode?.Where(c => !char.IsWhiteSpace(c)).ToArray());
            mallCode = mallCode.Substring(0, mallCode.Length > 10 ? 10 : mallCode.Length);
            return mallCode;
        }

        public static bool IsNumeric(this string text)
        {
            return long.TryParse(text, out _);
        }
        #endregion Methods
    }
}
