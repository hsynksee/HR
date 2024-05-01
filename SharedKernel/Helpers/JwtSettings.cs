﻿namespace SharedKernel.Helpers
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int Expires { get; set; }
        public string UploadPath { get; set; }
        public string ReturnDomain { get; set; }
    }
}
