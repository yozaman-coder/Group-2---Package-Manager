
namespace Package_Manager
{
    partial class frmAddModifyProduct
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
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.btnAddModifyProduct = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(197, 51);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(141, 31);
            this.txtProductID.TabIndex = 0;
            // 
            // btnAddModifyProduct
            // 
            this.btnAddModifyProduct.Location = new System.Drawing.Point(76, 182);
            this.btnAddModifyProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddModifyProduct.Name = "btnAddModifyProduct";
            this.btnAddModifyProduct.Size = new System.Drawing.Size(107, 38);
            this.btnAddModifyProduct.TabIndex = 1;
            this.btnAddModifyProduct.Text = "Add";
            this.btnAddModifyProduct.UseVisualStyleBackColor = true;
            this.btnAddModifyProduct.Click += new System.EventHandler(this.btnAddModifyProduct_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(197, 104);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(214, 31);
            this.txtProductName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Product ID:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(14, 107);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(130, 25);
            this.lblProductName.TabIndex = 4;
            this.lblProductName.Text = "Product Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(231, 182);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 38);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddModifyProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(508, 339);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.btnAddModifyProduct);
            this.Controls.Add(this.txtProductID);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddModifyProduct";
            this.Text = "frmAddProduct";
            this.Load += new System.EventHandler(this.frmAddModifyProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Button btnAddModifyProduct;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Button btnCancel;
    }
}