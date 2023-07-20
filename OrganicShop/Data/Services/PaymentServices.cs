using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly AppDBContext _context;
        public PaymentServices(AppDBContext context)
        {
            _context = context;
        }
        public List<SelectListItem> GetAllowed()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "1", Text = "Active" },
                new SelectListItem { Value = "0", Text = "Disable" }
            };
            return Status;
        }

        public IOrderedQueryable<Payments> GetAllPayments()
        {
            var result = _context.Payments.AsNoTracking().OrderByDescending(x => x.PaymentID);
            return result;
        }
    }
}
