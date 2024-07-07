﻿namespace WebKrpcApi.Services.Validator
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryHours { get; set; }
    }
}
