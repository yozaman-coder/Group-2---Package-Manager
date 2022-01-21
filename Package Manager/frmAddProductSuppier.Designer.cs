﻿
namespace Package_Manager
{
    partial class frmAddProductSuppier
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
            this.SuspendLayout();
            // 
            // cboProducts
            // 
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(19, 36);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(121, 23);
            this.cboProducts.TabIndex = 0;
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(19, 18);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(54, 15);
            this.lblProducts.TabIndex = 1;
            this.lblProducts.Text = "Products";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(156, 18);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(50, 15);
            this.lblSupplier.TabIndex = 2;
            this.lblSupplier.Text = "Supplier";
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.Enabled = false;
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.Location = new System.Drawing.Point(156, 36);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(121, 23);
            this.cboSuppliers.TabIndex = 3;
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Location = new System.Drawing.Point(19, 65);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(121, 23);
            this.btnNewProduct.TabIndex = 4;
            this.btnNewProduct.Text = "Add new product";
            this.btnNewProduct.UseVisualStyleBackColor = true;
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.Location = new System.Drawing.Point(156, 65);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.Size = new System.Drawing.Size(121, 23);
            this.btnNewSupplier.TabIndex = 5;
            this.btnNewSupplier.Text = "Add new supplier";
            this.btnNewSupplier.UseVisualStyleBackColor = true;
            // 
            // btnAddProductToPackage
            // 
            this.btnAddProductToPackage.Location = new System.Drawing.Point(85, 109);
            this.btnAddProductToPackage.Name = "btnAddProductToPackage";
            this.btnAddProductToPackage.Size = new System.Drawing.Size(121, 41);
            this.btnAddProductToPackage.TabIndex = 6;
            this.btnAddProductToPackage.Text = "Add to selected package";
            this.btnAddProductToPackage.UseVisualStyleBackColor = true;
            // 
            // frmAddProductSuppier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 178);
            this.Controls.Add(this.btnAddProductToPackage);
            this.Controls.Add(this.btnNewSupplier);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.cboSuppliers);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.cboProducts);
            this.Name = "frmAddProductSuppier";
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
    }
}

