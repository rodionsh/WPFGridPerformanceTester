namespace WFGridPerformanceTester.Views
{
    partial class BasicDXView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bookGridControl = new DevExpress.XtraGrid.GridControl();
            this.bookGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BWork = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Bids = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Asks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWork = new DevExpress.XtraGrid.Columns.GridColumn();
            this.randomizeButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.bookGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bookGridControl
            // 
            this.bookGridControl.Location = new System.Drawing.Point(0, 0);
            this.bookGridControl.MainView = this.bookGridView;
            this.bookGridControl.Name = "bookGridControl";
            this.bookGridControl.Size = new System.Drawing.Size(200, 500);
            this.bookGridControl.TabIndex = 0;
            this.bookGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bookGridView});
            // 
            // bookGridView
            // 
            this.bookGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BWork,
            this.Bids,
            this.Price,
            this.Asks,
            this.AWork});
            this.bookGridView.GridControl = this.bookGridControl;
            this.bookGridView.Name = "bookGridView";
            this.bookGridView.OptionsView.ShowGroupPanel = false;
            this.bookGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.bookGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.bookGridView.OptionsBehavior.Editable = false;
            this.bookGridView.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            this.bookGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bookGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.bookGridView.OptionsView.ShowGroupPanel = false;
            this.bookGridView.OptionsView.ShowIndicator = false;
            // 
            // BWork
            // 
            this.BWork.FieldName = "BWork";
            this.BWork.Caption = "BWork";
            this.BWork.Name = "BWork";
            this.BWork.Visible = true;
            this.BWork.VisibleIndex = 0;
            this.BWork.Width = 35;
            // 
            // Bids
            // 
            this.Bids.FieldName = "Bids";
            this.Bids.Caption = "Bids";
            this.Bids.Name = "Bids";
            this.Bids.Visible = true;
            this.Bids.VisibleIndex = 1;
            this.Bids.Width = 24;
            // 
            // Price
            // 
            this.Price.FieldName = "Price";
            this.Price.Caption = "Price";
            this.Price.Name = "Price";
            this.Price.Visible = true;
            this.Price.VisibleIndex = 2;
            this.Price.Width = 30;
            // 
            // Asks
            // 
            this.Asks.FieldName = "Asks";
            this.Asks.Caption = "Asks";
            this.Asks.Name = "Asks";
            this.Asks.Visible = true;
            this.Asks.VisibleIndex = 3;
            this.Asks.Width = 30;
            // 
            // AWork
            // 
            this.AWork.FieldName = "AWork";
            this.AWork.Caption = "AWork";
            this.AWork.Name = "AWork";
            this.AWork.Visible = true;
            this.AWork.VisibleIndex = 4;
            this.AWork.Width = 35;
            // 
            // randomizeButton
            // 
            this.randomizeButton.Location = new System.Drawing.Point(3, 510);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(194, 23);
            this.randomizeButton.TabIndex = 1;
            this.randomizeButton.Text = "Randomize!";
            //this.randomizeButton.Click += new System.EventHandler(this.randomizeButton_Click);
            // 
            // BasicDXView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.randomizeButton);
            this.Controls.Add(this.bookGridControl);
            this.Name = "BasicDXView";
            this.Size = new System.Drawing.Size(200, 536);
            ((System.ComponentModel.ISupportInitialize)(this.bookGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookGridView)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private DevExpress.XtraGrid.GridControl bookGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView bookGridView;
        private DevExpress.XtraGrid.Columns.GridColumn BWork;
        private DevExpress.XtraGrid.Columns.GridColumn Bids;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraGrid.Columns.GridColumn Asks;
        private DevExpress.XtraGrid.Columns.GridColumn AWork;
        private DevExpress.XtraEditors.SimpleButton randomizeButton;
    }
}
