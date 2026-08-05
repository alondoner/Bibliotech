using Microsoft.AspNetCore.Mvc;
using Bibliotech.Domain.Services;
using Bibliotech.Domain.Entities;

namespace Bibliotech.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly MemberService _memberService;
        private readonly LoanService _loanService;

        public MembersController(MemberService memberService, LoanService loanService)
        {
            _memberService = memberService;
            _loanService = loanService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            await _memberService.AddAsync(member);
            return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
        }

        [HttpGet("{id:int}/loans")]
        public async Task<IActionResult> GetLoans(int id)
        {
            var loans = await _loanService.GetLoansByMemberAsync(id);
            return Ok(loans);
        }

        [HttpGet("{id:int}/penalties")]
        public async Task<IActionResult> GetPenalties(int id)
        {
            var loans = await _loanService.GetLoansByMemberAsync(id);
            var total = loans.Sum(l => l.MontantPenalite);

            return Ok(new { TotalPenalties = total });
        }
    }
}
