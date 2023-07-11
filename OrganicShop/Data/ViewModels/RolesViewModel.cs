using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Data.ViewModels
{
    public class RolesViewModel
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; } = string.Empty;
        [Required]
        public string RoleDescription { get; set; } = string.Empty;
    }
}
