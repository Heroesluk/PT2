using Presentation;
using PT2.logic;
using PT2.Presentation;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        try
        {
            var catalogService = LogicServiceFactory.CreateCatalogService();
            var inventoryService = LogicServiceFactory.CreateInventoryService();
            var eventHistoryService = LogicServiceFactory.CreateEventHistoryService();

            var mainForm = new CatalogForm(catalogService,eventHistoryService);
            var userPanel = new UserPanelForm(inventoryService, catalogService,eventHistoryService);
            
            Application.Run(new ContainerForm(mainForm, userPanel));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}\n{ex.InnerException?.Message}");
            MessageBox.Show($"Application Error: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}