using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using ToDo.Domain.Models;

namespace ToDo.Infra.CrossCutting.Token
{
	public static class TokenSecurity
	{
		public static void ConfigureToken(this IServiceCollection services, IConfiguration configuration)
		{
			var loginConfigurations = new LoginConfiguration();
			services.AddSingleton(loginConfigurations);
			TokenConfigurationModel tokenConfigurations = RetornarTokenConfiguration(configuration);
			services.AddSingleton(tokenConfigurations);

			services.AddAuthentication(authOptions =>
			{
				authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(bearerOptions =>
			{
				var parametroValidacao = bearerOptions.TokenValidationParameters;
				parametroValidacao.ValidAudience = tokenConfigurations.Audience;
				parametroValidacao.IssuerSigningKey = loginConfigurations.Key;
				parametroValidacao.ValidateIssuerSigningKey = true;
				parametroValidacao.ValidIssuer = tokenConfigurations.Issuer;
				parametroValidacao.ClockSkew = TimeSpan.Zero;
				parametroValidacao.ValidateLifetime = true;
			});

			services.AddAuthorization(auth =>
			{
				auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
					.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
					.RequireAuthenticatedUser().Build());
			});
		}

		private static TokenConfigurationModel RetornarTokenConfiguration(IConfiguration configuration)
		{
			var tokenConfigurations = new TokenConfigurationModel();
			new ConfigureFromConfigurationOptions<TokenConfigurationModel>(
				configuration.GetSection("TokenConfigurations"))
					.Configure(tokenConfigurations);
			return tokenConfigurations;
		}
	}
}
