using Moq;
using PT2.logic.API;

namespace TestPresentationLayer;

[TestClass]
public class CatalogViewModelTests
{
    private Mock<ICatalogService> _mockCatalogService;
    private Mock<IEventHistoryService> _mockEventHistoryService;
    private CatalogViewModel _viewModel;

    [TestInitialize]
    public void Setup()
    {
        _mockCatalogService = new Mock<ICatalogService>();
        _mockEventHistoryService = new Mock<IEventHistoryService>();

        _viewModel = new CatalogViewModel(
            _mockCatalogService.Object,
            _mockEventHistoryService.Object
        );
    }

    [TestMethod]
    public void AddItem_ShouldCallCatalogServiceAndRefreshItems()
    {
        _viewModel.AddItem(1, "Item1", "Description1", 10.0f);

        _mockCatalogService.Verify(s => s.AddItemToCatalog(1, "Item1", "Description1", 10.0f), Times.Once);
    }


    [TestMethod]
    public void UpdateItem_ShouldCallCatalogServiceAndRefreshItems()
    {
        _viewModel.UpdateItem(1, "UpdatedName", "UpdatedDescription", 20.0f);

        _mockCatalogService.Verify(s => s.UpdateItemDetails(1, "UpdatedName", "UpdatedDescription", 20.0f), Times.Once);
    }
}
