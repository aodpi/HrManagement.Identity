// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace hrid
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("hrm.backend")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("hrm.backend.api", "HRM API")
                {
                    Scopes = { "hrm.backend" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "hrm.angular",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "http://localhost:4200/signin-callback", "https://hrmdev.tk/signin-callback" },
                    PostLogoutRedirectUris = { "http://localhost:4200/signout-callback", "https://hrmdev.tk/signout-callback" },
                    AllowedCorsOrigins = { "http://localhost:4200", "https://hrmdev.tk" },
                    AccessTokenLifetime = 60,
                    AllowOfflineAccess = false,
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedScopes = { "openid", "profile", "hrm.backend" },
                    ClientName = "HRM Angular UI Frontend",
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RequireConsent = false
                }
            };
    }
}