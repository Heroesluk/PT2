// UserPanelForm.Designer.cs
namespace Presentation;

partial class UserPanelForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView dataGridViewAvailable;
    private System.Windows.Forms.DataGridView dataGridViewPurchased;
    private System.Windows.Forms.Label labelAvailable;
    private System.Windows.Forms.Label labelPurchased;
    private System.Windows.Forms.TextBox textBoxDescription;
    private System.Windows.Forms.TextBox textBoxQuantity;

    private void InitializeComponent()
    {
        this.textBoxDescription = new System.Windows.Forms.TextBox();
        this.textBoxQuantity = new System.Windows.Forms.TextBox();

        this.SuspendLayout();

        this.textBoxDescription.Location = new System.Drawing.Point(610, 100);
        this.textBoxDescription.Multiline = true;
        this.textBoxDescription.Name = "textBoxDescription";
        this.textBoxDescription.ReadOnly = true;
        this.textBoxDescription.Size = new System.Drawing.Size(150, 100);
        this.textBoxDescription.TabIndex = 1;
        this.textBoxDescription.BackColor = System.Drawing.Color.LightGray;

        this.textBoxQuantity.Location = new System.Drawing.Point(610, 200);
        this.textBoxQuantity.Multiline = true;
        this.textBoxQuantity.Name = "textBoxDescription";
        this.textBoxQuantity.ReadOnly = true;
        this.textBoxQuantity.Size = new System.Drawing.Size(150, 100);
        this.textBoxQuantity.TabIndex = 1;
        this.textBoxQuantity.BackColor = System.Drawing.Color.Cornsilk;
        
        this.Controls.Add(this.textBoxQuantity);
        this.Controls.Add(this.textBoxDescription);

        this.ResumeLayout(false);
        this.PerformLayout();
        
        
        this.dataGridViewAvailable = new System.Windows.Forms.DataGridView();
        this.dataGridViewPurchased = new System.Windows.Forms.DataGridView();
        this.labelAvailable = new System.Windows.Forms.Label();
        this.labelPurchased = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailable)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchased)).BeginInit();
        this.SuspendLayout();

        // labelAvailable
        this.labelAvailable.AutoSize = true;
        this.labelAvailable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.labelAvailable.Location = new System.Drawing.Point(12, 9);
        this.labelAvailable.Text = "Available Items";

        // dataGridViewAvailable
        this.dataGridViewAvailable.Location = new System.Drawing.Point(12, 40);
        this.dataGridViewAvailable.Size = new System.Drawing.Size(600, 200);
        this.dataGridViewAvailable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // labelPurchased
        this.labelPurchased.AutoSize = true;
        this.labelPurchased.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.labelPurchased.Location = new System.Drawing.Point(12, 250);
        this.labelPurchased.Text = "Purchased Items";

        // dataGridViewPurchased
        this.dataGridViewPurchased.Location = new System.Drawing.Point(12, 280);
        this.dataGridViewPurchased.Size = new System.Drawing.Size(600, 150);
        this.dataGridViewPurchased.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Form
        this.ClientSize = new System.Drawing.Size(624, 441);
        this.Controls.Add(this.labelAvailable);
        this.Controls.Add(this.dataGridViewAvailable);
        this.Controls.Add(this.labelPurchased);
        this.Controls.Add(this.dataGridViewPurchased);
        this.Text = "User Panel";
        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailable)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchased)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}