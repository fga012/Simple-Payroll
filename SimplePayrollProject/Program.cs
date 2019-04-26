using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SimplePayrollProject
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            var month = 0;
            var year = 0;

            while (year == 0)
            {
                Console.Write("\nPlease enter the year: ");

                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid format. Try again");
                }
            }

            while (month == 0)
            {
                Console.Write("\nPlease enter the month: ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1|| month > 12)
                    {
                        Console.WriteLine("You have entered invalid value");
                        month = 0;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine("Invalid value, try again" + e.Message);
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine("Enter hours worked for {0}: ", myStaff[i].NameOfStaff);
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input" + e.Message);
                    i--;
                }
            }

            var ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
            Console.Read();

        }
    }


}
