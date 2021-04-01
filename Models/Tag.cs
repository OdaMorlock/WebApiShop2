using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopApi2.Models
{
    public partial class Tag
    {
        public Tag()
        {
            TagLists = new HashSet<TagList>();
        }

        public int Id { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<TagList> TagLists { get; set; }
    }
}
