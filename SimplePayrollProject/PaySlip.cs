using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace SimplePayrollProject
{
    public class PaySlip
    {
        private int month;
        private int year;

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public enum MonthsOfYear
        {
            JAN = 1, FEB = 2, MARCH, APRIL, MAY, JUNE, JULY, AUGUST, SEPTEMBER, OCTOBER, NOVEMBER, DECEMBER
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {

            string path;
            foreach (Staff f in myStaff)
            {

                path = f.NameOfStaff + ".txt";

                using (StreamWriter sw = new StreamWriter(path))
                {

                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("========================");
                    sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);

                    if (f.GetType() == typeof(Manager))
                    {
                        sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                    }
                    else if (f.GetType() == typeof(Admin))
                    {
                        sw.WriteLine("Overtime: {0:C}", ((Admin)f).Overtime);
                    }

                    sw.WriteLine("");
                    sw.WriteLine("========================");
                    sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                    sw.WriteLine("========================");

                    sw.Close();

                }
            }
        }
        public void GenerateSummary(List<Staff> myStaff)
        {

            var result =
                from f in myStaff
                where f.HoursWorked < 10
                orderby f.NameOfStaff ascending
                select new { f.NameOfStaff, f.HoursWorked };

            string path = "summary.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");

                foreach (var f in result)
                {
                    Console.WriteLine("Name of Staff: {0}, Hours Worked: {1}", f.NameOfStaff, f.HoursWorked);
                }

                sw.Close();

            }
        }
        public override string ToString()
        {
            return "month = " + month + "year = " + year;
        }
    }


}
