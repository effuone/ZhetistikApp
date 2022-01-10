using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zhetistik.Api.Areas.Identity.Data;
using Zhetistik.Api.Common.Models;
using Zhetistik.Api.Data;

namespace Zhetistik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ZhetistikApiContext _dbContext;
        private readonly UserManager<ZhetistikUser> _userManager;
        private readonly SignInManager<ZhetistikUser> _signInManager;

        public AccountController(ZhetistikApiContext dbContext, UserManager<ZhetistikUser> userManager, SignInManager<ZhetistikUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpPost("getToken")]
        public async Task<ActionResult> GetToken([FromBody] LoginModelType loginModel)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == loginModel.Email);
            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
                if (signInResult.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("MY_BIG_SECRET_KEY_LKSHDJFLSDKJFW@#($)(#)34234");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, loginModel.Email)
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Ok("Failed, try again");
                }
            }
            return Ok("Failed, try again");
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] LoginModelType loginModel)
        {
            ZhetistikUser user = new ZhetistikUser()
            {
                Email = loginModel.Email,
                UserName = loginModel.Email,
                EmailConfirmed = false
            };
            var result = await _userManager.CreateAsync(user, loginModel.Password);
            if (result.Succeeded)
            {
                return Ok(new { Result = "Register Success" });
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.Append(error.Description);
                }
                return Ok(new { Result = $"Register Fail: {stringBuilder.ToString()}" });
            }
        }
    }
}
