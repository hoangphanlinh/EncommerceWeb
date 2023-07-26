namespace OrganicShop.Data.ViewModels
{
    public class PaymentViewModel
    {
        public class UpdatePaymentViewModel
        {
            public int PaymentID { get; set; }
            public string? Type { get; set; }
            public bool Allowed { get; set; }
        }
       
    }
}
