﻿using System.Security.Cryptography;
using System.Text;

namespace API_ProcessJudicial.Infra.CrossCutting
{
    public class CreateHash
    {
        public static string CreateHashMd5(string password)
        {
            MD5 md5Hash = MD5.Create();
            
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
          
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
