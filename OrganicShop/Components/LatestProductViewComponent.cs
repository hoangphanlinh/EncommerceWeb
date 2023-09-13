using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;

namespace OrganicShop.Components
{
    public class LatestProductViewComponent : ViewComponent
    {
        private readonly IProductServices _productServices;
        public LatestProductViewComponent(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public IViewComponentResult Invoke()
        {
            var result = _productServices.LatestProducts().TakeLast(3).ToList();
            return View(result);
        }
    }
}
