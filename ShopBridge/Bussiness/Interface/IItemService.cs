using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Bussiness.Interface
{
    public interface IItemService
    {
          Task AddItem(Item product);
          Task<List<Item>> GetItem(int? id);
          Task<string> UpdateItem(Item product);
          Task<string> DeleteItem(int Id);
    }
}
