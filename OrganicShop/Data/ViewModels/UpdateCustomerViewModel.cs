namespace OrganicShop.Data.ViewModels
{
    public class UpdateCustomerViewModel
    {
        public int CustomerID { get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool Active { get; set; }

    }
}
