using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;
using static OrganicShop.Data.ViewModels.PaymentViewModel;

namespace OrganicShop.Data.Interfaces
{
    public interface IPaymentServices
    {
        IOrderedQueryable<Payments> GetAllPayments();
        List<SelectListItem> GetAllowed();
        void Create(Payments payments);

        void Update(UpdatePaymentViewModel payments);
        void Delete(int id);
        Payments GetById(int id);
    }
}
