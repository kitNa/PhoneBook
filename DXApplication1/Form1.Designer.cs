
namespace DXApplication1
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.PhoneBookControl = new DevExpress.XtraGrid.GridControl();
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.autoHideContainer2 = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedList = new System.Windows.Forms.CheckedListBox();
            this.toolStrip_Change = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редагуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoHideContainer1 = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.ContactList = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneBookControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.autoHideContainer2.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContactList)).BeginInit();
            this.SuspendLayout();
            // 
            // PhoneBookControl
            // 
            this.PhoneBookControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhoneBookControl.EmbeddedNavigator.Cursor = System.Windows.Forms.Cursors.Default;
            gridLevelNode1.RelationName = "Level1";
            this.PhoneBookControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.PhoneBookControl.Location = new System.Drawing.Point(28, 30);
            this.PhoneBookControl.LookAndFeel.SkinName = "Office 2010 Blue";
            this.PhoneBookControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.PhoneBookControl.MainView = this.ContactList;
            this.PhoneBookControl.Name = "PhoneBookControl";
            this.PhoneBookControl.Size = new System.Drawing.Size(527, 479);
            this.PhoneBookControl.TabIndex = 0;
            this.PhoneBookControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ContactList});
            this.PhoneBookControl.Click += new System.EventHandler(this.PhoneBookControl_Click);
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(22, 534);
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.autoHideContainer2});
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // autoHideContainer2
            // 
            this.autoHideContainer2.BackColor = System.Drawing.SystemColors.Control;
            this.autoHideContainer2.Controls.Add(this.dockPanel1);
            this.autoHideContainer2.Dock = System.Windows.Forms.DockStyle.Left;
            this.autoHideContainer2.Location = new System.Drawing.Point(0, 30);
            this.autoHideContainer2.Name = "autoHideContainer2";
            this.autoHideContainer2.Size = new System.Drawing.Size(28, 479);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("34e5d85c-3577-488b-968a-dc386ca24a64");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(157, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(157, 493);
            this.dockPanel1.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Left;
            this.dockPanel1.Text = "Фільтр за оператором телефонного зв\'язку";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.button2);
            this.dockPanel1_Container.Controls.Add(this.button1);
            this.dockPanel1_Container.Controls.Add(this.checkedList);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 28);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(145, 460);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.AliceBlue;
            this.button2.Location = new System.Drawing.Point(28, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 69);
            this.button2.TabIndex = 2;
            this.button2.Text = "Скинути всі фільтри";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Location = new System.Drawing.Point(28, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Примінити";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedList
            // 
            this.checkedList.FormattingEnabled = true;
            this.checkedList.Items.AddRange(new object[] {
            "МТС",
            "Life",
            "Kyivstar"});
            this.checkedList.Location = new System.Drawing.Point(2, 0);
            this.checkedList.Name = "checkedList";
            this.checkedList.Size = new System.Drawing.Size(140, 220);
            this.checkedList.TabIndex = 0;
            // 
            // toolStrip_Change
            // 
            this.toolStrip_Change.Name = "toolStrip_Change";
            this.toolStrip_Change.ShowShortcutKeys = false;
            this.toolStrip_Change.Size = new System.Drawing.Size(145, 24);
            this.toolStrip_Change.Text = "Редагувати";
            this.toolStrip_Change.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStrip_Delete
            // 
            this.toolStrip_Delete.Name = "toolStrip_Delete";
            this.toolStrip_Delete.ShowShortcutKeys = false;
            this.toolStrip_Delete.Size = new System.Drawing.Size(145, 24);
            this.toolStrip_Delete.Text = "Видалити";
            this.toolStrip_Delete.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // ContextMenu
            // 
            this.ContextMenu.AllowMerge = false;
            this.ContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_Change,
            this.toolStrip_Delete});
            this.ContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ContextMenu.Name = "Змінити";
            this.ContextMenu.ShowItemToolTips = false;
            this.ContextMenu.Size = new System.Drawing.Size(146, 52);
            this.ContextMenu.Text = "Змінити";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(555, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редагуватиToolStripMenuItem,
            this.видалитиToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(546, 24);
            this.toolStripMenuItem1.Text = "Внести зміни";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.добавитьToolStripMenuItem.Text = "Додати контакт";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // редагуватиToolStripMenuItem
            // 
            this.редагуватиToolStripMenuItem.Name = "редагуватиToolStripMenuItem";
            this.редагуватиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.редагуватиToolStripMenuItem.Text = "Редагувати контакт";
            this.редагуватиToolStripMenuItem.Click += new System.EventHandler(this.редагуватиToolStripMenuItem_Click);
            // 
            // видалитиToolStripMenuItem
            // 
            this.видалитиToolStripMenuItem.Name = "видалитиToolStripMenuItem";
            this.видалитиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.видалитиToolStripMenuItem.Text = "Видалити контакт";
            this.видалитиToolStripMenuItem.Click += new System.EventHandler(this.видалитиToolStripMenuItem_Click);
            // 
            // autoHideContainer1
            // 
            this.autoHideContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.autoHideContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.autoHideContainer1.Location = new System.Drawing.Point(0, 30);
            this.autoHideContainer1.Name = "autoHideContainer1";
            this.autoHideContainer1.Size = new System.Drawing.Size(22, 504);
            // 
            // ContactList
            // 
            this.ContactList.ActiveFilterEnabled = false;
            this.ContactList.GridControl = this.PhoneBookControl;
            this.ContactList.Name = "ContactList";
            this.ContactList.OptionsBehavior.Editable = false;
            this.ContactList.OptionsCustomization.AllowColumnMoving = false;
            this.ContactList.OptionsFind.AlwaysVisible = true;
            this.ContactList.OptionsFind.FindNullPrompt = "Введіть прізвище чи ім\'я для пошуку";
            this.ContactList.OptionsNavigation.EnterMoveNextColumn = true;
            this.ContactList.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.ContactList.OptionsView.ShowGroupPanel = false;
            this.ContactList.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.ContactList_CustomColumnSort);
            this.ContactList.DoubleClick += new System.EventHandler(this.ContactList_DoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(555, 509);
            this.ContextMenuStrip = this.ContextMenu;
            this.Controls.Add(this.PhoneBookControl);
            this.Controls.Add(this.autoHideContainer2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Телефонна книга";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PhoneBookControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.autoHideContainer2.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.ContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContactList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraGrid.GridControl PhoneBookControl;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        public System.Windows.Forms.ContextMenuStrip ContextMenu;
        public System.Windows.Forms.ToolStripMenuItem toolStrip_Change;
        public System.Windows.Forms.ToolStripMenuItem toolStrip_Delete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редагуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиToolStripMenuItem;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.AutoHideContainer autoHideContainer1;
        private DevExpress.XtraBars.Docking.AutoHideContainer autoHideContainer2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.CheckedListBox checkedList;
        public DevExpress.XtraGrid.Views.Grid.GridView ContactList;
    }
}

