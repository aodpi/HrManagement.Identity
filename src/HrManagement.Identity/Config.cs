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
                    Scopes = { "hrm.backend", "profile" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "hrm.angular",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { 
                        "http://localhost:4200/assets/signin-callback.html",
                        "https://hrmdev.tk/assets/signin-callback.html",
                        "http://localhost:4200/assets/silent-callback.html", 
                        "https://hrmdev.tk/assets/silent-callback.html",
                    },
                    PostLogoutRedirectUris = { "http://localhost:4200", "https://hrmdev.tk" },
                    AllowedCorsOrigins = { "http://localhost:4200", "https://hrmdev.tk" },
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
