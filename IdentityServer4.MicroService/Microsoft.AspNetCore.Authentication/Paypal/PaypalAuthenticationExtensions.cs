/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using System;
using AspNet.Security.OAuth.Paypal;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authentication;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods to add Paypal authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class PaypalAuthenticationExtensions
    {
        /// <summary>
        /// Adds <see cref="PaypalAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Paypal authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static AuthenticationBuilder AddPaypal(this AuthenticationBuilder builder)
        {
            return builder.AddPaypal(PaypalAuthenticationDefaults.AuthenticationScheme, options => { });
        }

        /// <summary>
        /// Adds <see cref="PaypalAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Paypal authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="configuration">The delegate used to configure the OpenID 2.0 options.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static AuthenticationBuilder AddPaypal(
            this AuthenticationBuilder builder,
            Action<PaypalAuthenticationOptions> configuration)
        {
            return builder.AddPaypal(PaypalAuthenticationDefaults.AuthenticationScheme, configuration);
        }

        /// <summary>
        /// Adds <see cref="PaypalAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Paypal authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="scheme">The authentication scheme associated with this instance.</param>
        /// <param name="configuration">The delegate used to configure the Paypal options.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddPaypal(
            this AuthenticationBuilder builder, string scheme,
            Action<PaypalAuthenticationOptions> configuration)
        {
            return builder.AddPaypal(scheme, PaypalAuthenticationDefaults.DisplayName, configuration);
        }

        /// <summary>
        /// Adds <see cref="PaypalAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Paypal authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="scheme">The authentication scheme associated with this instance.</param>
        /// <param name="caption">The optional display name associated with this instance.</param>
        /// <param name="configuration">The delegate used to configure the Paypal options.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddPaypal(
            this AuthenticationBuilder builder,
            string scheme, string caption,
            Action<PaypalAuthenticationOptions> configuration)
        {
            return builder.AddOAuth<PaypalAuthenticationOptions, PaypalAuthenticationHandler>(scheme, caption, configuration);
        }
    }
}
