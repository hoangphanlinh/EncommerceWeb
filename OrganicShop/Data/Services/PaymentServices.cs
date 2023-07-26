using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;
using static OrganicShop.Data.ViewModels.PaymentViewModel;

namespace OrganicShop.Data.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly AppDBContext _context;
        public PaymentServices(AppDBContext context)
        {
            _context = context;
        }

        public void Create(Payments payments)
        {
            _context.Payments.Add(payments);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = GetById(id);
            _context.Payments.Remove(model);
            _context.SaveChanges();
        }

        public List<SelectListItem> GetAllowed()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "True", Text = "Active" },
                new SelectListItem { Value = "False", Text = "Disable" }
            };
            return Status;
        }

        public IOrderedQueryable<Payments> GetAllPayments()
        {
            var result = _context.Payments.AsNoTracking().OrderByDescending(x => x.PaymentID);
            return result;
        }

        public Payments GetById(int id)
        {
            var model = _context.Payments.FirstOrDefault(x => x.PaymentID == id);
            if(model == null)
            {
                throw new NotImplementedException();

            }
            return model;
        }

        public void Update(UpdatePaymentViewModel payments)
        {
            var model = GetById(payments.PaymentID);
            if(model != null)
            {
                model.PaymentID = payments.PaymentID;
                model.Type = payments.Type;
                model.Allowed= payments.Allowed;
            }
            _context.SaveChanges();
        }
    }
}
