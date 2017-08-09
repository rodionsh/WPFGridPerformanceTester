namespace WFGridPerformanceTester
{
    partial class BasicDXForm
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
            this.basicBookDXViewA = new WFGridPerformanceTester.Views.BasicDXView();
            this.basicBookDXViewB = new WFGridPerformanceTester.Views.BasicDXView();
            this.basicBookDXViewC = new WFGridPerformanceTester.Views.BasicDXView();
            this.SuspendLayout();
            // 
            // basicBookDXViewA
            // 
            this.basicBookDXViewA.Location = new System.Drawing.Point(12, 12);
            this.basicBookDXViewA.Name = "basicBookDXViewA";
            this.basicBookDXViewA.Size = new System.Drawing.Size(210, 550);
            this.basicBookDXViewA.TabIndex = 0;
            // 
            // basicBookDXViewB
            // 
            this.basicBookDXViewB.Location = new System.Drawing.Point(228, 12);
            this.basicBookDXViewB.Name = "basicBookDXViewB";
            this.basicBookDXViewB.Size = new System.Drawing.Size(210, 550);
            this.basicBookDXViewB.TabIndex = 1;
            // 
            // basicBookDXViewC
            // 
            this.basicBookDXViewC.Location = new System.Drawing.Point(444, 12);
            this.basicBookDXViewC.Name = "basicBookDXViewC";
            this.basicBookDXViewC.Size = new System.Drawing.Size(210, 550);
            this.basicBookDXViewC.TabIndex = 2;
            // 
            // BasicDXForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 564);
            this.Controls.Add(this.basicBookDXViewC);
            this.Controls.Add(this.basicBookDXViewB);
            this.Controls.Add(this.basicBookDXViewA);
            this.Name = "BasicDXForm";
            this.Text = "BasicDXForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.BasicDXView basicBookDXViewA;
        private Views.BasicDXView basicBookDXViewB;
        private Views.BasicDXView basicBookDXViewC;
    }
}