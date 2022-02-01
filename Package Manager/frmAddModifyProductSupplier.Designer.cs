
namespace Package_Manager
{
    partial class frmAddModifyProductSupplier
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddModifyProductSupplier));
            this.cboProductID = new System.Windows.Forms.ComboBox();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cboSupplierID = new System.Windows.Forms.ComboBox();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.btnNewSupplier = new System.Windows.Forms.Button();
            this.btnAddProductToPackage = new System.Windows.Forms.Button();
            this.btnModifyProduct = new System.Windows.Forms.Button();
            this.btnSupplierModify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProdSupID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboProductID
            // 
            this.cboProductID.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboProductID.FormattingEnabled = true;
            this.cboProductID.Location = new System.Drawing.Point(21, 43);
            this.cboProductID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboProductID.Name = "cboProductID";
            this.cboProductID.Size = new System.Drawing.Size(117, 26);
            this.cboProductID.TabIndex = 0;
            this.cboProductID.SelectedIndexChanged += new System.EventHandler(this.cboProducts_SelectedIndexChanged);
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.BackColor = System.Drawing.Color.Transparent;
            this.lblProducts.Location = new System.Drawing.Point(21, 21);
            this.lblProducts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(72, 18);
            this.lblProducts.TabIndex = 1;
            this.lblProducts.Text = "Products";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplier.Location = new System.Drawing.Point(380, 21);
            this.lblSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(72, 18);
            this.lblSupplier.TabIndex = 2;
            this.lblSupplier.Text = "Supplier";
            // 
            // cboSupplierID
            // 
            this.cboSupplierID.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboSupplierID.FormattingEnabled = true;
            this.cboSupplierID.Location = new System.Drawing.Point(380, 46);
            this.cboSupplierID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboSupplierID.Name = "cboSupplierID";
            this.cboSupplierID.Size = new System.Drawing.Size(117, 26);
            this.cboSupplierID.TabIndex = 3;
            this.cboSupplierID.SelectedIndexChanged += new System.EventHandler(this.cboSupplierID_SelectedIndexChanged);
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Location = new System.Drawing.Point(21, 126);
            this.btnNewProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(171, 37);
            this.btnNewProduct.TabIndex = 4;
            this.btnNewProduct.Text = "Add new product";
            this.btnNewProduct.UseVisualStyleBackColor = true;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.Location = new System.Drawing.Point(475, 126);
            this.btnNewSupplier.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.Size = new System.Drawing.Size(151, 37);
            this.btnNewSupplier.TabIndex = 5;
            this.btnNewSupplier.Text = "Add new supplier";
            this.btnNewSupplier.UseVisualStyleBackColor = true;
            this.btnNewSupplier.Click += new System.EventHandler(this.btnNewSupplier_Click);
            // 
            // btnAddProductToPackage
            // 
            this.btnAddProductToPackage.Location = new System.Drawing.Point(253, 212);
            this.btnAddProductToPackage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddProductToPackage.Name = "btnAddProductToPackage";
            this.btnAddProductToPackage.Size = new System.Drawing.Size(144, 49);
            this.btnAddProductToPackage.TabIndex = 6;
            this.btnAddProductToPackage.Text = "Add to selected package";
            this.btnAddProductToPackage.UseVisualStyleBackColor = true;
            this.btnAddProductToPackage.Click += new System.EventHandler(this.btnAddProductToPackage_Click);
            // 
            // btnModifyProduct
            // 
            this.btnModifyProduct.Location = new System.Drawing.Point(21, 178);
            this.btnModifyProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnModifyProduct.Name = "btnModifyProduct";
            this.btnModifyProduct.Size = new System.Drawing.Size(171, 35);
            this.btnModifyProduct.TabIndex = 7;
            this.btnModifyProduct.Text = "Modify Product";
            this.btnModifyProduct.UseVisualStyleBackColor = true;
            this.btnModifyProduct.Click += new System.EventHandler(this.btnModifyProduct_Click);
            // 
            // btnSupplierModify
            // 
            this.btnSupplierModify.Location = new System.Drawing.Point(475, 178);
            this.btnSupplierModify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSupplierModify.Name = "btnSupplierModify";
            this.btnSupplierModify.Size = new System.Drawing.Size(151, 35);
            this.btnSupplierModify.TabIndex = 8;
            this.btnSupplierModify.Text = "Modify Supplier";
            this.btnSupplierModify.UseVisualStyleBackColor = true;
            this.btnSupplierModify.Click += new System.EventHandler(this.btnSupplierModify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(253, 277);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 49);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Location = new System.Drawing.Point(21, 78);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(246, 25);
            this.txtProductName.TabIndex = 10;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierName.Location = new System.Drawing.Point(380, 78);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(246, 25);
            this.txtSupplierName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(253, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "ProductSupplierID";
            // 
            // lblProdSupID
            // 
            this.lblProdSupID.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblProdSupID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProdSupID.Location = new System.Drawing.Point(287, 153);
            this.lblProdSupID.Name = "lblProdSupID";
            this.lblProdSupID.Size = new System.Drawing.Size(71, 35);
            this.lblProdSupID.TabIndex = 13;
            this.lblProdSupID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddModifyProductSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(637, 333);
            this.Controls.Add(this.lblProdSupID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSupplierModify);
            this.Controls.Add(this.btnModifyProduct);
            this.Controls.Add(this.btnAddProductToPackage);
            this.Controls.Add(this.btnNewSupplier);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.cboSupplierID);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.cboProductID);
            this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmAddModifyProductSupplier";
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.frmAddModifyProductSupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProductID;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboSupplierID;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.Button btnAddProductToPackage;
        private System.Windows.Forms.Button btnModifyProduct;
        private System.Windows.Forms.Button btnSupplierModify;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProdSupID;
    }
}

