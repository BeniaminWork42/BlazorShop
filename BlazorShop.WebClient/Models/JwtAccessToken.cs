﻿namespace BlazorShop.WebClient.Models
{
    public class JwtAccessToken
    {
        public string? Access_Token { get; set; }
        public string? Type => "Bearer";

        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}
