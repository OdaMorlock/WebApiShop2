using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopApi2.Models
{
    public partial class Product
    {
        public Product()
        {
            TagLists = new HashSet<TagList>();
        }

        public int Id { get; set; }
        public int? ColorId { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? SizeId { get; set; }
        public int Price { get; set; }
        public bool OnSale { get; set; }
        public bool InStock { get; set; }
        public string Image { get; set; }

        public string ProductName { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Color Color { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<TagList> TagLists { get; set; }
    }
}
