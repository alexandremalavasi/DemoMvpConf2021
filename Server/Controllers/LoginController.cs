using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MVPConfDemo.Shared;

namespace MVPConfDemo.Server.Controllers
{
    [ApiController, Route("api")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var result = login.Username == "admin" && login.Password == "test" || login.Username == "organizer" && login.Password == "test";

            if (!result) return BadRequest(new LoginResult { Successful = false, Error = "Username and password are invalid." });

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, login.Username));

            if (login.Username == "admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            if (login.Username == "organizer")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Organizer"));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}