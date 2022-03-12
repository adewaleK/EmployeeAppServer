using EmployeeApp.Models;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApp.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.EnsureCreated();

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new List<Employee>() {
                    new Employee()
                    {
                        FirstName= "Abass",
                        LastName = "Akande",
                        Address = "42, HAssan balogun, Isheri",
                        Salary = "200,000",
                        PhoneNmber = "07038893413",
          
                    },
                      new Employee()
                    {
                        FirstName= "Ahmed",
                        LastName = "Ibrahim",
                        Address = "52, London Avenue, Isheri",
                        Salary = "200,000",
                        PhoneNmber = "08038893413",

                    },
                      new Employee()
                    {
                        FirstName= "Bob",
                        LastName = "James",
                        Address = "12, Asajoh way, Ajah",
                        Salary = "200,000",
                        PhoneNmber = "08138893413",

                    },



                });

                    context.SaveChanges();
                }

            }

        }
    }
}
