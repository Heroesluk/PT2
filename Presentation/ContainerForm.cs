using PT2.Presentation;

namespace Presentation;

// ContainerForm.cs
internal class ContainerForm : Form
{
    private readonly CatalogForm _catalogForm;
    private readonly UserPanelForm _userPanelForm;
    private TabControl tabControl;

    public ContainerForm(CatalogForm catalogForm, UserPanelForm userPanelForm)
    {
        _catalogForm = catalogForm;
        _userPanelForm = userPanelForm;
        InitializeComponent();
        SetupTabs();
    }

    private void InitializeComponent()
    {
        this.tabControl = new TabControl();
        this.SuspendLayout();

        // TabControl
        this.tabControl.Dock = DockStyle.Fill;
        this.tabControl.Location = new Point(0, 0);
        this.tabControl.Name = "tabControl";
        this.tabControl.SelectedIndex = 0;

        // ContainerForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.tabControl);
        this.Name = "ContainerForm";
        this.Text = "Shop Management System";
        this.ResumeLayout(false);
    }

    private void SetupTabs()
    {
        // Admin Tab
        var adminTab = new TabPage("Admin Panel");
        _catalogForm.TopLevel = false;
        _catalogForm.FormBorderStyle = FormBorderStyle.None;
        _catalogForm.Dock = DockStyle.Fill;
        adminTab.Controls.Add(_catalogForm);
        _catalogForm.Show();

        // User Tab
        var userTab = new TabPage("User Panel");
        _userPanelForm.TopLevel = false;
        _userPanelForm.FormBorderStyle = FormBorderStyle.None;
        _userPanelForm.Dock = DockStyle.Fill;
        userTab.Controls.Add(_userPanelForm);
        _userPanelForm.Show();

        // Add tabs
        tabControl.TabPages.Add(adminTab);
        tabControl.TabPages.Add(userTab);
    }
}