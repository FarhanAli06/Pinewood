
using System;
using System.Collections.Generic;
using PinewoodDMS.Domain;
namespace PinewoodDMS.Application.Constants
{
    public static class DummyData
    {
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 30,
                    Email = "john.doe@example.com",
                    PhoneNumber = "555-1234",
                    Address = "123 Main St, Anytown, USA",
                    CreatedDate = DateTime.Now.AddDays(-10)
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Age = 25,
                    Email = "jane.smith@example.com",
                    PhoneNumber = "555-5678",
                    Address = "456 Elm St, Anytown, USA",
                    CreatedDate = DateTime.Now.AddDays(-20)
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Age = 35,
                    Email = "alice.johnson@example.com",
                    PhoneNumber = "555-8765",
                    Address = "789 Maple Ave, Anytown, USA",
                    CreatedDate = DateTime.Now.AddDays(-30)
                },
                new Customer
                {
                    Id = 4,
                    FirstName = "Bob",
                    LastName = "Brown",
                    Age = 40,
                    Email = "bob.brown@example.com",
                    PhoneNumber = "555-4321",
                    Address = "101 Pine St, Anytown, USA",
                    CreatedDate = DateTime.Now.AddDays(-40)
                },
                new Customer
                {
                    Id = 5,
                    FirstName = "Carol",
                    LastName = "White",
                    Age = 28,
                    Email = "carol.white@example.com",
                    PhoneNumber = "555-6789",
                    Address = "202 Oak St, Anytown, USA",
                    CreatedDate = DateTime.Now.AddDays(-50)
                }
            };
        }
    }
}
