using BankCRUDusingdapperwebapi.Model;

namespace BankCRUDusingdapperwebapi.Repository.Interface
{
    public interface IBankRepository
    {
        public Task<IEnumerable<Bank>> GetAllBanks();
        public Task<Bank> GetBankById(int id);
        public Task<int> InsertCostumer(Customer customer);
        public Task<int> DeleteCustomer(int id);
        public Task<int> TrunketeTable(int id);
        public Task<int> DeleteBank(int id);
        
    }
}
