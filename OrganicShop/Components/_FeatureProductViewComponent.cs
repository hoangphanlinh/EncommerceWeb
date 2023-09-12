using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;

namespace OrganicShop.Components
{
    public class _FeatureProductViewComponent : ViewComponent
    {
        private readonly IProductServices _productServices;
        public _FeatureProductViewComponent(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public IViewComponentResult Invoke(string searchCatName)
        {
            var result = _productServices.SearchProductCatName(searchCatName).ToList();
            return View(result);
        }
    }
}
