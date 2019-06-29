
namespace Models
{
    public class Enums
    {
        public enum Gender
        {
            Male = 0,
            FeMale = 1
        }
        public enum UserLevel
        {
            SystemOwner = 0,
            CompanyOwner = 1,
            DepartmentOwner = 2,
            Employee = 3,
            Customer = 4
        }

        public enum CaseType
        {
            Cabrio = 0,
            Coupe = 1,
            Hatchback = 2,
            Panelvan = 3,
            PickUp = 4,
            Roadster = 5,
            Sedan = 6,
            Stationvagon = 7,
            Suv = 8
        }


        public enum FuelType
        {
            Gasoline = 0,
            Diesel = 1,
            Hybrid = 2,
            Electric = 3
        }

        public enum GearType
        {
            Automatic = 0,
            Manual = 1
        }
        public enum Classes
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3
        }

        public enum ReservationTypes
        {
            Pre = 0,
            Full = 1,
            Deliver = 2
        }
    }
}
