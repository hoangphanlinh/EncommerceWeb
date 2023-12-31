﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        [DisplayName("Name")]
        public string RoleName { get; set; } = string.Empty;
        [DisplayName("Description")]
        public string RoleDescription { get; set; } = string.Empty;
    }
}
