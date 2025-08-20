﻿using backend_aluno.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace backend_aluno.Services.Senha
{
    public class SenhaService : ISenhaInterface
    {
            private readonly IConfiguration _config;
            public SenhaService(IConfiguration config)
            {
                _config = config;
            }
            public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
            {
                using (var hmac = new HMACSHA512())
                {
                    senhaSalt = hmac.Key;
                    senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                }
            }

            public string CriarToken(AlunoModel aluno)
            {
                List<Claim> claims = new List<Claim>()
            {
                new Claim ("Email", aluno.Email),
                new Claim ("UserName", aluno.Usuario),
                new Claim ("UserId", aluno.Id.ToString())
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(

                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                    );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }


            public bool VerificaSenhaHash(string senha, byte[] senhaHash, byte[] SenhaSalt)
            {
                using (var hmac = new HMACSHA3_512(SenhaSalt))
                {
                    var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                    return computerHash.SequenceEqual(senhaHash);
                }
            }
        
    }
}
