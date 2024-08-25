﻿using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel.DataAnnotations;

namespace MossadMVC.Models
{
    public class Agent
    {
        [Key]
        public int ID { get; set; }
        public string PhotoUrl { get; set; }
        public string Nickname { get; set; }
        public int? locationID { get; set; }
        public StatusAgent? status { get; set; }
    }
}
