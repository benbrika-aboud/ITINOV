using BanqueITINOV.DTOs;
using BanqueITINOV.Entities;
using BanqueITINOV.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanqueITINOV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("historical/{customerId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetHistorical(int customerId)
        {
            var transactions = await _customerService.GetHistoricalTransactionsAsync(customerId);
            if(transactions.Count() == 0)
            {
                return NoContent();
            }
            return Ok(transactions);
        }

        [HttpPut]
        public async Task<ActionResult<Account>> UpdateAccount(AccountUpdateDto accountUpdateDto)
        {
            //la methode GetUsername est une extension quon a developer dans la classe Extensions/ClaimsPrincipalExtensions
            var account = await _customerService.UpdateAaccountAsync(accountUpdateDto.CustomerId, accountUpdateDto.Amount, accountUpdateDto.Type);
            if (account != null)
                return Ok(account);

            return BadRequest("We're not able to execute the transaction");
   
        }
    }
}
