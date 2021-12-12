using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Model
{
    public class Item
    {   [Key] 
        public int Id { get; set; }
        public string Name {get; set;}
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ManufacturingDate { get; set; }

        public DateTime ExpirtDate { get; set; }
        public string Status { get; set; }
    }
}
