// UserPanelForm.cs

using PT2.logic.API;

namespace Presentation;

internal partial class UserPanelForm : Form
{
    private readonly UserPanelViewModel _viewModel;
    private List<PurchasedItem> _purchasedItems;

    public UserPanelForm(IInventoryService inventoryService, ICatalogService catalogService, IEventHistoryService eventHistoryService)
    {
        InitializeComponent();
        _viewModel = new UserPanelViewModel( catalogService, eventHistoryService,inventoryService);
        _viewModel.ItemsChanged += ViewModel_ItemsChanged;
        _purchasedItems = new List<PurchasedItem>();
        SetupDataGrids();
        LoadInventory();
        EventService.CatalogChanged += (s, e) => _viewModel.RefreshItems();

    }
    
    
    private void SetupDataGrids()
    {
        // Available items grid
        dataGridViewAvailable.AutoGenerateColumns = false;
        dataGridViewAvailable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        // Add columns to Master view
        dataGridViewAvailable.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ItemId",
            HeaderText = "ID",
            Name = "ItemId"
        });
        dataGridViewAvailable.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Name",
            HeaderText = "Name",
            Name = "Name"
        });
        dataGridViewAvailable.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Price",
            HeaderText = "Price",
            Name = "Price"
        });
        var buyColumn = new DataGridViewButtonColumn
        {
            Text = "Buy",
            UseColumnTextForButtonValue = true,
            Name = "BuyColumn",
            HeaderText = "Action"
        };
        dataGridViewAvailable.Columns.Add(buyColumn);

        dataGridViewAvailable.CellClick += DataGridViewAvailable_CellClick;
        dataGridViewAvailable.SelectionChanged += DataGridViewAvailable_SelectionChanged;

        // Purchased items grid
        dataGridViewPurchased.AutoGenerateColumns = true;
    }

    private void DataGridViewAvailable_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridViewAvailable.SelectedRows.Count > 0)
        {
            var selectedRow = dataGridViewAvailable.SelectedRows[0];
            int itemId = (int)selectedRow.Cells["ItemId"].Value;

            var selectedItem = _viewModel.AvailableItems.FirstOrDefault(item => item.ItemId == itemId);
            if (selectedItem != null)
            {
                textBoxDescription.Text = selectedItem.Description;
                textBoxQuantity.Text = $"Quantity left: {selectedItem.AvailableQuantity}";
            }
        }
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
                MessageBox.Show($"Error: {ex.Message}\n{ex.InnerException?.Message}");
                // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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