using BankCRUDusingdapperwebapi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankCRUDusingdapperwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankRepository _bankRepo;
        public BankController(IBankRepository bankRepo)
        {
            _bankRepo = bankRepo;
        }  
        [HttpGet]   
        public async Task<IActionResult> GetAllBanks()
        {
            var result=await _bankRepo.GetAllBanks();
            return Ok(result);

        }
        [HttpGet("/id")]
        public async Task<IActionResult> GetBanksById(int id)
        {
            try
            {
                var resul = await _bankRepo.GetBankById(id);
                return Ok(resul);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "something is wrong");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DelelteBank(int id)
        {
            try
            {
                var result = await _bankRepo.DeleteBank(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Something wrong");
            }
        }
    }
}
