using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;

namespace OrganicShop.Components
{
    public class ProductBestSaleViewComponent : ViewComponent
    {
        private readonly IProductServices _productServices;
        public ProductBestSaleViewComponent(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public IViewComponentResult Invoke()
        {
            var result = _productServices.ListProductBestSale().ToList().Take(8);
            return View(result);
        }
    }
}
