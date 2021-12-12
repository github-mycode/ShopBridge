using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridge.Bussiness.Interface;
using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IItemService _itemService;
        public InventoryController(ILogger<InventoryController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;

        }
        [HttpGet]
        public async Task<List<Item>> GetItem(int? id)
        {
            List<Item> item;
           

                 item = await _itemService.GetItem(id);
            return item;
        }
        
        [HttpDelete]
        public async Task<string> DeleteItem(int id)
        {
            Console.WriteLine(id);
            string item = await _itemService.DeleteItem(id);

            return item;
        }
        [HttpPost]
        public async Task  AddItem([FromBody] Item product)
        {
            if (ModelState.IsValid)
            {
                _itemService.AddItem(product);
            }
            
        }
        [HttpPut]
        public async Task<string> UpdateItem([FromBody] Item product)
        {
            if (ModelState.IsValid)
            {
               return await _itemService.UpdateItem(product);
            }
            return "Invalid Model State";
        }

    }
}
