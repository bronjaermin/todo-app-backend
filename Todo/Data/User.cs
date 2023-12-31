﻿namespace Todo.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Item> Items { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}
