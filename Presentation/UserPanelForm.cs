// UserPanelForm.cs

using PT2.logic.API;

namespace Presentation;

public partial class UserPanelForm : Form
{
    private readonly UserPanelViewModel _viewModel;
    private List<PurchasedItem> _purchasedItems;

    public UserPanelForm(IInventoryService inventoryService, ICatalogService catalogService)
    {
        InitializeComponent();
        _viewModel = new UserPanelViewModel(inventoryService, catalogService);
        _viewModel.ItemsChanged += ViewModel_ItemsChanged;
        _purchasedItems = new List<PurchasedItem>();
        SetupDataGrids();
        LoadInventory();
        EventService.CatalogChanged += (s, e) => _viewModel.RefreshItems();

    }

    private void SetupDataGrids()
    {
        // Available items grid
        dataGridViewAvailable.AutoGenerateColumns = true;
        dataGridViewAvailable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        var buyColumn = new DataGridViewButtonColumn
        {
            Text = "Buy",
            UseColumnTextForButtonValue = true,
            Name = "BuyColumn",
            HeaderText = "Action"
        };
        dataGridViewAvailable.Columns.Add(buyColumn);
        dataGridViewAvailable.CellClick += DataGridViewAvailable_CellClick;

        // Purchased items grid
        dataGridViewPurchased.AutoGenerateColumns = true;
    }

    private void DataGridViewAvailable_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        if (e.ColumnIndex == dataGridViewAvailable.Columns["BuyColumn"].Index)
        {
            var row = dataGridViewAvailable.Rows[e.RowIndex];
            int itemId = (int)row.Cells["ItemId"].Value;
            string name = (string)row.Cells["Name"].Value;
            float price = (float)row.Cells["Price"].Value;

            try
            {
                _viewModel.BuyItem(itemId, 1);
            
                // Find existing purchased item or create new one
                var existingItem = _purchasedItems.FirstOrDefault(p => p.ItemId == itemId);
                if (existingItem != null)
                {
                    // Create new item with updated quantity because PurchasedItem is immutable
                    _purchasedItems.Remove(existingItem);
                    _purchasedItems.Add(new PurchasedItem(itemId, name, price, existingItem.Quantity + 1));
                }
                else
                {
                    _purchasedItems.Add(new PurchasedItem(itemId, name, price, 1));
                }
            
                UpdatePurchasedItemsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    private void LoadInventory()
    {
        if (_viewModel.AvailableItems != null)
        {
            if (dataGridViewAvailable.InvokeRequired)
            {
                dataGridViewAvailable.Invoke(() => dataGridViewAvailable.DataSource = _viewModel.AvailableItems);
            }
            else
            {
                dataGridViewAvailable.DataSource = _viewModel.AvailableItems;
            }
        }
    }

    private void UpdatePurchasedItemsGrid()
    {
        dataGridViewPurchased.DataSource = null;
        dataGridViewPurchased.DataSource = _purchasedItems;
    }

    private void ViewModel_ItemsChanged(object sender, EventArgs e)
    {
        LoadInventory();
    }
}