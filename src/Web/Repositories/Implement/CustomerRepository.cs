using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Web.Domain;
using Web.Repositories.Interface;

namespace Web.Repositories.Implement
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Property

        private IDbConnection Conn { get; }

        #endregion

        #region Constructor

        public CustomerRepository(IDbConnection connection)
        {
            Conn = connection;
        }

        #endregion

        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<int> InsertCustomerAsync(Customer customer)
        {
            int result;

            using (var db = Conn)
            {
                string sql = @"Insert into Customers 
                                (CustomerID, CompanyName) 
                               Values 
                                (@CustomerID, @CompanyName)";

                result = await db.ExecuteAsync(sql, customer);
            }

            return result;
        }

        /// <summary>
        /// 取得全部客戶資料
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            IEnumerable<Customer> customers;

            using (var db = Conn)
            {
                string sql = @"Select * from Customers";

                customers = await db.QueryAsync<Customer>(sql);
            }

            return customers;
        }

        /// <summary>
        /// 依據ID取得客戶資料
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomerByIdAsync(object customerId)
        {
            Customer customer;

            using (var db = Conn)
            {
                string sql = @"Select * from Customers where CustomerID = @id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("id", customerId);

                customer = await db.QueryFirstAsync<Customer>(sql, parameters);
            }

            return customer;
        }

        /// <summary>
        /// 更新客戶資料
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            int result;

            using (var db = Conn)
            {
                string sql = @"Update Customers Set 
                                 CompanyName = @CompanyName
                                Where CustomerID = @CustomerID";

                result = await db.ExecuteAsync(sql, customer);
            }

            return result;
        }

        /// <summary>
        /// 刪除客戶資料
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<int> DeleteCustomerAsync(object customerId)
        {
            int result;

            using (var db = Conn)
            {
                string sql = @"Delete Customers where CustomerID = @id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("id", customerId);

                result = await db.ExecuteAsync(sql, parameters);
            }

            return result;
        }
    }
}
