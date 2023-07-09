using System;
using learning_asp.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace learning_asp.Options
{
    public class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
	{
		private readonly JwtOptions _jwtOptions;

		public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions) {
            _jwtOptions = jwtOptions.Value;
		}

		public void Configure(string? name, JwtBearerOptions options) {
            options.TokenValidationParameters = new() {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Issuer, 
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                ClockSkew = TimeSpan.Zero
            };
		}

        public void Configure(JwtBearerOptions options)
        {
            // This will never be called
            throw new NotImplementedException();
        }
    }
}

