using Business.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business
{
    public class UserBLL : IUser
    {
        public User Login(string userName, string passWord)
        {
            List<User> userList = new List<User>()
            {
                new User(),
                new User("ASD","asd"),
                new User("ZXC","1241"),
                new User("hpjjphhpj","131415161718","Admin"),
            };

            var user = userList.Find(ele => ele.UserId == userName && ele.Password == passWord);

            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                    new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"),
                    new Claim(ClaimTypes.Name, userName)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConstParam.SecurityKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: ConstParam.Domain,
                    audience: ConstParam.Domain,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                user.Token = new JwtSecurityTokenHandler().WriteToken(token);
                user.Password = "Protected";
            }

            return user;
        }
    }
}
