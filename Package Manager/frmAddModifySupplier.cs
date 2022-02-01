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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddModifySupplier));
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
            this.btnCancel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(258, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 46);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplierName.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSupplierName.Location = new System.Drawing.Point(14, 129);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(120, 18);
            this.lblSupplierName.TabIndex = 10;
            this.lblSupplierName.Text = "Supplier Name:";
            // 
            // lblSupplierID
            // 
            this.lblSupplierID.AutoSize = true;
            this.lblSupplierID.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplierID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSupplierID.Location = new System.Drawing.Point(30, 66);
            this.lblSupplierID.Name = "lblSupplierID";
            this.lblSupplierID.Size = new System.Drawing.Size(104, 18);
            this.lblSupplierID.TabIndex = 9;
            this.lblSupplierID.Text = "Supplier ID:";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtSupplierName.Location = new System.Drawing.Point(136, 122);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(256, 25);
            this.txtSupplierName.TabIndex = 8;
            // 
            // btnAddModifySupplier
            // 
            this.btnAddModifySupplier.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddModifySupplier.Location = new System.Drawing.Point(45, 204);
            this.btnAddModifySupplier.Name = "btnAddModifySupplier";
            this.btnAddModifySupplier.Size = new System.Drawing.Size(128, 46);
            this.btnAddModifySupplier.TabIndex = 7;
            this.btnAddModifySupplier.Text = "&Save";
            this.btnAddModifySupplier.UseVisualStyleBackColor = true;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtSupplierID.Location = new System.Drawing.Point(136, 61);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(256, 25);
            this.txtSupplierID.TabIndex = 6;
            // 
            // frmAddModifySupplier
            // 
            this.AcceptButton = this.btnAddModifySupplier;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(441, 274);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.lblSupplierID);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.btnAddModifySupplier);
            this.Controls.Add(this.txtSupplierID);
            this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmAddModifySupplier";
            this.Text = "Add/Modify Supplier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
