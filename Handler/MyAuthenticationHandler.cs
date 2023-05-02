using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace LearnAspNet.Handler
{
    public class MyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public MyAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {

        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return AuthenticateResult.NoResult();
        }
    }
}