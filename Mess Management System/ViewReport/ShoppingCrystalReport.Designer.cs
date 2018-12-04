namespace Mess_Management_System.ViewReport
{
    partial class ShoppingCrystalReport
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
            this.crvShoppingReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvShoppingReport
            // 
            this.crvShoppingReport.ActiveViewIndex = -1;
            this.crvShoppingReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvShoppingReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvShoppingReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvShoppingReport.Location = new System.Drawing.Point(0, 0);
            this.crvShoppingReport.Name = "crvShoppingReport";
            this.crvShoppingReport.Size = new System.Drawing.Size(716, 608);
            this.crvShoppingReport.TabIndex = 0;
            this.crvShoppingReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ShoppingCrystalReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 608);
            this.Controls.Add(this.crvShoppingReport);
            this.Name = "ShoppingCrystalReport";
            this.Text = "ShoppingCrystalReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvShoppingReport;



    }
}