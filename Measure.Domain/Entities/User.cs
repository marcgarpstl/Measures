﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTimeOffset Created { get; set; }

        public MaleMeasures? Male { get; set; } = new MaleMeasures();
        public FemaleMeasures? Female { get; set; } = new FemaleMeasures();

        public User(string firstName, string lastName, string email, string password, string userName)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserName = userName;
            Created = DateTimeOffset.UtcNow;
        }
    }
}
