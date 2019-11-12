using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Domain;

namespace Web.Repositories.Interface
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task<int> InsertCustomerAsync(Customer customer);

        /// <summary>
        /// 取得全部客戶資料
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetCustomersAsync();

        /// <summary>
        /// 依據客戶ID取得客戶資料
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Customer> GetCustomerByIdAsync(object customerId);

        /// <summary>
        /// 更新客戶資料
        /// </summary>
        /// <param name="customer"></param>
        Task<int> UpdateCustomerAsync(Customer customer);

        /// <summary>
        /// 刪除客戶資料
        /// </summary>
        /// <param name="customerId"></param>
        Task<int> DeleteCustomerAsync(object customerId);
    }
}
