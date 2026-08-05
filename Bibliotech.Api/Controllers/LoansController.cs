using Microsoft.AspNetCore.Mvc;
using Bibliotech.Domain.Services;

namespace Bibliotech.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly LoanService _loanService;

        public LoansController(LoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        public async Task<IActionResult> Borrow(int memberId, int bookId)
        {
            try
            {
                var loan = await _loanService.BorrowAsync(memberId, bookId);
                return Ok(loan);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("{loanId:int}/return")]
        public async Task<IActionResult> Return(int loanId)
        {
            try
            {
                var loan = await _loanService.ReturnAsync(loanId);
                return Ok(loan);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
