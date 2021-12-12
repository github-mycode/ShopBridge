using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopBridge;
using ShopBridge.Bussiness;
using ShopBridge.Bussiness.Interface;
using ShopBridge.Controllers;
using ShopBridge.DAL;
using System.Threading.Tasks;

namespace ShopBridgeTest
{
    [TestClass]
    public class Tests
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
            inventoryController = new InventoryController(_logger, _itemService);
            _actionProcess = new Mock<IItemService>();
        }

       
        [TestMethod]
        public void TestGetActionsReturnsOk()
        {

            _actionProcess.Setup(x => x.DeleteItem(It.IsAny<int>())).Returns(Task.FromResult<string>("Item Deleted"));
            var response= inventoryController.DeleteItem(1).Result;
            Assert.IsNotNull(response);
         //   Assert.AreEqual(200, response);
        }
    }
}