using LearnCore.Web.Data;
using LearnCore.Web.Interfaces;
using LearnCore.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnCore.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRespository<Customer> _customerRepository;

        public CustomerService(IRespository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task DeleteCustomer(Customer model)
        {
            await _customerRepository.DeleteAsync(model);
        }

        public async Task<Customer> GetCustomerById(long id)
        {
            return _customerRepository.Table.Where(c => c.Id == id).FirstOrDefault();
        }

        public async Task<Customer> InsertCustomerModel(CustomerModel model)
        {
            var customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                EmailId = model.EmailId,
                Gender = model.Gender,
                MobileNo = model.MobileNo,
                TermAndCondition = model.TermAndCondition
            };

            var insertedcustomer = await _customerRepository.InsertAsync(customer);
            return insertedcustomer;
        }

        public async Task<IList<CustomerModel>> PrepareCustomerListModel(CustomerSearchListModel searchModel)
        {
            var model = new List<CustomerModel>();

            var query = _customerRepository.Table;

            if (!string.IsNullOrEmpty(searchModel.SearchByEmailId))
                query = query.Where(c => c.EmailId.Trim() == searchModel.SearchByEmailId.Trim());

            if (!string.IsNullOrEmpty(searchModel.SearchByMobile))
                query = query.Where(c => c.MobileNo.Trim() == searchModel.SearchByMobile.Trim());

            query = query.OrderByDescending(c => c.Id);

            foreach (var customer in query)
                model.Add(new CustomerModel
                {
                    Id = customer.Id,
                    Age = customer.Age,
                    EmailId = customer.EmailId,
                    FirstName = customer.FirstName,
                    Gender = customer.Gender,
                    LastName = customer.LastName,
                    MobileNo = customer.MobileNo,
                    TermAndCondition = customer.TermAndCondition
                });

            return model.ToList();
        }

        public async Task<IList<CustomerModel>> PrepareCustomerListModel()
        {
            var model = new List<CustomerModel>();

            var query = _customerRepository.Table;

            query = query.OrderByDescending(c => c.Id);

            foreach (var customer in query)
                model.Add(new CustomerModel
                {
                    Id = customer.Id,
                    Age = customer.Age,
                    EmailId = customer.EmailId,
                    FirstName = customer.FirstName,
                    Gender = customer.Gender,
                    LastName = customer.LastName,
                    MobileNo = customer.MobileNo,
                    TermAndCondition = customer.TermAndCondition
                });

            return model.ToList();
        }

        public async Task<CustomerModel> PrepareCustomerModel()
        {
            var model = new CustomerModel();

            for (int i = 18; i <= 40; i++)
                model.AvailableAges.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });

            return model;
        }

        public async Task<Customer> UpdateCustomerModel(CustomerModel model)
        {
            //customer email id and mobile number is not allowed to change
            var customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,               
                Gender = model.Gender,
                TermAndCondition = model.TermAndCondition
            };

            var updatedcustomer = await _customerRepository.UpdateAsync(customer);
            return updatedcustomer;
        }
    }
}
