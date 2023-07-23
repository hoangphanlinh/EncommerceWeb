using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.ViewModels;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly AppDBContext _context;
        public CustomerServices(AppDBContext context) 
        {  
            _context = context; 
        }
        public IOrderedQueryable<Customers> GetAllCustomer()
        {
            var result = _context.Customers.Include(x=>x.ward).Include(x=>x.city).Include(x=>x.district).AsNoTracking().OrderByDescending(x => x.CustomerID);
            return result;
        }
        public void Edit(UpdateCustomerViewModel customers)
        {
            var model = getCustomerById(customers.CustomerID);
           if(model !=null)
            {
                model.CustomerID = customers.CustomerID;
                model.FullName = customers.FullName;
                model.BirthDay = customers.BirthDay;
                model.Address = customers.Address;
                model.Email = customers.Email;
                model.Phone = customers.Phone;
                model.Active = customers.Active;    

            }
           _context.SaveChanges();
        }

        public IOrderedQueryable<Customers> SearchCustomer(string? searchString, string? status)
        {
            var result = from customer in _context.Customers select customer;
            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(x=> x.FullName.Contains(searchString) || x.Phone.Contains(searchString));
            }
            if(status == "True")
            {
                result = result.Where(x => x.Active == true);
            }
            if(status == "False")
            {
                result = result.Where(x => x.Active == false);

            }
            return (IOrderedQueryable<Customers>)result;

        }

        public List<SelectListItem> GetStatus()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "True", Text = "Active" },
                new SelectListItem { Value = "False", Text = "Block" }
            };
            return Status;
        }

        public Customers Details(int id)
        {
            var result = _context.Customers.Include(x => x.ward).Include(x => x.city).Include(x => x.district).FirstOrDefault(x=>x.CustomerID == id);
            if(result == null)
            {
                return NotFound();
            }
            return result;
        }

        private Customers NotFound()
        {
            throw new NotImplementedException();
        }

        public List<City> GetCity()
        {
            return _context.City.OrderBy(x=>x.cityName).ToList();
        }

        public Customers getCustomerById(int id)
        {
           var result = _context.Customers.FirstOrDefault(x => x.CustomerID == id);
           return result == null ? NotFound() : result;
        }

        public IOrderedQueryable<Customers> FilterCustomers(string? searchString, string? status,int city, int district, int ward)
        {
            var result = from customer in _context.Customers select customer;
            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Include(x=>x.city).Include(y=>y.district).Include(z=>z.ward).Where(x => x.FullName.Contains(searchString) || x.Phone.Contains(searchString));
            }
            if (status == "True")
            {
                result = result.Include(x => x.city).Include(y => y.district).Include(z => z.ward).Where(x => x.Active == true);
            }
            if (status == "False")
            {
                result = result.Include(x => x.city).Include(y => y.district).Include(z => z.ward).Where(x => x.Active == false);

            }
            if(city > 0)
            {
                result = result.Include(x => x.city).Include(y => y.district).Include(z => z.ward).Where(x => x.City == city);

            }
            if(city>0 && district > 0)
            {
                result = result.Include(x => x.city).Include(y => y.district).Include(z => z.ward).Where(x => x.City ==city && x.District == district);

            }
            if(city>0 && district> 0 && ward > 0)
            {
                result = result.Include(x => x.city).Include(y => y.district).Include(z => z.ward).Where(x => x.City == city && x.District == district && x.Ward == ward);

            }
            return (IOrderedQueryable<Customers>)result;
        }

        public List<District> GetDistrict(int cityId)
        {
            return _context.District.Where(x=>x.CityId == cityId).OrderBy(x=>x.DistrictName).ToList();
        }

        public List<Ward> GetWard(int districtId)
        {
            return _context.Ward.Where(x=>x.DistrictId==districtId).OrderBy(x=>x.WardName).ToList();
        }
    }
}
