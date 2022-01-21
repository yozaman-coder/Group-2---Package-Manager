using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Package_Manager
{
    public partial class frmAddModifySupplier : Form
    {
        private Button btnCancel;
        private Label lblSupplierName;
        private Label lblSupplierID;
        private TextBox txtSupplierName;
        private Button btnAddModifySupplier;
        private TextBox txtSupplierID;

        public frmAddModifySupplier()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblSupplierID = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.btnAddModifySupplier = new System.Windows.Forms.Button();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(161, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(9, 65);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(88, 15);
            this.lblSupplierName.TabIndex = 10;
            this.lblSupplierName.Text = "Supplier Name:";
            // 
            // lblSupplierID
            // 
            this.lblSupplierID.AutoSize = true;
            this.lblSupplierID.Location = new System.Drawing.Point(33, 35);
            this.lblSupplierID.Name = "lblSupplierID";
            this.lblSupplierID.Size = new System.Drawing.Size(67, 15);
            this.lblSupplierID.TabIndex = 9;
            this.lblSupplierID.Text = "Supplier ID:";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(102, 62);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(151, 23);
            this.txtSupplierName.TabIndex = 8;
            // 
            // btnAddModifySupplier
            // 
            this.btnAddModifySupplier.Location = new System.Drawing.Point(52, 110);
            this.btnAddModifySupplier.Name = "btnAddModifySupplier";
            this.btnAddModifySupplier.Size = new System.Drawing.Size(75, 23);
            this.btnAddModifySupplier.TabIndex = 7;
            this.btnAddModifySupplier.Text = "Add";
            this.btnAddModifySupplier.UseVisualStyleBackColor = true;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(102, 32);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(100, 23);
            this.txtSupplierID.TabIndex = 6;
            // 
            // frmAddModifySupplier
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(269, 151);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.lblSupplierID);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.btnAddModifySupplier);
            this.Controls.Add(this.txtSupplierID);
            this.Name = "frmAddModifySupplier";
            this.Text = "Add Supplier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
