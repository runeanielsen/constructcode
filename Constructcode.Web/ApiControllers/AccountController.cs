using AutoMapper;
using Constructcode.Web.ApiControllers.DataTransferObjects;
using Constructcode.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Constructcode.Web.ApiControllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto dto)
        {
            var account = _accountService.GetAccount(dto.Username);

            if (account is null || !_accountService.VerifyAccountLogin(account, dto.Password))
                return BadRequest("Bad Username or Password");

            var authenticationClaim = _accountService.CreateAuthenticationClaim(account);

            await HttpContext.SignInAsync(authenticationClaim, new AuthenticationProperties
            {
                IsPersistent = dto.Remember,
                ExpiresUtc = new DateTimeOffset(DateTime.Now).AddDays(30)
            });

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateAccount([FromBody]UpdateAccountDto dto)
        {
            if (string.IsNullOrEmpty(dto.Password))
                return BadRequest("Password cannot be empty");

            if (dto.Password.Length < 5)
                return BadRequest("Password need to be 5 characters or longer");

            var account = _accountService.GetAccount(User.FindFirst("name").Value);
            _accountService.UpdateAccount(_mapper.Map(dto, account));

            return Ok("Account updated");
        }
    }
}
