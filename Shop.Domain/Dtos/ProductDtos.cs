using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos
{
    public class ProductDtos
    {
        public int Id { set; get; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string MoreImage { get; set; }

        public bool? Status { get; set; }

        public bool? HomeFlag { get; set; }
        public decimal? Price { get; set; }

        public int? Quatity { get; set; }

        public int? CategoryID { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warranty { get; set; }

        public string MetaDescriptions { get; set; }

        public string MetaKeywords { get; set; }
    }
}
