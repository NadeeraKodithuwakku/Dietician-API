// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace NadeeraKodithuwakku.Dietician.IDP
{
    public class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>
        {
            new TestUser{SubjectId = "10001", Username = "chan4lk", Password = "1q2w3e4r", 
                Claims = 
                {
                    new Claim(JwtClaimTypes.Name, "Chandima Ranaweera"),
                    new Claim(JwtClaimTypes.GivenName, "Chandima"),
                    new Claim(JwtClaimTypes.FamilyName, "Ranaweera"),
                    new Claim(JwtClaimTypes.Email, "chan4lk@gamil.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "https://chan4lk.github.io"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }
            },
            new TestUser{SubjectId = "10002", Username = "nadeera", Password = "1q2w3e4r", 
                Claims = 
                {
                    new Claim(JwtClaimTypes.Name, "Nadeera Kodithuwakku"),
                    new Claim(JwtClaimTypes.GivenName, "Nadeera"),
                    new Claim(JwtClaimTypes.FamilyName, "Kodithuwakku"),
                    new Claim(JwtClaimTypes.Email, "kodithuwakku.uom@gmail.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "https://chan4lk.github.io"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "Sri Lanka")
                }
            }
        };
    }
}