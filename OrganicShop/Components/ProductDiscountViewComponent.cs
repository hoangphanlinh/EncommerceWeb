using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;

namespace OrganicShop.Components
{
    public class ProductDiscountViewComponent : ViewComponent
    {
        private readonly IProductServices _productServices;
        public ProductDiscountViewComponent(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public IViewComponentResult Invoke() {
            var result = _productServices.ListProductDiscount().ToList().Take(8);
            return View(result); 
        }

    }
}
