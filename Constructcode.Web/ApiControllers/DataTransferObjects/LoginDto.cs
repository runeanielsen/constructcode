﻿namespace Constructcode.Web.ApiControllers.DataTransferObjects
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}