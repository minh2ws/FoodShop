using DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagementApi.Util
{
    public class JwtUtil
    {
        public static string GenerateJSONWebToken(TblEmployeesDTO employeesDTO,IConfiguration _config)
        {
            var credentials = GetCredentials(_config);
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim("idEmployee", employeesDTO.idEmployee));
            permClaims.Add(new Claim("role", employeesDTO.role));
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              permClaims, 
              expires: DateTime.Now.AddMinutes(1440),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool ValidateJSONWebToken(string token, IConfiguration _config)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                // lay securityKey từ appsetting json
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
               // check token
                ClaimsPrincipal claims = handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Issuer"],
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);
            }catch(Exception)
            {
                return false;
            }
            return true;
        }
        public static SigningCredentials GetCredentials(IConfiguration _config)
        {
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }
        public static ClaimsPrincipal getClaims(string token,IConfiguration _config)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                // lay securityKey từ appsetting json
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                // check token
                ClaimsPrincipal claims = handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Issuer"],
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);
                return claims;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
