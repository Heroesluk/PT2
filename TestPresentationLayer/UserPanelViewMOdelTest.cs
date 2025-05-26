using Moq;
using Presentation;
using PT2.data.API;
using PT2.logic.API;

[TestClass]
public class UserPanelViewModelTests
{
    private Mock<ICatalogService> _mockCatalogService;
    private Mock<IEventHistoryService> _mockEventHistoryService;
    private Mock<IInventoryService> _mockInventoryService;
    private UserPanelViewModel _viewModel;

    [TestInitialize]
    public void Setup()
    {
        _mockCatalogService = new Mock<ICatalogService>();
        _mockEventHistoryService = new Mock<IEventHistoryService>();
        _mockInventoryService = new Mock<IInventoryService>();

        _mockCatalogService.Setup(s => s.GetAllItems()).Returns(new List<IItem>());

        _viewModel = new UserPanelViewModel(
            _mockCatalogService.Object,
            _mockEventHistoryService.Object,
            _mockInventoryService.Object
        );
    }

    [TestMethod]
    public void RefreshItems_ShouldPopulateAvailableItems()
    {
        var items = new List<IItem>
        {
            new Mock<IItem>().Object
        };

        _mockCatalogService.Setup(s => s.GetAllItems()).Returns(items);
        _mockInventoryService.Setup(s => s.GetItemStock(It.IsAny<int>())).Returns(10);

        _viewModel.RefreshItems();

        Assert.AreEqual(1, _viewModel.AvailableItems.Count);
    }

    [TestMethod]
    public void BuyItem_ShouldThrowException_WhenStockIsInsufficient()
    {
        _mockInventoryService.Setup(s => s.GetItemStock(It.IsAny<int>())).Returns(0);

        Assert.ThrowsException<InvalidOperationException>(() => _viewModel.BuyItem(1, 1));
    }
}
