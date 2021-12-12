using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopBridge.Bussiness.Interface;
using ShopBridge.Controllers;
using ShopBridge.DAL;
using ShopBridge.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridgeMSTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IItemService _itemService;
        private readonly SaveItem _saveItem;
        InventoryController inventoryController;
        private Mock<IItemService> _actionProcess;

        [TestInitialize]
        public void Init()
        {
            //  _itemService = new ItemService(_saveItem);
            // inventoryController = new InventoryController(_logger, _itemService);
            _actionProcess = new Mock<IItemService>();
            inventoryController = new InventoryController(_logger, _actionProcess.Object);
        }

        [TestMethod]
        public void GetTestMethod()
        {
            Item item = new Item()
            {
                Name = "Coffee",
                Description = "Break Drink",
                Price = 21,
                ExpirtDate = System.DateTime.Now,
                ManufacturingDate = System.DateTime.Now,
                Status = "Active"
            };
            _actionProcess.Setup(x => x.GetItem(1)).Returns(Task.FromResult<List<Item>>(new List<Item> { item }));
            var response = inventoryController.GetItem(1).Result;
            Assert.IsNotNull(response);
            //   Assert.AreEqual(200, response);
        }

        [TestMethod]
        public void DeleteTestMethod()
        {

            _actionProcess.Setup(x => x.DeleteItem(It.IsAny<int>())).Returns(Task.FromResult<string>("Item Deleted"));
            var response = inventoryController.DeleteItem(1).Result;
            Assert.IsNotNull(response);
            //   Assert.AreEqual(200, response);
        }
     
    }
}
