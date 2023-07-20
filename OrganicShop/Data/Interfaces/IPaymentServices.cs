using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface IPaymentServices
    {
        IOrderedQueryable<Payments> GetAllPayments();
        List<SelectListItem> GetAllowed();

    }
}
