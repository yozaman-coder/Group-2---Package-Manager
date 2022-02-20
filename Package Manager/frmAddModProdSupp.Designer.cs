
namespace Package_Manager
{
    partial class frmAddModProdSupp
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
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.lstSuppliers = new System.Windows.Forms.ListBox();
            this.btnAddProductToPackage = new System.Windows.Forms.Button();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.btnNewSupplier = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstProducts
            // 
            this.lstProducts.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 27;
            this.lstProducts.Location = new System.Drawing.Point(55, 38);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(520, 382);
            this.lstProducts.TabIndex = 0;
            // 
            // lstSuppliers
            // 
            this.lstSuppliers.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstSuppliers.FormattingEnabled = true;
            this.lstSuppliers.ItemHeight = 27;
            this.lstSuppliers.Location = new System.Drawing.Point(659, 38);
            this.lstSuppliers.Name = "lstSuppliers";
            this.lstSuppliers.Size = new System.Drawing.Size(520, 382);
            this.lstSuppliers.TabIndex = 1;
            // 
            // btnAddProductToPackage
            // 
            this.btnAddProductToPackage.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddProductToPackage.Location = new System.Drawing.Point(484, 477);
            this.btnAddProductToPackage.Name = "btnAddProductToPackage";
            this.btnAddProductToPackage.Size = new System.Drawing.Size(258, 95);
            this.btnAddProductToPackage.TabIndex = 2;
            this.btnAddProductToPackage.Text = "Add Product-Supplier to Package";
            this.btnAddProductToPackage.UseVisualStyleBackColor = true;
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewProduct.Location = new System.Drawing.Point(55, 477);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(201, 87);
            this.btnNewProduct.TabIndex = 3;
            this.btnNewProduct.Text = "Add New Product";
            this.btnNewProduct.UseVisualStyleBackColor = true;
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewSupplier.Location = new System.Drawing.Point(978, 477);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.Size = new System.Drawing.Size(201, 87);
            this.btnNewSupplier.TabIndex = 4;
            this.btnNewSupplier.Text = "Add New Supplier";
            this.btnNewSupplier.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(484, 633);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(258, 95);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddModProdSupp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 776);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNewSupplier);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.btnAddProductToPackage);
            this.Controls.Add(this.lstSuppliers);
            this.Controls.Add(this.lstProducts);
            this.Name = "frmAddModProdSupp";
            this.Text = "frmAddModProdSupp";
            this.Load += new System.EventHandler(this.frmAddModProdSupp_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.ListBox lstSuppliers;
        private System.Windows.Forms.Button btnAddProductToPackage;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.Button btnCancel;
    }
}