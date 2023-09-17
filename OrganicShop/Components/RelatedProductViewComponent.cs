using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;

namespace OrganicShop.Components
{
    public class RelatedProductViewComponent : ViewComponent
    {
        private readonly IProductServices _productServices;
        public RelatedProductViewComponent(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public IViewComponentResult Invoke(int id)
        {
            var result = _productServices.RelatedProduct(id).TakeLast(3).ToList();
            return View(result);
        }
    }
}
