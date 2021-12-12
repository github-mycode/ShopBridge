using ShopBridge.Bussiness.Interface;
using ShopBridge.DAL;
using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Bussiness
{
    public class ItemService : IItemService
    {
        public SaveItem _saveItem;
        public ItemService(SaveItem saveItem)
        {
            _saveItem = saveItem;
        }
        public async Task AddItem(Item product)
        {
            _saveItem.AddItem(product);
        }

        public async Task<List<Item>> GetItem(int? id)
        {
            try
            {
               return await _saveItem.GetItem(id);
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
                return await _saveItem.UpdateItem(product);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
                return ex.Message;
            }
        }
        public async Task<string> DeleteItem(int id) {
            try
            {
               return await _saveItem.DeleteItem(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
                return ex.Message;
            }
        }
    }
}
