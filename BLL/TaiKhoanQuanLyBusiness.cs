using DAL.Repository.Interfaces;
using MODEL;
using System;
using System.Collections.Generic;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;


namespace BLL
{
    public class TaiKhoanQuanLyBusiness : ITaiKhoanQuanLyBusiness
    {
        private ITaiKhoanQuanLyRepository _res;
        public TaiKhoanQuanLyBusiness(ITaiKhoanQuanLyRepository res)
        {
            _res = res;
        }


        public bool Create(TaiKhoanQuanLy model)
        {
            return _res.Create(model);
        }

        public bool Delete(string userName)
        {
            return _res.Delete(userName);
        }

        public TaiKhoanQuanLy Login(string userName, string password)
        {
            var user = _res.Login(userName, password);
            //if (user == null)
            //    return null;
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.userName, user.userName.ToString()),
            //        new Claim(ClaimTypes.Email, user.Email)
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //user.token = tokenHandler.WriteToken(token);
            return user;
        }

        public bool Update(TaiKhoanQuanLy model)
        {
            return _res.Create(model);
        }

       
    }
}
