﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HobbyListForHobbyist.Models;
using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HobbyListForHobbyist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IConfiguration _config;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = configuration;
        }

        // register
        // POST: api/account/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = register.Email,
                UserName = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

                await _signInManager.SignInAsync(user, false);

                return Ok();
            }

            return BadRequest("Invalid Registration");
        }

        // Login
        // POST: api/account/Login
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(login.Email);

                var identityRole = await _userManager.GetRolesAsync(user);

                var token = CreateToken(user, identityRole.ToList());

                return Ok(new
                {
                    jwt = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return BadRequest("Invalid Attempt");
        }


        // assign roles
        // POST: api/assign/role
        [HttpPost("assign/role")]
        [Authorize(Policy = "AdminPrivileges")]
        public async Task AssignRoleToUser(AssignRoleDTO assignment)
        {
            var user = await _userManager.FindByEmailAsync(assignment.Email);

            await _userManager.AddToRoleAsync(user, assignment.Role);
        }

        //Create Token
        private JwtSecurityToken CreateToken(ApplicationUser user, List<string> role)
        {
            // ============== TODO Decide on claims =====================
            var authClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("UserId", user.Id)
            };

            foreach (var item in role)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, item));
            }

            var token = AuthenticationToken(authClaims);

            return token;
        }

        // Authenticate a Token
        private JwtSecurityToken AuthenticationToken(List<Claim> claims)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTKey"]));

            var token = new JwtSecurityToken(
                issuer: _config["JWTIssuer"],
                audience: _config["JWTIssuer"],
                expires: DateTime.UtcNow.AddHours(24),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
