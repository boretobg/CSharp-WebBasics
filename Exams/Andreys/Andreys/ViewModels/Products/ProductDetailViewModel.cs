using Andreys.Data.Models.Enums;

namespace Andreys.ViewModels.Products
{
    public class ProductDetailViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public GenderType Gender { get; set; }

        public CategoryType Category { get; set; }
    }
}
