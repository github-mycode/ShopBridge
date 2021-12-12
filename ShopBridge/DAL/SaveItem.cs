using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.DAL
{
    public class SaveItem
    {
        public readonly CoreDbContext _context;
        public SaveItem(CoreDbContext context)
        {
            _context = context;
        }
        public  async Task AddItem(Item item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }
        public async Task<List<Item>> GetItem(int? id)
        {
            try
            {
                List<Item> item = new List<Item>();
                if (id != null)
                {

                    Item item1 =  _context.item.Find(id);
                    item.Add(item1);
                }
                else
                {
                    item = _context.Set<Item>().ToList();
                }
                return item;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
                throw;
            }
        }
        public async Task<string> UpdateItem(Item product)
        {
            try
            {

                var item1 =_context.item.Find(product.Id);
                if(item1 == null)
                {
                    return $"Product with ID {product.Id} is not found";    
                }
                else
                {
                    item1.Name = product.Name;
                    item1.Description=product.Description;
                    item1.ExpirtDate =product.ExpirtDate;
                    item1.ManufacturingDate=product.ManufacturingDate;
                    item1.Price = product.Price;
                    item1.Status = product.Status;
                   // _context.Update(item1);
                    _context.SaveChanges();

                    return $"Product with ID {product.Id} is  found";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
                return $"Product with ID {product.Id} is not found";
            }
        }
        public async Task<string> DeleteItem(int ID)
        {
            var item=_context.item.Find(ID);
            if (item != null)
            {
                 _context.item.Remove(item);
                 _context.SaveChanges();
                return $"Item is deleted successfully id deleted {ID}";
            }
            return $"Item not found for ID {ID}";
        }
    }
}
