﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Azure.WebJobs.Script.WebHost.Authentication;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Azure.WebJobs.Script.WebHost.Security.Authentication;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Azure.WebJobs.Script.WebHost.Security.Authorization;
using Microsoft.Azure.WebJobs.Script.Description;

namespace Azure.Functions.Cli.Actions.HostActions.WebHost.Security
{
    public class CliAuthenticationHandler<TOptions> : AuthenticationHandler<TOptions> where TOptions : AuthenticationSchemeOptions, new()
    {
        public CliAuthenticationHandler(IOptionsMonitor<TOptions> options, ILoggerFactory logger, UrlEncoder encoder) 
            : base(options, logger, encoder)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // This authentication handler always returns an authenticated principal with
            // the auth level claim type set to `Admin`
            var claims = new List<Claim>
                {
                    new Claim(SecurityConstants.AuthLevelClaimType, AuthorizationLevel.Admin.ToString())
                };

            var identity = new ClaimsIdentity(claims, AuthLevelAuthenticationDefaults.AuthenticationScheme);
            AuthenticateResult result = AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(identity), Scheme.Name));

            return Task.FromResult(result);
        }
    }

    public class CoreToolsAuthorizationHandler : AuthorizationHandler<FunctionAuthorizationRequirement, FunctionDescriptor>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FunctionAuthorizationRequirement requirement, FunctionDescriptor resource)
        {
            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
