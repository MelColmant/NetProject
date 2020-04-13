using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.JWT
{
    public class JWTService
    {
        private readonly string signature;
        private readonly string issuer;
        private readonly string audience;

        private readonly JwtSecurityTokenHandler handler;

        public JWTService(string signature, string issuer, string audience)
        {
            this.signature = signature;
            this.issuer = issuer;
            this.audience = audience;
            this.handler = new JwtSecurityTokenHandler();
        }

        public bool ValidateToken(string token)
        {
            TokenValidationParameters parameters =
                new TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    RequireSignedTokens = true,
                    IssuerSigningKey = GenerateSignature(),
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            try 
            {
                handler.ValidateToken(
                    token,
                    parameters,
                    out SecurityToken s_token);
                    return true;
            } catch(Exception){ return false; }
        }

        public string Encode<T>(T t_payload) 
        {
            //générer un header sur base de la signature
            JwtHeader header = new JwtHeader(
                new SigningCredentials(
                    GenerateSignature(),
                    SecurityAlgorithms.HmacSha256)
                );

            //générer le payload
            JwtPayload payload = new JwtPayload(
                this.issuer,
                this.audience,
                typeof(T).GetProperties()
                .Select(p =>
                {
                    return new Claim(
                        p.Name,
                        p.GetValue(t_payload).ToString()
                        );
                }),
                DateTime.Now,
                DateTime.Now.AddDays(1)
            );

            //générer un token sur base d'un header et d'un payload
            JwtSecurityToken token = new JwtSecurityToken(header, payload);
            return handler.WriteToken(token);
        }

        private SecurityKey GenerateSignature()
        {
            return new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(this.signature)
                        );
        }

    }
}
