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

            var mainForm = new CatalogForm(catalogService);
            var userPanel = new UserPanelForm(inventoryService, catalogService);
            
            Application.Run(new ContainerForm(mainForm, userPanel));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Application Error: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}