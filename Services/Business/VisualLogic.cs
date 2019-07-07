using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services.Business
{
    public static class VisualLogic
    {
        public static async Task<int> Create(string departmentCode, Models.Visual visual)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                visual.CreatedDateTime = DateTime.Now;
                visual.DepartmentCode = departmentCode;

                db.Visuals.Add(visual);

                if (await db.SaveChangesAsync() > 0)
                {
                    return visual.Id;
                }

                return -1;
            }
        }

        public static async Task<Models.Visual> GetVisual(string departmentCode, int visualId)
        {
            using (var db = new DataAccess.CaraxEntitiy())
            {
                return await db.Visuals.FirstOrDefaultAsync(q => q.DepartmentCode == departmentCode && q.Id == visualId);
            }
        }

        public static byte[] Resizer(Image originalImage, Size newSize)
        {
            if (originalImage.Width < newSize.Width)
            {
                newSize = originalImage.Size;
            }

            MemoryStream result;
            using (var newImage = originalImage.GetThumbnailImage(newSize.Width, newSize.Height, null, IntPtr.Zero))
            {
                result = new MemoryStream();
                newImage.Save(result, originalImage.RawFormat);
            }
            return result.ToArray();
        }

        public static byte[] Resizer(byte[] dataBytes, Size newSize)
        {
            Image originalImage;
            using (var memoryStream = new MemoryStream(dataBytes))
            {
                originalImage = Image.FromStream(memoryStream);
            }
            return Resizer(originalImage, newSize);
        }

        public static byte[] GetDataBytes(byte[] data, int? width = null, int? height = null)
        {
            var dataBytes = data;
            if (dataBytes == null)
            {
                return null;
            }

            if (!width.HasValue && !height.HasValue)
            {
                return dataBytes;
            }

            if (width.HasValue && height.HasValue)
            {
                return Resizer(dataBytes, new Size(width.Value, height.Value));
            }

            using (var memoryStream = new MemoryStream(dataBytes))
            {
                var originalImage = Image.FromStream(memoryStream);
                var originalSize = new Size(originalImage.Width, originalImage.Height);

                var ratio = width.HasValue
                                      ? width.Value / (float)originalSize.Width
                                      : height.Value / (float)originalSize.Height;

                var resultSize = new Size((int)Math.Round(originalSize.Width * ratio, MidpointRounding.ToEven),
                                          (int)Math.Round(originalSize.Height * ratio, MidpointRounding.ToEven));

                return Resizer(originalImage, resultSize);
            }
        }

    }
}
