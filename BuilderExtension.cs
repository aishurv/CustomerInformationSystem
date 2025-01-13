using CustomerInformationSystem.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CustomerInformationSystem
{
    public static class BuilderExtension
    {
        /// <summary>
        /// Add Services to the WebApplicationBuilder builder
        /// </summary>
        /// <param name="builder"></param>
        public static void AddBuilderServices(this WebApplicationBuilder builder)
        {
             builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
                .AddIdentityCookies();
        }
    }
}
