﻿using System.Text.Json.Serialization;

namespace NovaAPI.Entities.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [JsonIgnore]
        public ICollection<Order> Order { get; set; }
    }
}