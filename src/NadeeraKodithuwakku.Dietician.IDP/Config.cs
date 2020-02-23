// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace NadeeraKodithuwakku.Dietician.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            { };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client {
                    ClientName = "Dietician Admin",
                    ClientId = "DieticianAdminClient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>(){
                        "https://localhost:44368/signin-oidc"
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    }
                }
            };

    }
}