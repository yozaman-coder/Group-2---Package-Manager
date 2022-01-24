
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
            this.txtProdCode = new System.Windows.Forms.TextBox();
            this.txtSupCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboProducts
            // 
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(26, 59);
            this.cboProducts.Margin = new System.Windows.Forms.Padding(4);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(154, 40);
            this.cboProducts.TabIndex = 0;
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(24, 25);
            this.lblProducts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(106, 32);
            this.lblProducts.TabIndex = 1;
            this.lblProducts.Text = "Products";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(275, 25);
            this.lblSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(102, 32);
            this.lblSupplier.TabIndex = 2;
            this.lblSupplier.Text = "Supplier";
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.Enabled = false;
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.Location = new System.Drawing.Point(275, 59);
            this.cboSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(154, 40);
            this.cboSuppliers.TabIndex = 3;
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Location = new System.Drawing.Point(24, 171);
            this.btnNewProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(194, 72);
            this.btnNewProduct.TabIndex = 4;
            this.btnNewProduct.Text = "Add new product";
            this.btnNewProduct.UseVisualStyleBackColor = true;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.Location = new System.Drawing.Point(275, 171);
            this.btnNewSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.Size = new System.Drawing.Size(170, 72);
            this.btnNewSupplier.TabIndex = 5;
            this.btnNewSupplier.Text = "Add new supplier";
            this.btnNewSupplier.UseVisualStyleBackColor = true;
            this.btnNewSupplier.Click += new System.EventHandler(this.btnNewSupplier_Click);
            // 
            // btnAddProductToPackage
            // 
            this.btnAddProductToPackage.Location = new System.Drawing.Point(24, 344);
            this.btnAddProductToPackage.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProductToPackage.Name = "btnAddProductToPackage";
            this.btnAddProductToPackage.Size = new System.Drawing.Size(194, 75);
            this.btnAddProductToPackage.TabIndex = 6;
            this.btnAddProductToPackage.Text = "Add to selected package";
            this.btnAddProductToPackage.UseVisualStyleBackColor = true;
            this.btnAddProductToPackage.Click += new System.EventHandler(this.btnAddProductToPackage_Click);
            // 
            // btnModifyProduct
            // 
            this.btnModifyProduct.Location = new System.Drawing.Point(26, 256);
            this.btnModifyProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnModifyProduct.Name = "btnModifyProduct";
            this.btnModifyProduct.Size = new System.Drawing.Size(192, 74);
            this.btnModifyProduct.TabIndex = 7;
            this.btnModifyProduct.Text = "Modify Product";
            this.btnModifyProduct.UseVisualStyleBackColor = true;
            this.btnModifyProduct.Click += new System.EventHandler(this.btnModifyProduct_Click);
            // 
            // btnSupplierModify
            // 
            this.btnSupplierModify.Location = new System.Drawing.Point(275, 251);
            this.btnSupplierModify.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupplierModify.Name = "btnSupplierModify";
            this.btnSupplierModify.Size = new System.Drawing.Size(170, 79);
            this.btnSupplierModify.TabIndex = 8;
            this.btnSupplierModify.Text = "Modify Supplier";
            this.btnSupplierModify.UseVisualStyleBackColor = true;
            this.btnSupplierModify.Click += new System.EventHandler(this.btnSupplierModify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(164, 500);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 57);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtProdCode
            // 
            this.txtProdCode.Location = new System.Drawing.Point(26, 103);
            this.txtProdCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtProdCode.Name = "txtProdCode";
            this.txtProdCode.ReadOnly = true;
            this.txtProdCode.Size = new System.Drawing.Size(154, 39);
            this.txtProdCode.TabIndex = 10;
            // 
            // txtSupCode
            // 
            this.txtSupCode.Location = new System.Drawing.Point(275, 103);
            this.txtSupCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.ReadOnly = true;
            this.txtSupCode.Size = new System.Drawing.Size(157, 39);
            this.txtSupCode.TabIndex = 11;
            // 
            // frmAddModifyProductSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 598);
            this.Controls.Add(this.txtSupCode);
            this.Controls.Add(this.txtProdCode);
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
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddModifyProductSupplier";
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.frmAddModifyProductSuppier_Load);
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
        private System.Windows.Forms.TextBox txtProdCode;
        private System.Windows.Forms.TextBox txtSupCode;
    }
}

