using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UBook.Models
{
    public class ResturantType
    {

        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Type => typeof(ResturantType).Name;
    }
}