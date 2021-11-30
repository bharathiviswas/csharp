using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineRegistration
{
    class Vaccination
    {
        public VaccineType vaccineType { get; set; }
        public string dosage { get; set; }
        public DateTime date { get; set; }
        public Vaccination(VaccineType vaccineType1,DateTime date1)
        {
            vaccineType = vaccineType1;
            date = date1;
        }
    }
    public enum VaccineType
    {
        Covaccine,
        Covishield,
        Sputnik

    }
    class BeneficiaryDetails
    {
        private static int _id = 100;
        public int registrationNo { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public Gender gender { get; set; }
        public long mobileNo { get; set; }
        public string city { get; set; }
        public List<Vaccination> vaccineDetails { get; set; }
        public BeneficiaryDetails(string name1, int age1, int gender1, long mobileNo1, string city1)
        {
            name = name1;
            age = age1;
            gender = (Gender)gender1;
            mobileNo = mobileNo1;
            city = city1;
            registrationNo = _id++;
        }
        public enum Gender
        {
            Male=1,
            Female=2,
            Others=3
        }
        public static string GetGender(Gender gender)
        {
            switch(gender)
            {
                case Gender.Male:
                    return "Male";
                case Gender.Female:
                    return "Female";
                case Gender.Others:
                    return "Others";
                default:
                    return "Invalid Input";
            }
        }
    }
  
}
