using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineRegistration
{
    class Program
    {
        private static List<BeneficiaryDetails> beneficiary = new List<BeneficiaryDetails>();
        static void Main(string[] args)
        {
            
            Program user = new Program();
            var user1 = new BeneficiaryDetails("Vishwa", 22,1, 7687987687, "Chennai");
            var user2 = new BeneficiaryDetails("Ashwin", 34, 1, 8976789780, "Chennai");
            beneficiary.Add(user1);
            beneficiary.Add(user2);
            string choice = "";
            do
            {
                Console.WriteLine("Enter your option");
                Console.WriteLine("1.Beneficiary registration");
                Console.WriteLine("2.Vaccination");
                Console.WriteLine("3.Exit");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        user.BeneficiaryRegistration();
                        break;
                    case 2:
                        user.VaccineDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;


                }
                Console.WriteLine("Do you want to continue?yes or no");
                choice = Console.ReadLine().ToLower();
            } while (choice == "yes");
            Console.ReadKey();
        }
        public void BeneficiaryRegistration()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter gender:");
            string gender1 = Console.ReadLine();
            int gender = int.Parse(gender1);
            Console.WriteLine("Enter mobile number:");
            long mobile = long.Parse(Console.ReadLine());
            Console.WriteLine("enter city:");
            string city = Console.ReadLine();
            var user3 = new BeneficiaryDetails(name, age, gender, mobile, city);
            beneficiary.Add(user3);
            Console.WriteLine("Your registration number :" + user3.registrationNo);

        }
        public void VaccineDetails()
        {
            string choice = "";
            int type1 = 0;
            Console.WriteLine("Enter registration number:");
            int registerNo = int.Parse(Console.ReadLine());
            foreach(BeneficiaryDetails i in beneficiary)
            {
                if(i.registrationNo  == registerNo)
                {
                    do
                    {
                        Console.WriteLine("1.Vaccination,2.Vaccination history,3.Next due date");
                             type1 = int.Parse(Console.ReadLine());
                        switch (type1)
                        {
                            case 1:

                                Console.WriteLine("Enter Vaccination type");
                                Console.WriteLine("1.Covaccine,2.CovidShield,3.Sputnik");
                                VaccineType vac = (VaccineType)int.Parse(Console.ReadLine());
                                if (i.registrationNo == registerNo)
                                {
                                    Vaccination person = new Vaccination(vac, DateTime.Now);
                                    if (i.vaccineDetails == null)
                                    {
                                        i.vaccineDetails = new List<Vaccination>();

                                    }
                                    i.vaccineDetails.Add(person);

                                }
                                Console.WriteLine("Thanks for your Vaccination");
                                break;
                            case 2:
                                VaccinationHistory(registerNo);
                                break;
                            case 3:
                                NextDueDate(registerNo);
                                break;
                            default:
                                Console.WriteLine("Enter valid input");
                                break;
                        }
                        Console.WriteLine("Do you want to continue?yes or no");
                        choice = Console.ReadLine().ToLower();

                    } while (choice == "yes");
                }
            }
        }
        public void VaccinationHistory(int registerNo)
        {
            foreach(BeneficiaryDetails i in beneficiary)
            {
                if(i.registrationNo==registerNo)
                {
                    Console.WriteLine("Registration number is {0} whose name is{1} vaccinated dose {2}", i.registrationNo, i.name, i.vaccineDetails.Count);

                }
            }
        }
        public void NextDueDate(int registerNo)
        {
            foreach (BeneficiaryDetails i in beneficiary)
            {
                if(i.registrationNo==registerNo)
                {
                    if(i.vaccineDetails.Count==1)
                    {
                        Console.WriteLine("You are vaccinated:" + i.vaccineDetails.Count);
                        Console.WriteLine("Your next due date is:" + i.vaccineDetails[0].date.AddDays(30));
                    }
                    else if (i.vaccineDetails.Count==2)
                    {
                        Console.WriteLine("You have taken two doses");
                    }
                }
            }

        }
        
    }

}
   

