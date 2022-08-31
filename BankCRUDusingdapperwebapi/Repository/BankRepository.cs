using BankCRUDusingdapperwebapi.Context;
using BankCRUDusingdapperwebapi.Model;
using BankCRUDusingdapperwebapi.Repository.Interface;
using Dapper;

namespace BankCRUDusingdapperwebapi.Repository
{
    public class BankRepository: IBankRepository
    {
        private readonly DapperContext _context;
        public BankRepository(DapperContext context)
        {
 
            _context = context;
            
        }

        public async Task<int> DeleteBank(int id)
        {
            
            string query = "delete tblBank where bId=@bId";
            using(var connection=_context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, new { bId = id });
                
                   var ret =await TrunketeTable(id);

                return result;

            }
        }

        public async Task<int> DeleteCustomer(int id)
        {
            string query = "delete tblCustomer where custId=@custId";
            using(var connection=_context.CreateConnection())
            {
                int result = await connection.ExecuteAsync(query, new { custId = id });
                return result;
            }
        }

        public async Task<IEnumerable<Bank>> GetAllBanks()
        {
            List<Bank> bankslist = new List<Bank>();
            string query= "select * from tblBank";
            using(var connection=_context.CreateConnection())
            {
                var banks = await connection.QueryAsync<Bank>(query);
                  
                    bankslist= banks.ToList();
                foreach(var bank in bankslist)
                {
                    var result = await connection.QueryAsync<Customer>(@"select * from tblCustomer where bId=@bId", new { bId = bank.bId });
                    bank.customerslist = result.ToList();
                }
                return bankslist;
            }
        }

        public async Task<Bank> GetBankById(int id)
        {
            Bank bk = new Bank();
            string query = "select * from tblBank where bId=@bId";
            using(var connection=_context.CreateConnection())
            {
                var bank = await connection.QuerySingleAsync<Bank>(query, new { bId = id });
                bk= bank;
                if(bk!=null)
                {
                    var showcust = await connection.QueryAsync<Customer>(@"select * from tblCustomer where bId=@bId", new { bId = id });
                    bk.customerslist= showcust.ToList();    
                }
                return bk;
            }
        }

        public async Task<int> InsertCostumer(Customer customer)
        {
            string qry = "insert into tblCustomer(bId,custName,mobileNo,accountType,balance) values(@bId,@custName,@mobileNo,@accountType,@balance)";
            using(var connection=_context.CreateConnection())
            {
                var cust = await connection.ExecuteAsync(qry, customer);
                return cust;
            }
        }

        public async Task<int> TrunketeTable(int id)
        {
            string qry = "delete tblCustomer where bId=@bId";
            using (var connection = _context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(qry, new {bId=id});
                return result;
            }
        }
    }
}
