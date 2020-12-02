using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ef5_core31_poc
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Build DB and Add records");
            using (var ctxSetup = new emppocContext())
            {
                ctxSetup.Database.EnsureDeleted(); //Wipe out
                ctxSetup.Database.EnsureCreated(); //Create

                //Add some employees
                ctxSetup.Employees.Add(new Employee()
                {
                    EmployeeNumber = "ABC123",
                    EmployeeEmails = "|emp1@deloveh.com|dave@deloveh.com|"
                });
                ctxSetup.Employees.Add(new Employee()
                {
                    EmployeeNumber = "DEF456",
                    EmployeeEmails = "|emp2@deloveh.com|"
                });

                ctxSetup.SaveChanges(); //Commit them
            }

            Console.WriteLine("Display Employees");

            //Build a new context to display them
            using (var ctx = new emppocContext())
            {
                ctx.Employees.ToList().ForEach(e => Console.WriteLine($"Employee Number={e.EmployeeNumber}\tEmails={e.EmployeeEmails}"));
            }

            Console.WriteLine("Done!");
        }
    }
}
