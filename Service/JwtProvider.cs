﻿using System;
using learning_asp.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using learning_asp.Model;

namespace learning_asp.Service
{
	public class JwtProvider : IJwtProvider
	{
		public JwtOptions _jwtOptions;

        public JwtProvider(IOptions<JwtOptions> jwtOptions)
		{
			_jwtOptions = jwtOptions.Value;
		}

		public string Generate(User input) {
			var claims = new Claim[] {
				new Claim(JwtRegisteredClaimNames.Email, input.Email),
				new Claim("name", input.Name)
			};
			    
			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
				SecurityAlgorithms.HmacSha256
			);

			var token = new JwtSecurityToken(
                 _jwtOptions.Issuer,
                 _jwtOptions.Audience,
				 claims,
				 null,
				 DateTime.Now.AddHours(1),
                 signingCredentials
            );

			string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

			return tokenValue;
		}
	}
}

