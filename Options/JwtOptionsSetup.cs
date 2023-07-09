using System;
using learning_asp.Service;
using Microsoft.Extensions.Options;

namespace learning_asp.Options
{
	public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
	{
		private readonly string Section = "JwtSettings"; 
		private readonly IConfiguration _configuration;

		public JwtOptionsSetup(IConfiguration configuration) {
			_configuration = configuration;
		}

		public void Configure(JwtOptions jwtOptions) {
			_configuration.GetSection(Section).Bind(jwtOptions);
		}
	}
}

