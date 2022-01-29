/* Brett - this form opens in response to on-click events from btnNewSupplier and btnSupplierModify on the frmAddModifyProductSupplier form.
 */
using ProductData;
using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Package_Manager
{
    public partial class frmAddModifySupplier : Form
    {
        private Button btnCancel;
        private Label lblSupplierName;
        private Label lblSupplierID;
        private TextBox txtSupplierName;
        private Button btnAddSupplier;
        private TextBox txtSupplierID;

        public Supplier Suppliers;
        private DataGridView dgvListSuppliers;
        private Button btnSave;
        public bool AddSupplier;
        //private TravelExpertsContext context = new TravelExpertsContext();

        public string getselectedSupplierID
        {
            get { return txtSupplierID.Text; }
            set { txtSupplierID.Text = value; }
        }
        public frmAddModifySupplier()
        {
            InitializeComponent();
        }

        private void frmAddModifySupplier_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            if (AddSupplier)
            {
                this.Text = "Add Supplier";
                txtSupplierID.ReadOnly = true;
                btnAddSupplier.Visible = true;
            }
            else
            {
                this.Text = "Modify Supplier";
                txtSupplierID.ReadOnly = true;
                btnSave.Visible = true;

            }
        }
        private void LoadSuppliers()
        {
            using (TravelExpertsContext db = new TravelExpertsContext()) // Establishes a connection with the database.
            {
                dgvListSuppliers.Columns.Clear(); // Calls the DataGridView's Clear() method
                /*The below implicitly-typed variable stores the results of a lambda expression that gets each of the 
                 * public properties from the Products class, representing attributes/columns from the Products table
                 * and stores them in a list. Note that */
                var products = db.Suppliers.Select(s => new
                {
                    s.SupplierId,
                    s.SupName
                }).ToList();

                dgvListSuppliers.DataSource = products; /* gets the entries stored in the products local variable and sets 
                                                        * them as the DataGridView's datasource. */

                dgvListSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold); //setting DGV's header font 

                // format the first column
                dgvListSuppliers.Columns[0].HeaderText = "Supplier ID";
                dgvListSuppliers.Columns[0].Width = 150;
                // format the second column
                dgvListSuppliers.Columns[1].HeaderText = "Supplier Name";
                dgvListSuppliers.Columns[dgvListSuppliers.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        
        
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var newSupplier = new Supplier();
                this.FillSupplierData(newSupplier);
                try 
                { 
                    db.Suppliers.Add(newSupplier);
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    this.HandleDataBaseError(ex);
                }
                catch (Exception ex)
                {
                    this.HandleGeneralError(ex);
                }
                LoadSuppliers();
                MessageBox.Show("New record was added to the database.");
            }
        }

        private void FillSupplierData(Supplier Suppliers)
        {
            Suppliers.SupName = txtSupplierName.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new TravelExpertsContext())
            {
                var modSupplier = db.Suppliers.Find(Convert.ToInt32(getselectedSupplierID));
                modSupplier.SupName = txtSupplierName.Text;
                db.SaveChanges();
                LoadSuppliers();
                MessageBox.Show("Change made successfully.");
            }
        }

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void HandleDataBaseError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE:  " + error.Number + " " +
                                error.Message + "\n";
            }
            MessageBox.Show(errorMessage);
        }
        /* Brett - should all of the Form Designer code be visible within the InitializeComponent method 
         * here? I haven't seen that before. It's usually stored in a different module.*/
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblSupplierID = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.dgvListSuppliers = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(119, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(12, 79);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(133, 25);
            this.lblSupplierName.TabIndex = 10;
            this.lblSupplierName.Text = "Supplier Name:";
            // 
            // lblSupplierID
            // 
            this.lblSupplierID.AutoSize = true;
            this.lblSupplierID.Location = new System.Drawing.Point(33, 35);
            this.lblSupplierID.Name = "lblSupplierID";
            this.lblSupplierID.Size = new System.Drawing.Size(104, 25);
            this.lblSupplierID.TabIndex = 9;
            this.lblSupplierID.Text = "Supplier ID:";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(153, 79);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(173, 31);
            this.txtSupplierName.TabIndex = 8;
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(119, 156);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(75, 36);
            this.btnAddSupplier.TabIndex = 7;
            this.btnAddSupplier.Text = "Add";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Visible = false;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(153, 29);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(100, 31);
            this.txtSupplierID.TabIndex = 6;
            // 
            // dgvListSuppliers
            // 
            this.dgvListSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListSuppliers.Location = new System.Drawing.Point(383, 35);
            this.dgvListSuppliers.Name = "dgvListSuppliers";
            this.dgvListSuppliers.RowHeadersWidth = 62;
            this.dgvListSuppliers.RowTemplate.Height = 33;
            this.dgvListSuppliers.Size = new System.Drawing.Size(676, 352);
            this.dgvListSuppliers.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(119, 253);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 36);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddModifySupplier
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1090, 440);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvListSuppliers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.lblSupplierID);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.txtSupplierID);
            this.Name = "frmAddModifySupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Supplier";
            this.Load += new System.EventHandler(this.frmAddModifySupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
