using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace JwtTokenApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //priate key in base64
            var privateKeyBase64 = "LS0tLS1CRUdJTiBQUklWQVRFIEtFWS0tLS0tCk1JSUV2UUlCQURBTkJna3Foa2lHOXcwQkFRRUZBQVNDQktjd2dnU2pBZ0VBQW9JQkFRRHhWSjM0K3ArdXFGUVIKTEZFNHZFWW9GRHZvQ0FGeFhDQlltdXhmeC9CN2dCVi9DYU1qd0l6UUZjdDd1WUJPV09rNmFIY1gzNUdYRkNENQpZRHBHbTdDY09nSWcwaWMrck4ybU8yNTBiVjNieXI5TlJXQ2FmTXVpNVIwaHpRL3JvSkNjRjlSSlJGVDc4TzRMCldyZ1k3TjBFbmRyM25jVEJZNGNWSEF3MmJoV1plS2E5ak82RG5rZUFtQm56WjZkOW5ob3kyT1h4eU4zcDlLc3cKNXpJaW55YUgzVzkwMjNlTURHdnhFSWNSNDUzTkNiK1NweWZveDlNWXVlM0U1Y2wzbGM5b1hmcmlqblg0YU5ITQpJOXhzWUpaaFMxY3Rpd0x5SWNhZW41Wml6NFhyMkFKOHQxZWZPWDJwODJoTkVjQkJYQVhUVUZZT2gvVmMyOTJsCi9iUlBvYW4xQWdNQkFBRUNnZ0VBRGtNckg0Mm04SnBpZHRpdzBpZ1ByZ3NJRnFpYnkrTWZIRUxIcVI5MnRHM00KN01MdWk4eUk1ZWFyMkhEaThYNXFzT04vU2xTOFZNL3I1UFppd0tLRWpRUnI5TWJ4YW5yLzV4K2R0d1FjVWNMZQpqSEZjWDErZkQwNU5hdlBQWVk4TjRpa1JzdVRNR3ZtbkJTL0VMK0Ryd2xGQlRCOWNXS0RmcmwweWZEMnU5QnRpCmFjbFJLKzNTQWlZemo5OVd1VCtZWWZhZ3dmMGNyaXBNM29jWTdPWnkxY1VnMVZ0TW1jUmRpN1djYm91QnFhWUYKS1J5OU8rU0ZRTXZLN1M5U2FjbU1KV2pLM09tckFwOSttVjdyK3RWdFpQaVppTm4wM2YrOWtCUjdmaE5XSUhaMQpWbHFpSU9HRDhEdEZMUDFWdnByaUxkVU5ZQnNYUTMxWWs5M0h0YmRrWHdLQmdRRDdNNStSdEpRN3JrZ0t2ZktDCnFjZTQ0TWFhWjQ4WjFHS0FSWFZ6T3JUQ2pTVWpIc1NtSjMvUFE1eTNwM21hamw0U2VNMmZ5K1liU3JiSmFIMnUKOGdLNjNUR294aXNjR2xuQWU2cUgybmorYkxWejd4U1NDdjdpa0lrTGtqOGovMk5WY3ZIbnBZUnVmOGVla0o5Vwowa0NSU3hmUUdJQldNT1dhSS9lUE9RV2FEd0tCZ1FEMThMbFdQNzU5NTZYV2VNSzc1UWpIMGZ6MjdmdmJKOGdaCmUxWkpPUGZuRU9BZE16RmJ0SEIwNGdoQWhHMUlIZzBmLysrUUVaTFNzaUM2S3lZY2lwOVliVWVrOVp3ZkUvaCsKQkl6d0NFblJvWFdjU3h3Tk5ocEZzNDVOa3JoOVFhdHRidkdjMGdwUURmSUQ4d2ZEQitQazJQOGduV0FoOVgzbQpHYnY0SjRqUHV3S0JnRHZrNFNVU2swMXZqb25SSkdOM0s4R3ZCbXVHU1o1MC8wOXFRRWpMTkpJMnFTWW9qZWE0CkFFZGc3WnIwZVpBYVpkK3RvZ2w1eWxHempNV1UvbkthRFlDVWdPU202MXgyQS9SYkNCd0FRVjBZZW1NOEhBRisKVWF1Zm5xMTluMFJyL2prL2dPSWttdURsNHFpeC91dnFrYTZTNHdpZzd1aWVIQUNXbHM0MVlGcU5Bb0dCQU54NApoY3pacSt5MlFxWTI3MnI4OEpnZ21JTEw2S0VYMG50MVkyNlVrVGNrbTZQUmhvZk5BNXJrSGIyb2VVYlRHYlQ3Ci9FZk1XVEJqMm83SnE0cWVnaVlGSU5xeUN0aVpVSU8zbEppQTladmsvOGV5VlYxS2lOYS9GZXhZZ09aWWZsTEYKeC9ackhDK1RzTWIxa0ptM2N3WnR1SmdHUEcxMDR2M3BSK1kzbXArTkFvR0FQVkFoY2h4bi9MelpjM2RPUnh1KwpOdHE4UEUwY3NCMXE3OXFvalNQUE4wRUpXMHdubnoxeE1BL1BGMUZhYk9mdVhIMTl4NVFscmVzRk53aG1tTStaClNwV28wRk5QdFpzaUlmU3plaWhtcmZRR1lHd1FrMTZMeWNzU0FBN3R2eXlRUGZVeWtsNUJ3YVd4L2RXZzZ6RDIKMGE2TzlZVVRUNXBVU2ZBWkYwbkxERVE9Ci0tLS0tRU5EIFBSSVZBVEUgS0VZLS0tLS0K";
            var privateText = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(privateKeyBase64)); //System.IO.File.ReadAllText(@"C:\Users\Robert.Herzog\projects\csharpjwtgeficke\private_key.pem");

            
            using RSA rsa = RSA.Create();
            rsa.ImportFromPem(privateText.ToCharArray()); 

            // SigningCredentials
            var signingCredentials = new SigningCredentials(
                new RsaSecurityKey(rsa),
                SecurityAlgorithms.RsaSha512
            );


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Claims = new Dictionary<string, object>
    {
        { "data", "look mom! JWT!" }
    },
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = signingCredentials
            };


            // generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

           
            Console.WriteLine("Generated JWT-Token:");
            Console.WriteLine(jwtToken);
            var publicKeyText = System.IO.File.ReadAllText(@"path\to\public_key.pem");
            using RSA rsaPublic = RSA.Create();
            rsaPublic.ImportFromPem(publicKeyText.ToCharArray());

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new RsaSecurityKey(rsaPublic)
            };

            try
            {
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(jwtToken, validationParameters, out validatedToken);

                Console.WriteLine("Token validated succeesfully:");
                foreach (var claim in principal.Claims)
                {
                    Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Token could not be validated reason:");
                Console.WriteLine(ex.Message);



            }
        }
    }
}