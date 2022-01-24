
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
            this.SuspendLayout();
            // 
            // cboProductID
            // 
            this.cboProductID.FormattingEnabled = true;
            this.cboProductID.Location = new System.Drawing.Point(24, 50);
            this.cboProductID.Margin = new System.Windows.Forms.Padding(4);
            this.cboProductID.Name = "cboProductID";
            this.cboProductID.Size = new System.Drawing.Size(71, 29);
            this.cboProductID.TabIndex = 0;
            this.cboProductID.SelectedIndexChanged += new System.EventHandler(this.cboProducts_SelectedIndexChanged);
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
            // cboSupplierID
            // 
            this.cboSupplierID.FormattingEnabled = true;
            this.cboSupplierID.Location = new System.Drawing.Point(201, 50);
            this.cboSupplierID.Margin = new System.Windows.Forms.Padding(4);
            this.cboSupplierID.Name = "cboSupplierID";
            this.cboSupplierID.Size = new System.Drawing.Size(68, 29);
            this.cboSupplierID.TabIndex = 3;
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Location = new System.Drawing.Point(24, 186);
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
            this.btnNewSupplier.Location = new System.Drawing.Point(201, 186);
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
            this.btnModifyProduct.Location = new System.Drawing.Point(24, 227);
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
            this.btnSupplierModify.Location = new System.Drawing.Point(201, 227);
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
            this.btnCancel.Location = new System.Drawing.Point(201, 344);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 57);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(24, 91);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(156, 29);
            this.txtProductName.TabIndex = 10;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(201, 91);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(156, 29);
            this.txtSupplierName.TabIndex = 11;
            // 
            // frmAddModifyProductSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 419);
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
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddModifyProductSupplier";
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.frmAddModifyProductSuppier_Load);
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
    }
}

