using Microsoft.IdentityModel.Tokens;
using PT2.data.API;
using PT2.logic.API;

namespace PT2.Presentation
{
    public partial class CatalogForm : Form
    {
        private readonly CatalogViewModel _viewModel;

        public CatalogForm(ICatalogService catalogService, IEventHistoryService eventHistoryService)
        {
            InitializeComponent();
            _viewModel = new CatalogViewModel(catalogService, eventHistoryService);
            _viewModel.ItemsChanged += ViewModel_ItemsChanged;

            // Add columns to grid
            dataGridViewItems.AutoGenerateColumns = true;
            LoadCatalog();
        }

        private void LoadCatalog()
        {
            if (_viewModel.Items != null)
            {
                var items = _viewModel.Items.Select(i => new
                {
                    i.Id,
                    i.Name,
                    i.Description,
                    i.Price
                }).ToList();

                if (dataGridViewItems.InvokeRequired)
                {
                    dataGridViewItems.Invoke(() => dataGridViewItems.DataSource = items);
                }
                else
                {
                    dataGridViewItems.DataSource = items;
                }
            }
        }

        private void ViewModel_ItemsChanged(object sender, EventArgs e)
        {
            LoadCatalog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBoxId.Text);
                string name = textBoxName.Text;
                string description = textBoxDescription.Text;
                float price = float.Parse(textBoxPrice.Text);

                _viewModel.AddItem(id, name, description, price);
                ClearInputs();
                MessageBox.Show("Item added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n{ex.InnerException?.Message}");            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            { 
                if (dataGridViewItems.CurrentRow == null)
                {
                    MessageBox.Show("Please select an item to remove.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedItem = dataGridViewItems.CurrentRow.DataBoundItem;
                var itemId = (int)dataGridViewItems.CurrentRow.Cells["Id"].Value;

                if (MessageBox.Show("Are you sure you want to remove this item?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _viewModel.RemoveItem(itemId);
                    ClearInputs();
                    MessageBox.Show("Item removed successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n{ex.InnerException?.Message}");            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_viewModel.Items == null || _viewModel.Items.Count == 0)
                {
                    MessageBox.Show("Nothing to update.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataGridViewItems.CurrentRow == null)
                {
                    MessageBox.Show("Please select an item to update.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBoxName.Text == "" && textBoxDescription.Text == "" && textBoxPrice.Text == "")
                {
                    MessageBox.Show("Please enter at least 1 new item value to update.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedItem = dataGridViewItems.CurrentRow.DataBoundItem;
                var itemId = (int)dataGridViewItems.CurrentRow.Cells["Id"].Value;

                //values from text fields
                string name = "";
                string description = "";
                float price = 0;

                //getting old item values
                IItem item = _viewModel.Items.First(i => itemId == i.Id);

                if (item != null)
                {
                    name = item.Name;
                    description = item.Description;
                    price = item.Price;
                }
                else
                {
                    throw new Exception("Item for update doesn't exist - but is on list");
                }

                //getting values from text fields if not empty
                if (textBoxName.Text != "")
                    name = textBoxName.Text;

                if (textBoxDescription.Text != "")
                    description = textBoxDescription.Text;

                if (textBoxPrice.Text != "")
                    price = float.Parse(textBoxPrice.Text);


                _viewModel.UpdateItem(itemId, name, description, price);
                ClearInputs();
                MessageBox.Show("Item updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n{ex.InnerException?.Message}");            }
        }

        private void ClearInputs()
        {
            textBoxId.Clear();
            textBoxName.Clear();
            textBoxDescription.Clear();
            textBoxPrice.Clear();
        }
    }
}