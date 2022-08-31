using BankCRUDusingdapperwebapi.Model;
using BankCRUDusingdapperwebapi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankCRUDusingdapperwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IBankRepository _bankRepo;
        public CustomerController(IBankRepository bankRepo)
        {
            _bankRepo = bankRepo;
        }   
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            var result = await _bankRepo.InsertCostumer(customer);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _bankRepo.DeleteCustomer(id);

            return Ok(result);  
        }
    }
}
