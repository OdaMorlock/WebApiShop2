using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopApi2.Models
{
    public partial class TagList
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int ProdutId { get; set; }

        public virtual Product Produt { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
