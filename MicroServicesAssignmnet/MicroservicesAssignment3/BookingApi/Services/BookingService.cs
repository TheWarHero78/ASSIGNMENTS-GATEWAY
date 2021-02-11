using BookingEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApi.Services
{
    public class BookingService
    {
        public IEnumerable<Booking> GetBookings(long? id = null)
        {
            var bookings = new List<Booking>();
            var customers = GetCustomers();
            if (id != null)
            {
                customers = customers.Where(r => r.ID == id);
            }
            foreach (var customer in customers)
            {
                for (int i = 1; i <= 3; i++)
                {
                    bookings.Add(new Booking
                    {
                        ID = i,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(i),
                        Charges = (double)i * 4.96,
                        CustomerID = i,
                        CarID = i,
                        DriverID = i,
                        ExternalID = new Guid()

                    });
                }
            }
            return bookings;
        }



        private IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            for (int i = 1; i <= 3; i++)
            {
                customers.Add(new Customer
                {
                    ID = i,
                    Name = $"Name_{i}"


                });
            }
            return customers;
        }
    }
}
