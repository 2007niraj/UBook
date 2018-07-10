using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UBook.Models
{
    public class WishlistItem
    {

        public Guid ? Id { get; set; }

        public string  Name { get; set; }

       // public string Type { get { return "WishlistItem"; }}

        public string Type => typeof(WishlistItem).Name;
    }
}