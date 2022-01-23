using ProductData;
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

        public Supplier Suppliers;
        public bool AddSupplier;
        private TravelExpertsContext context = new TravelExpertsContext();

        public frmAddModifySupplier()
        {
            InitializeComponent();
        }

        private void frmAddModifySupplier_Load(object sender, EventArgs e)
        {

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
            this.btnCancel.Location = new System.Drawing.Point(208, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(12, 79);
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
            this.txtSupplierName.Location = new System.Drawing.Point(153, 79);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(151, 23);
            this.txtSupplierName.TabIndex = 8;
            // 
            // btnAddModifySupplier
            // 
            this.btnAddModifySupplier.Location = new System.Drawing.Point(62, 144);
            this.btnAddModifySupplier.Name = "btnAddModifySupplier";
            this.btnAddModifySupplier.Size = new System.Drawing.Size(75, 36);
            this.btnAddModifySupplier.TabIndex = 7;
            this.btnAddModifySupplier.Text = "Add";
            this.btnAddModifySupplier.UseVisualStyleBackColor = true;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(153, 29);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(100, 23);
            this.txtSupplierID.TabIndex = 6;
            // 
            // frmAddModifySupplier
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(385, 269);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.lblSupplierID);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.btnAddModifySupplier);
            this.Controls.Add(this.txtSupplierID);
            this.Name = "frmAddModifySupplier";
            this.Text = "Add Supplier";
            this.Load += new System.EventHandler(this.frmAddModifySupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
}
