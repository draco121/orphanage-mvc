﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrphanageMVC.Common
{
    public class Password
    {
        public string Encode(string password)
        {
            try
            {
                byte[] EncDataByte = new byte[password.Length];
                EncDataByte = System.Text.Encoding.UTF32.GetBytes(password);
                string EncryptedData = Convert.ToBase64String(EncDataByte);
                return EncryptedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Encode" + ex.Message);
            }
        }
    }
}