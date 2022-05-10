using LearnCore.Web.Data;
using LearnCore.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnCore.Web.Interfaces
{
    public interface ICustomerService
    {
        Task<IList<CustomerModel>> PrepareCustomerListModel();
        Task<IList<CustomerModel>> PrepareCustomerListModel(CustomerSearchListModel searchModel);
        Task<CustomerModel> PrepareCustomerModel();
        Task<Customer> GetCustomerById(long id);
        Task<Customer> InsertCustomerModel(CustomerModel model);
        Task<Customer> UpdateCustomerModel(CustomerModel model);
        Task DeleteCustomer(Customer model);
    }
}
