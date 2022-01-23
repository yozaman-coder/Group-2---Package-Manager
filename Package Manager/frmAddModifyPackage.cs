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
    public partial class frmAddPackage : Form
    {
        Package selectedPackage = null;

        public frmAddPackage()
        {
            InitializeComponent();
        }

        private void frmAddPackage_Load(object sender, EventArgs e)
        {
            // James Straka - Will try to get these done today
            // Select package 1 by default
            SelectPackage(1);
            DisplayPackages();
            //DisplayProducts();
        }

        private void DisplayPackages()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // Get packages from database
                var packages = db.Packages.Select(p => new
                {
                    p.PackageId,
                    p.PkgName,
                    p.PkgStartDate,
                    p.PkgEndDate,
                    p.PkgDesc,
                    p.PkgBasePrice,
                    // Usually between 8 - 11 %
                    p.PkgAgencyCommission
                }).ToList();


                // Get current package

                // Populate combo box with ids
                for (var i = 0; i < packages.Count; i++)
                {
                    cboPackageID.Items.Add(packages[i].PackageId);
                }

                // Populate data grid view
                dgvPackages.DataSource = packages;
            }
            // Format headers
            dgvPackages.Columns[0].HeaderText = "ID";

            // Format columns for display
            dgvPackages.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvPackages.Columns[5].DefaultCellStyle.Format = "c";
            dgvPackages.Columns[6].DefaultCellStyle.Format = "c";
            dgvPackages.Columns[2].DefaultCellStyle.Format = "MMMM/d/yyyy";
            dgvPackages.Columns[3].DefaultCellStyle.Format = "MMMM/d/yyyy";

            // Makes sure user cannot select multiple rows or select individual components
            dgvPackages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPackages.MultiSelect = false;

        }

        // Will get this done tomorrow.
        private void DisplayProducts()
        {
            throw new NotImplementedException();
        }

        private void cboPackageID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get package id for selection from combo box
            int selectedPackageID = Convert.ToInt32(this.cboPackageID.GetItemText(this.cboPackageID.SelectedItem));
            // Select package with id and display information
            SelectPackage(selectedPackageID);
            //DisplayProducts();
        }

        private void SelectPackage(int selectedPackageID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // Load selected package using selected package ID
                selectedPackage = db.Packages.Find(selectedPackageID);
            }
            // Display package information
            cboPackageID.Text = selectedPackage.PackageId.ToString();
            txtName.Text = selectedPackage.PkgName;
            txtBasePrice.Text = selectedPackage.PkgBasePrice.ToString("c");
            txtDescription.Text = selectedPackage.PkgDesc;
            dateStartDate.Value = (DateTime)selectedPackage.PkgStartDate;
            dateEndDate.Value = (DateTime)selectedPackage.PkgEndDate;
            // Agency commission can be null so we have to check before displaying 
            if (selectedPackage.PkgAgencyCommission != null) // Commission is not null
            {
                txtComissionPrice.Text = selectedPackage.PkgAgencyCommission?.ToString("c");
                // Display commission as percentage
                txtCommissionPerc.Text = (selectedPackage.PkgAgencyCommission / selectedPackage.PkgBasePrice)?.ToString("p");
            }
            else // There is no commission
            {
                txtComissionPrice.Text = "";
                txtCommissionPerc.Text = "0%";
            }
          
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Opens secondForm to add new product/supplier.
        }

        private void btnNewPackage_Click(object sender, EventArgs e)
        {
            // Adds new empty package
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update selected package with form information
            DisplayProducts();
            DisplayPackages();
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            // Opens second form to change selected products/supplier supplier/product.
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            // Delete selected product/supplier.
        }

        // User selects package through data grid view
        private void dgvPackages_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPackages.SelectedRows.Count > 0) // A row has been selected
            {
                int selectedRowIndex = dgvPackages.SelectedCells[0].RowIndex;
                // Get selected row using the index
                DataGridViewRow selectedRow = dgvPackages.Rows[selectedRowIndex];
                // Get Package id from selected row
                string selectedPackageID = selectedRow.Cells["PackageId"].Value.ToString();
                // Select package with package id
                SelectPackage(Convert.ToInt32(selectedPackageID));
            }
        }
    }
}
