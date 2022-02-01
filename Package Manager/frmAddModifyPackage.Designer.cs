
namespace Package_Manager
{
    partial class frmAddPackage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddPackage));
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.dgvPackages = new System.Windows.Forms.DataGridView();
            this.lblPackageDisplay = new System.Windows.Forms.Label();
            this.btnNewPackage = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dateStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cboPackageID = new System.Windows.Forms.ComboBox();
            this.lblPackage = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnModifyProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.txtBasePrice = new System.Windows.Forms.TextBox();
            this.txtCommissionPerc = new System.Windows.Forms.TextBox();
            this.txtComissionPrice = new System.Windows.Forms.TextBox();
            this.lblCommissionPerc = new System.Windows.Forms.Label();
            this.lblCommissionPrice = new System.Windows.Forms.Label();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.btnCalcCommission = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.txtStop = new System.Windows.Forms.TextBox();
            this.btnCancelPackage = new System.Windows.Forms.Button();
            this.btnDeletePackage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(270, 330);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(141, 33);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Add product(s)";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // dgvPackages
            // 
            this.dgvPackages.AllowUserToAddRows = false;
            this.dgvPackages.AllowUserToDeleteRows = false;
            this.dgvPackages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPackages.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackages.Location = new System.Drawing.Point(417, 27);
            this.dgvPackages.Name = "dgvPackages";
            this.dgvPackages.ReadOnly = true;
            this.dgvPackages.RowHeadersVisible = false;
            this.dgvPackages.RowHeadersWidth = 62;
            this.dgvPackages.RowTemplate.Height = 25;
            this.dgvPackages.Size = new System.Drawing.Size(650, 468);
            this.dgvPackages.TabIndex = 1;
            this.dgvPackages.SelectionChanged += new System.EventHandler(this.dgvPackages_SelectionChanged);
            // 
            // lblPackageDisplay
            // 
            this.lblPackageDisplay.AutoSize = true;
            this.lblPackageDisplay.BackColor = System.Drawing.Color.Transparent;
            this.lblPackageDisplay.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPackageDisplay.Location = new System.Drawing.Point(417, 9);
            this.lblPackageDisplay.Name = "lblPackageDisplay";
            this.lblPackageDisplay.Size = new System.Drawing.Size(128, 18);
            this.lblPackageDisplay.TabIndex = 2;
            this.lblPackageDisplay.Text = "Travel Packages";
            // 
            // btnNewPackage
            // 
            this.btnNewPackage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNewPackage.Location = new System.Drawing.Point(294, 14);
            this.btnNewPackage.Name = "btnNewPackage";
            this.btnNewPackage.Size = new System.Drawing.Size(110, 23);
            this.btnNewPackage.TabIndex = 3;
            this.btnNewPackage.Text = "Add new";
            this.btnNewPackage.UseVisualStyleBackColor = false;
            this.btnNewPackage.Click += new System.EventHandler(this.btnNewPackage_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(146, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(265, 23);
            this.txtName.TabIndex = 4;
            this.txtName.Tag = "Name";
            // 
            // dateStartDate
            // 
            this.dateStartDate.CalendarTitleBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.dateStartDate.Location = new System.Drawing.Point(146, 139);
            this.dateStartDate.MaxDate = new System.DateTime(2122, 12, 31, 0, 0, 0, 0);
            this.dateStartDate.MinDate = new System.DateTime(1900, 1, 30, 0, 0, 0, 0);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.Size = new System.Drawing.Size(265, 23);
            this.dateStartDate.TabIndex = 5;
            this.dateStartDate.Tag = "Start Date";
            // 
            // dateEndDate
            // 
            this.dateEndDate.CalendarTitleBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.dateEndDate.Location = new System.Drawing.Point(146, 169);
            this.dateEndDate.MaxDate = new System.DateTime(2122, 12, 31, 0, 0, 0, 0);
            this.dateEndDate.MinDate = new System.DateTime(1900, 1, 30, 0, 0, 0, 0);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Size = new System.Drawing.Size(265, 23);
            this.dateEndDate.TabIndex = 6;
            this.dateEndDate.Tag = "End Date";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Location = new System.Drawing.Point(3, 145);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(140, 15);
            this.lblStartDate.TabIndex = 7;
            this.lblStartDate.Text = "Package start date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDate.Location = new System.Drawing.Point(18, 175);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(126, 15);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "Package end date:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(46, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(98, 15);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Package name:";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(146, 69);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(265, 64);
            this.txtDescription.TabIndex = 10;
            this.txtDescription.Tag = "Description";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(-3, 72);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(147, 15);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Package description:";
            // 
            // cboPackageID
            // 
            this.cboPackageID.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboPackageID.FormattingEnabled = true;
            this.cboPackageID.Location = new System.Drawing.Point(146, 15);
            this.cboPackageID.Name = "cboPackageID";
            this.cboPackageID.Size = new System.Drawing.Size(118, 23);
            this.cboPackageID.TabIndex = 12;
            this.cboPackageID.Tag = "Package ID";
            this.cboPackageID.SelectionChangeCommitted += new System.EventHandler(this.cboPackageID_SelectionChangeCommitted);
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.BackColor = System.Drawing.Color.Transparent;
            this.lblPackage.Location = new System.Drawing.Point(25, 18);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(119, 15);
            this.lblPackage.TabIndex = 13;
            this.lblPackage.Text = "Current package:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(5, 256);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(141, 33);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update package";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(5, 330);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowHeadersWidth = 62;
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.Size = new System.Drawing.Size(259, 165);
            this.dgvProducts.TabIndex = 15;
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);
            // 
            // btnModifyProduct
            // 
            this.btnModifyProduct.Location = new System.Drawing.Point(270, 369);
            this.btnModifyProduct.Name = "btnModifyProduct";
            this.btnModifyProduct.Size = new System.Drawing.Size(141, 33);
            this.btnModifyProduct.TabIndex = 16;
            this.btnModifyProduct.Text = "Modify product(s)";
            this.btnModifyProduct.UseVisualStyleBackColor = true;
            this.btnModifyProduct.Click += new System.EventHandler(this.btnModifyProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(270, 408);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(141, 33);
            this.btnDeleteProduct.TabIndex = 17;
            this.btnDeleteProduct.Text = "Delete product(s)";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // txtBasePrice
            // 
            this.txtBasePrice.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBasePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBasePrice.Location = new System.Drawing.Point(146, 198);
            this.txtBasePrice.Name = "txtBasePrice";
            this.txtBasePrice.Size = new System.Drawing.Size(265, 23);
            this.txtBasePrice.TabIndex = 18;
            this.txtBasePrice.Tag = "Base Price";
            this.txtBasePrice.TextChanged += new System.EventHandler(this.txtBasePrice_TextChanged);
            // 
            // txtCommissionPerc
            // 
            this.txtCommissionPerc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCommissionPerc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommissionPerc.Location = new System.Drawing.Point(117, 227);
            this.txtCommissionPerc.Name = "txtCommissionPerc";
            this.txtCommissionPerc.Size = new System.Drawing.Size(98, 23);
            this.txtCommissionPerc.TabIndex = 19;
            this.txtCommissionPerc.Tag = "Commission Percentage";
            this.txtCommissionPerc.TextChanged += new System.EventHandler(this.txtCommissionPerc_TextChanged);
            // 
            // txtComissionPrice
            // 
            this.txtComissionPrice.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtComissionPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComissionPrice.Location = new System.Drawing.Point(314, 227);
            this.txtComissionPrice.Name = "txtComissionPrice";
            this.txtComissionPrice.ReadOnly = true;
            this.txtComissionPrice.Size = new System.Drawing.Size(97, 23);
            this.txtComissionPrice.TabIndex = 20;
            this.txtComissionPrice.Tag = "Commission Price";
            // 
            // lblCommissionPerc
            // 
            this.lblCommissionPerc.AutoSize = true;
            this.lblCommissionPerc.BackColor = System.Drawing.Color.Transparent;
            this.lblCommissionPerc.Location = new System.Drawing.Point(18, 230);
            this.lblCommissionPerc.Name = "lblCommissionPerc";
            this.lblCommissionPerc.Size = new System.Drawing.Size(98, 15);
            this.lblCommissionPerc.TabIndex = 21;
            this.lblCommissionPerc.Text = "Commission %:";
            // 
            // lblCommissionPrice
            // 
            this.lblCommissionPrice.AutoSize = true;
            this.lblCommissionPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblCommissionPrice.Location = new System.Drawing.Point(221, 230);
            this.lblCommissionPrice.Name = "lblCommissionPrice";
            this.lblCommissionPrice.Size = new System.Drawing.Size(84, 15);
            this.lblCommissionPrice.TabIndex = 22;
            this.lblCommissionPrice.Text = "Commission:";
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.BackColor = System.Drawing.Color.Transparent;
            this.lblBasePrice.Location = new System.Drawing.Point(38, 201);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(105, 15);
            this.lblBasePrice.TabIndex = 23;
            this.lblBasePrice.Text = "Package Price:";
            // 
            // btnCalcCommission
            // 
            this.btnCalcCommission.Location = new System.Drawing.Point(294, 256);
            this.btnCalcCommission.Name = "btnCalcCommission";
            this.btnCalcCommission.Size = new System.Drawing.Size(117, 23);
            this.btnCalcCommission.TabIndex = 24;
            this.btnCalcCommission.Text = "Calc Commission";
            this.btnCalcCommission.UseVisualStyleBackColor = true;
            this.btnCalcCommission.Click += new System.EventHandler(this.btnCalcCommission_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(5, 291);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(141, 33);
            this.btnFinish.TabIndex = 25;
            this.btnFinish.Text = "Finish package";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // txtStop
            // 
            this.txtStop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStop.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtStop.Location = new System.Drawing.Point(500, 69);
            this.txtStop.Multiline = true;
            this.txtStop.Name = "txtStop";
            this.txtStop.ReadOnly = true;
            this.txtStop.Size = new System.Drawing.Size(484, 372);
            this.txtStop.TabIndex = 26;
            this.txtStop.Text = "\r\n\r\n\r\n\r\n\r\n\r\nPlease finish adding a package";
            this.txtStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStop.Visible = false;
            // 
            // btnCancelPackage
            // 
            this.btnCancelPackage.Location = new System.Drawing.Point(152, 291);
            this.btnCancelPackage.Name = "btnCancelPackage";
            this.btnCancelPackage.Size = new System.Drawing.Size(141, 33);
            this.btnCancelPackage.TabIndex = 27;
            this.btnCancelPackage.Text = "Cancel";
            this.btnCancelPackage.UseVisualStyleBackColor = true;
            this.btnCancelPackage.Visible = false;
            this.btnCancelPackage.Click += new System.EventHandler(this.btnCancelPackage_Click);
            // 
            // btnDeletePackage
            // 
            this.btnDeletePackage.Location = new System.Drawing.Point(152, 256);
            this.btnDeletePackage.Name = "btnDeletePackage";
            this.btnDeletePackage.Size = new System.Drawing.Size(141, 33);
            this.btnDeletePackage.TabIndex = 28;
            this.btnDeletePackage.Text = "Delete package";
            this.btnDeletePackage.UseVisualStyleBackColor = true;
            this.btnDeletePackage.Visible = false;
            this.btnDeletePackage.Click += new System.EventHandler(this.btnDeletePackage_Click);
            // 
            // frmAddPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1079, 507);
            this.Controls.Add(this.btnDeletePackage);
            this.Controls.Add(this.btnCancelPackage);
            this.Controls.Add(this.txtStop);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnCalcCommission);
            this.Controls.Add(this.lblBasePrice);
            this.Controls.Add(this.lblCommissionPrice);
            this.Controls.Add(this.lblCommissionPerc);
            this.Controls.Add(this.txtComissionPrice);
            this.Controls.Add(this.txtCommissionPerc);
            this.Controls.Add(this.txtBasePrice);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnModifyProduct);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblPackage);
            this.Controls.Add(this.cboPackageID);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dateEndDate);
            this.Controls.Add(this.dateStartDate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnNewPackage);
            this.Controls.Add(this.lblPackageDisplay);
            this.Controls.Add(this.dgvPackages);
            this.Controls.Add(this.btnAddProduct);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddPackage";
            this.Text = "Package Manager";
            this.Load += new System.EventHandler(this.frmAddPackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.DataGridView dgvPackages;
        private System.Windows.Forms.Label lblPackageDisplay;
        private System.Windows.Forms.Button btnNewPackage;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dateStartDate;
        private System.Windows.Forms.DateTimePicker dateEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cboPackageID;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnModifyProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.TextBox txtBasePrice;
        private System.Windows.Forms.TextBox txtCommissionPerc;
        private System.Windows.Forms.TextBox txtComissionPrice;
        private System.Windows.Forms.Label lblCommissionPerc;
        private System.Windows.Forms.Label lblCommissionPrice;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.Button btnCalcCommission;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.TextBox txtStop;
        private System.Windows.Forms.Button btnCancelPackage;
        private System.Windows.Forms.Button btnDeletePackage;
    }
}