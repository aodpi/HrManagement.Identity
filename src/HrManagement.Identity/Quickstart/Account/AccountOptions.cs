// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;

namespace HrManagement.Identity.Quickstart.Account
{
    public static class AccountOptions
    {
        public const bool AllowLocalLogin = true;
        public const bool AllowRememberLogin = true;
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);

        public const bool ShowLogoutPrompt = true;
        public const bool AutomaticRedirectAfterSignOut = false;

        public const string InvalidCredentialsErrorMessage = "Invalid username or password";
    }
}