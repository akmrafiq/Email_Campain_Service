using Email_Campain_Service.Core.Entities;
using Email_Campain_Service.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core.Services
{
    class CustomerService : ICustomerService
    {
        private ICampignUnitOfWork _campignUnitOfWork;

        public CustomerService(ICampignUnitOfWork campignUnitOfWork)
        {
            _campignUnitOfWork = campignUnitOfWork;
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null || string.IsNullOrWhiteSpace(customer.Name)||string.IsNullOrWhiteSpace(customer.Email))
                throw new InvalidOperationException("Incomplete information");

            _campignUnitOfWork.CustomerRepository.Add(customer);
            _campignUnitOfWork.Save();
        }
        
        public IEnumerable<Customer> GetCustomers()
        {
            return _campignUnitOfWork.CustomerRepository.GetAllItem();
        }
    }
}
