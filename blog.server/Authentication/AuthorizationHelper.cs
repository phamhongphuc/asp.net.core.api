﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace blog.server.Authentication
{
    public static class AuthorizationHelper
    {
        private static IConfiguration Configuration;

        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static string TokenBuilder(string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Configuration["JWT:issuer"],
                Configuration["JWT:audience"],
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(3),
                claims: new[]
                {
                    new Claim(ClaimTypes.Email, email)
                }
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
