using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Package_Manager
{
    public partial class frmAddPackage : Form
    {
        Package selectedPackage = null;
        ProductsSupplier selectedProduct = null;
        decimal? commissionPercentage = null;
        bool calcUpdated = true;
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
            DisplayProducts();
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
            using(TravelExpertsContext db = new TravelExpertsContext())
            {
                try
                {
                    var products = from p in db.PackagesProductsSuppliers
                                   where p.PackageId == selectedPackage.PackageId
                                   join prodsup in db.ProductsSuppliers
                                   on p.ProductSupplierId equals prodsup.ProductSupplierId
                                   join prod in db.Products
                                   on prodsup.ProductId equals prod.ProductId
                                   join supp in db.Suppliers
                                   on prodsup.SupplierId equals supp.SupplierId
                                   select new
                                   {
                                       ProductSupplierID = prodsup.ProductSupplierId,
                                       ProductName = prod.ProdName,
                                       SupplierName = supp.SupName
                                   };
                    var productsList = products.ToList();
                    dgvProducts.DataSource = productsList;
                    dgvProducts.ClearSelection();
                }
                catch (DbUpdateException ex)
                {
                    this.HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    this.HandleGeneralError(ex);
                }
            }
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Makes sure user cannot select multiple rows or select individual components
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            

        }

        private void cboPackageID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get package id for selection from combo box
            int selectedPackageID = Convert.ToInt32(this.cboPackageID.GetItemText(this.cboPackageID.SelectedItem));
            // Select package with id and display information
            SelectPackage(selectedPackageID);
            DisplayProducts();
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
            if (selectedPackage.PkgAgencyCommission > 0 && selectedPackage.PkgAgencyCommission != null) // Commission is not null
            {
                txtComissionPrice.Text = selectedPackage.PkgAgencyCommission?.ToString("c");
                // Display commission as percentage
                commissionPercentage = (selectedPackage.PkgAgencyCommission / selectedPackage.PkgBasePrice);
                txtCommissionPerc.Text = Decimal.Round(commissionPercentage.Value*100, 2).ToString();
                calcUpdated = true;
            }
            else // There is no commission
            {
                txtComissionPrice.Text = 0.ToString("c");
                txtCommissionPerc.Text = 0.ToString();
                calcUpdated = true;
            }
          
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Opens secondForm to add new product/supplier.
            frmAddModifyProductSupplier secondForm = new frmAddModifyProductSupplier();
            secondForm.isAdd = true; // Adding a product supplier
            secondForm.productSupplier = null; // No product supplier selected

            DialogResult result = secondForm.ShowDialog();

            if(result == DialogResult.OK)
            {
                //selectedPackageProductSupplier = secondForm.productSupplier;
                try
                {
                    using(TravelExpertsContext db = new TravelExpertsContext())
                    {
                        db.ProductsSuppliers.Add(selectedProduct);
                        db.SaveChanges();
                    }
                    DisplayProducts();
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void HandleDatabaseError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "Error Code: " + error.Number + " " + error.Message + "\n";
            }
            MessageBox.Show(errorMessage);
        }

        private void btnNewPackage_Click(object sender, EventArgs e)
        {
            // Adds new empty package
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update selected package with form information
            if(calcUpdated != true)
            {
                MessageBox.Show("Commission percentage has changed and must be recalculated! Press Calc Commission", "Commission Uncalculated");
            }
            //if(Success)
            //{
            //    // Update data and then redisplay
            //    DisplayProducts();
            //    DisplayPackages();
            //}
           
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            // Opens second form to change selected products/supplier supplier/product.
            if (selectedProduct != null)
            {
                frmAddModifyProductSupplier secondForm = new frmAddModifyProductSupplier();
                secondForm.isAdd = false;
                secondForm.productSupplier = selectedProduct;

                DialogResult result = secondForm.ShowDialog();

                if(result == DialogResult.OK)
                {
                    try
                    {
                        using (TravelExpertsContext db = new TravelExpertsContext())
                        {
                            selectedProduct = db.ProductsSuppliers.Find(secondForm.productSupplier.ProductSupplierId);
                            selectedProduct.ProductId = secondForm.productSupplier.ProductId;
                            selectedProduct.SupplierId = secondForm.productSupplier.SupplierId;
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        this.HandleDatabaseError(ex);
                    }
                    catch (Exception ex)
                    {
                        this.HandleGeneralError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a product first!", "Product Selection Error");
            }
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
                DisplayProducts();
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0) // A row has been selected
            {
                int selectedRowIndex = dgvProducts.SelectedCells[0].RowIndex;
                // Get selected row using the index
                DataGridViewRow selectedRow = dgvProducts.Rows[selectedRowIndex];
                // Get Package id from selected row
                string selectedProductSupplierID = selectedRow.Cells["ProductSupplierID"].Value.ToString();
                // Select package with package id
                SelectProduct(Convert.ToInt32(selectedProductSupplierID));
            }
        }

        private void SelectProduct(int selectedProductSupplierID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // Load selected product using selected product ID
                selectedProduct = db.ProductsSuppliers.Find(selectedProductSupplierID);
            }
        }

        private void btnCalcCommission_Click(object sender, EventArgs e)
        {
            string strippedCommissionPerc = Regex.Replace(txtCommissionPerc.Text.ToString(), @"[^0-9a-zA-Z.-]+", "");

            if (Convert.ToDecimal(strippedCommissionPerc) == 0 | strippedCommissionPerc == "")
            {
                selectedPackage.PkgAgencyCommission = null;
                txtComissionPrice.Text = 0.ToString("c");
                calcUpdated = true;
            }
            else if (Convert.ToDecimal(strippedCommissionPerc) < 1)
            {
                MessageBox.Show("Commission percent cannot be less than 1", "Error");
            }
            else
            {
                string strippedBase = Regex.Replace(txtBasePrice.Text.ToString(), @"[^0-9a-zA-Z.]+", "");
                decimal commissionTotal = (Decimal.Parse(strippedCommissionPerc) / 100) * Decimal.Parse(strippedBase);
                selectedPackage.PkgAgencyCommission = commissionTotal;
                txtComissionPrice.Text = Decimal.Round(selectedPackage.PkgAgencyCommission.Value, 2).ToString("c");
                calcUpdated = true;
            }
        }

        private void txtCommissionPerc_TextChanged(object sender, EventArgs e)
        {
            calcUpdated = false;
        }
    }
}
