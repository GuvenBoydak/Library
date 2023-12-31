﻿using System.Text.Json.Serialization;

namespace Library.MvcUi.Models.User;

public class UserModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    [JsonIgnore]
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
        set
        {
            FullName = value;
        }
    }
}