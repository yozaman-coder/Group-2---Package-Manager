
namespace Package_Manager
{
    partial class frmAddModifyProductSuppier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddModifyProductSuppier));
            this.cboProducts = new System.Windows.Forms.ComboBox();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cboSuppliers = new System.Windows.Forms.ComboBox();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.btnNewSupplier = new System.Windows.Forms.Button();
            this.btnAddProductToPackage = new System.Windows.Forms.Button();
            this.btnModifyProduct = new System.Windows.Forms.Button();
            this.btnSupplierModify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboProducts
            // 
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(45, 67);
            this.cboProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(144, 26);
            this.cboProducts.TabIndex = 0;
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.BackColor = System.Drawing.Color.Transparent;
            this.lblProducts.Location = new System.Drawing.Point(45, 43);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(72, 18);
            this.lblProducts.TabIndex = 1;
            this.lblProducts.Text = "Products";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplier.Location = new System.Drawing.Point(264, 43);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(72, 18);
            this.lblSupplier.TabIndex = 2;
            this.lblSupplier.Text = "Supplier";
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.Enabled = false;
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.Location = new System.Drawing.Point(258, 67);
            this.cboSuppliers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(144, 26);
            this.cboSuppliers.TabIndex = 3;
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Location = new System.Drawing.Point(45, 101);
            this.btnNewProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(144, 28);
            this.btnNewProduct.TabIndex = 4;
            this.btnNewProduct.Text = "Add new product";
            this.btnNewProduct.UseVisualStyleBackColor = true;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.Location = new System.Drawing.Point(258, 101);
            this.btnNewSupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.Size = new System.Drawing.Size(144, 28);
            this.btnNewSupplier.TabIndex = 5;
            this.btnNewSupplier.Text = "Add new supplier";
            this.btnNewSupplier.UseVisualStyleBackColor = true;
            this.btnNewSupplier.Click += new System.EventHandler(this.btnNewSupplier_Click);
            // 
            // btnAddProductToPackage
            // 
            this.btnAddProductToPackage.Location = new System.Drawing.Point(45, 204);
            this.btnAddProductToPackage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddProductToPackage.Name = "btnAddProductToPackage";
            this.btnAddProductToPackage.Size = new System.Drawing.Size(144, 49);
            this.btnAddProductToPackage.TabIndex = 6;
            this.btnAddProductToPackage.Text = "Add to selected package";
            this.btnAddProductToPackage.UseVisualStyleBackColor = true;
            this.btnAddProductToPackage.Click += new System.EventHandler(this.btnAddProductToPackage_Click);
            // 
            // btnModifyProduct
            // 
            this.btnModifyProduct.Location = new System.Drawing.Point(45, 137);
            this.btnModifyProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifyProduct.Name = "btnModifyProduct";
            this.btnModifyProduct.Size = new System.Drawing.Size(144, 32);
            this.btnModifyProduct.TabIndex = 7;
            this.btnModifyProduct.Text = "Modify";
            this.btnModifyProduct.UseVisualStyleBackColor = true;
            this.btnModifyProduct.Click += new System.EventHandler(this.btnModifyProduct_Click);
            // 
            // btnSupplierModify
            // 
            this.btnSupplierModify.Location = new System.Drawing.Point(258, 137);
            this.btnSupplierModify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSupplierModify.Name = "btnSupplierModify";
            this.btnSupplierModify.Size = new System.Drawing.Size(144, 32);
            this.btnSupplierModify.TabIndex = 8;
            this.btnSupplierModify.Text = "Modify";
            this.btnSupplierModify.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(258, 204);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 49);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddModifyProductSuppier
            // 
            this.AcceptButton = this.btnAddProductToPackage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(441, 274);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSupplierModify);
            this.Controls.Add(this.btnModifyProduct);
            this.Controls.Add(this.btnAddProductToPackage);
            this.Controls.Add(this.btnNewSupplier);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.cboSuppliers);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.cboProducts);
            this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAddModifyProductSuppier";
            this.Text = "Add Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProducts;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboSuppliers;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.Button btnAddProductToPackage;
        private System.Windows.Forms.Button btnModifyProduct;
        private System.Windows.Forms.Button btnSupplierModify;
        private System.Windows.Forms.Button btnCancel;
    }
}

