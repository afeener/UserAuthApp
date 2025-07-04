﻿namespace UserAuthApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; } = null;
        public string? Password { get; set; } = null;

        public void SetPassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}
