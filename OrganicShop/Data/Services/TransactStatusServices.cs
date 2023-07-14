using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class TransactStatusServices : ITransactStatusServices
    {
        private readonly AppDBContext _context;
        public TransactStatusServices(AppDBContext context)
        {
            _context = context;
        }
        public List<TransactStatus> GetAllTransactStatuses()
        {
            var result = _context.TransactStatus.AsNoTracking().OrderByDescending(x=>x.TransactStatusID).ToList();
            return result;
        }
    }
}
