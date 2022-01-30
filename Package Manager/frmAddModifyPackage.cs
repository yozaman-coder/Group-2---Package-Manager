using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Package_Manager
{
    //ADD ERROR CATCHING FOR DATABASE ACCESS POINTS
    //WORK ON PRODUCT MANAGEMENT AND MAKE IT WORK WHEN ADDING PACKAGE SOMEHOW
    //ADD VALIDATION FOR UPDATEPACKAGE()/CREATEPACKAGE()
    //ADD COMMENTING EVERYWHERE LOL


    public partial class frmAddPackage : Form
    {
        Package selectedPackage = null;
        ProductsSupplier selectedProduct = null;
        decimal? commissionPercentage = null;
        bool calcUpdated = true;
        bool succesfullAddition = true;
        bool dontCallSelectionEvent = false;
        int firstPackage = 1;
        public frmAddPackage()
        {
            InitializeComponent();
        }

        private void frmAddPackage_Load(object sender, EventArgs e)
        {
            // James Straka - Will try to get these done today
            // Select package first package in database as default
            using(TravelExpertsContext db = new TravelExpertsContext())
            {
                var fp = db.Packages.Select(a => a.PackageId).First();
                firstPackage = fp;
            }
            SelectPackage(firstPackage);
            DisplayPackages();
            DisplayProducts();
        }

        private void DisplayPackages()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // Get packages from database
                var packages = db.Packages.OrderBy(p => p.PackageId).Select(p => new
                {
                    p.PackageId,
                    p.PkgName,
                    p.PkgStartDate,
                    p.PkgEndDate,
                    p.PkgDesc,
                    p.PkgBasePrice,
                    p.PkgAgencyCommission
                }).ToList();

                // Clear old combo box
                cboPackageID.Items.Clear();
                // Populate combo box with ids
                for (var i = 0; i < packages.Count; i++)
                {
                    cboPackageID.Items.Add(packages[i].PackageId);
                }

                // Populate data grid view
                dontCallSelectionEvent = true;
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
            dontCallSelectionEvent = false;

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

        private void SelectPackage(int selectedPackageID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // Load selected package using selected package ID
                selectedPackage = db.Packages.Find(selectedPackageID);
            }
            // Display package information
            cboPackageID.SelectedItem = selectedPackage.PackageId;
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
            if(succesfullAddition == false) // User is adding new package
            {
                MessageBox.Show("Please finish adding the new package details to add products!", "Finish adding package details!");
            }
            else
            {
                // Opens secondForm to add new product/supplier.
                frmAddModifyProductSupplier secondForm = new frmAddModifyProductSupplier();
                secondForm.isAdd = true; // Adding a product supplier
                secondForm.productSupplier = null; // No product supplier selected

                DialogResult result = secondForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //selectedPackageProductSupplier = secondForm.productSupplier;
                    try
                    {
                        using (TravelExpertsContext db = new TravelExpertsContext())
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
            succesfullAddition = false;
            cboPackageID.Enabled = false;
            dgvPackages.Enabled = false;
            
            txtStop.Visible = true;
            // Adds new empty package
            btnUpdate.Visible = false;
            //btnDeletePackage.Visible = false;
            btnFinish.Visible = true;
            btnCancelPackage.Visible = true;
            selectedPackage.PkgName = "";
            selectedPackage.PkgStartDate = DateTime.Now;
            selectedPackage.PkgEndDate = DateTime.Now;
            selectedPackage.PkgDesc = "";
            selectedPackage.PkgBasePrice = 0m;
            selectedPackage.PkgAgencyCommission = null;
            int mostRecentID = 0;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                //db.Packages.Add( new Package() { PkgName = selectedPackage.PkgName, PkgStartDate = selectedPackage.PkgStartDate
                //, PkgEndDate = selectedPackage.PkgEndDate, PkgDesc = selectedPackage.PkgDesc, PkgBasePrice = selectedPackage.PkgBasePrice, 
                //PkgAgencyCommission = selectedPackage.PkgAgencyCommission});
                //db.SaveChanges();
                mostRecentID = db.Packages.OrderBy(x => x.PackageId).LastOrDefault().PackageId;
            }
            selectedPackage.PackageId = mostRecentID + 1;
            cboPackageID.Text = selectedPackage.PackageId.ToString();
            txtName.Text = selectedPackage.PkgName;
            txtDescription.Text = selectedPackage.PkgDesc;
            dateStartDate.Value = DateTime.Now;
            dateEndDate.Value = DateTime.Now;
            txtBasePrice.Text = selectedPackage.PkgBasePrice.ToString();
            txtComissionPrice.Text = selectedPackage.PkgAgencyCommission.ToString();
            txtCommissionPerc.Text = "";
            
            dgvProducts.DataSource = null;
            selectedProduct = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update selected package with form information
            if(calcUpdated != true)
            {
                MessageBox.Show("Commission percentage has changed and must be recalculated! Press Calc Commission", "Commission Uncalculated");
            }
            else
            { 
            UpdatePackage(selectedPackage.PackageId);
            }

        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            
            if (succesfullAddition == false) // User is adding new package
            {
                MessageBox.Show("Please finish adding the new package details to modify products!", "Finish adding package details!");
            }
            else
            {
                // Opens second form to change selected products/supplier supplier/product.
                if (selectedProduct != null)
                {
                    frmAddModifyProductSupplier secondForm = new frmAddModifyProductSupplier();
                    secondForm.isAdd = false;
                    secondForm.productSupplier = selectedProduct;

                    DialogResult result = secondForm.ShowDialog();

                    if (result == DialogResult.OK)
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
           
           
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            // Delete selected product/supplier.
            if (succesfullAddition == false) // User is adding new package
            {
                MessageBox.Show("Please finish adding the new package details to delete products!", "Finish adding package details!");
            }
            else
            {
                if (selectedProduct != null)
                {
                    DialogResult ans = MessageBox.Show($"Are you sure you want to delete this product from package with ProductSupplierID: {selectedProduct.ProductSupplierId}? THIS CANNOT BE UNDONE!!!!",
                            "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (ans == DialogResult.Yes)
                    {
                        try
                        {
                            using (TravelExpertsContext db = new TravelExpertsContext())
                            {
                                var result = (from p in db.PackagesProductsSuppliers
                                              where p.PackageId == selectedPackage.PackageId
                                              where p.ProductSupplierId == selectedProduct.ProductSupplierId
                                              select p).SingleOrDefault();

                                db.Remove(result);
                                db.SaveChanges();
                            }
                            DisplayProducts();
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
        }

        // User selects package through data grid view
        private void dgvPackages_SelectionChanged(object sender, EventArgs e)
        {
            if (dontCallSelectionEvent == false)
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
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if(dontCallSelectionEvent == false)
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
            string strippedCommissionPerc = Regex.Replace(txtCommissionPerc.Text.ToString(), @"[^0-9.-]+", "");
            string strippedBase = Regex.Replace(txtBasePrice.Text.ToString(), @"[^0-9.]+", "");

            if (Convert.ToDecimal(strippedBase) <= 0)
            {
                MessageBox.Show("Package price cannot be less than 0 when calculating commission", "Error");
            }
            else
            {
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
                    decimal commissionTotal = (Decimal.Parse(strippedCommissionPerc) / 100) * Decimal.Parse(strippedBase);
                    selectedPackage.PkgAgencyCommission = commissionTotal;
                    txtComissionPrice.Text = Decimal.Round(selectedPackage.PkgAgencyCommission.Value, 2).ToString("c");
                    calcUpdated = true;
                }
            }
        }

        private void txtCommissionPerc_TextChanged(object sender, EventArgs e)
        {
            calcUpdated = false;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (calcUpdated != true)
            {
                MessageBox.Show("Commission percentage has changed and must be recalculated! Press Calc Commission", "Commission Uncalculated");
            }
            else
            {
                CreatePackage();
                if (succesfullAddition == true)
                {
                    btnUpdate.Visible = true;
                    //btnDeletePackage.Visible = true;
                    btnCancelPackage.Visible = false;
                    btnFinish.Visible = false;
                    cboPackageID.Enabled = true;
                    dgvPackages.Enabled = true;
                    txtStop.Visible = false;
                }
            }
        }

        private void CreatePackage()
        {
            bool validation = true;
            if (validation)
            {
                int packageIDForRedisplay = 0;
                selectedPackage.PkgName = txtName.Text;
                selectedPackage.PkgStartDate = dateStartDate.Value;
                selectedPackage.PkgEndDate = dateEndDate.Value;
                selectedPackage.PkgDesc = txtDescription.Text;
                string strippedBase = Regex.Replace(txtBasePrice.Text.ToString(), @"[^0-9.]+", "");
                selectedPackage.PkgBasePrice = Decimal.Parse(strippedBase);
                string strippedCommission = Regex.Replace(txtComissionPrice.Text.ToString(), @"[^0-9.-]+", "");
                selectedPackage.PkgAgencyCommission = Decimal.Parse(strippedCommission);
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    db.Packages.Add( new Package() { PkgName = selectedPackage.PkgName, PkgStartDate = selectedPackage.PkgStartDate
                    , PkgEndDate = selectedPackage.PkgEndDate, PkgDesc = selectedPackage.PkgDesc, PkgBasePrice = selectedPackage.PkgBasePrice, 
                    PkgAgencyCommission = selectedPackage.PkgAgencyCommission});
                    db.SaveChanges();
                    var lp = db.Packages.OrderBy(a => a.PackageId).Select(a => a.PackageId).Last();
                    packageIDForRedisplay = lp;
                }
                DisplayPackages();
                SelectPackage(packageIDForRedisplay);
                succesfullAddition = true;
            }
        }

        private void UpdatePackage(int selectedPackageId)
        {
            bool validation = true;
            if (validation)
            {
                int packageIDForRedisplay = 0;
                selectedPackage.PkgName = txtName.Text;
                selectedPackage.PkgStartDate = dateStartDate.Value;
                selectedPackage.PkgEndDate = dateEndDate.Value;
                selectedPackage.PkgDesc = txtDescription.Text;
                string strippedBase = Regex.Replace(txtBasePrice.Text.ToString(), @"[^0-9.]+", "");
                selectedPackage.PkgBasePrice = Decimal.Parse(strippedBase);
                string strippedCommission = Regex.Replace(txtComissionPrice.Text.ToString(), @"[^0-9.-]+", "");
                selectedPackage.PkgAgencyCommission = Decimal.Parse(strippedCommission);
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    Package result = (from p in db.Packages
                                      where p.PackageId == selectedPackageId
                                      select p).SingleOrDefault();
                    result.PkgName = selectedPackage.PkgName;
                    result.PkgStartDate = selectedPackage.PkgStartDate;
                    result.PkgEndDate = selectedPackage.PkgEndDate;
                    result.PkgDesc = selectedPackage.PkgDesc;
                    result.PkgBasePrice = selectedPackage.PkgBasePrice;
                    result.PkgAgencyCommission = selectedPackage.PkgAgencyCommission;
                    packageIDForRedisplay = result.PackageId;

                    db.SaveChanges();
                }
                DisplayPackages();
                SelectPackage(packageIDForRedisplay);
                succesfullAddition = true;
            }
        }

        private void cboPackageID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Get package id for selection from combo box
            int selectedPackageID = Convert.ToInt32(this.cboPackageID.GetItemText(this.cboPackageID.SelectedItem));
            // Select package with id and display information
            SelectPackage(selectedPackageID);
            DisplayProducts();
        }

        private void btnCancelPackage_Click(object sender, EventArgs e)
        {
            //using (TravelExpertsContext db = new TravelExpertsContext())
            //{
            //    Package result = (from p in db.Packages
            //                      where p.PackageId == selectedPackage.PackageId
            //                      select p).SingleOrDefault();
            //    db.Remove(result);
            //    db.SaveChanges();
            //}
            succesfullAddition = true;
            btnUpdate.Visible = true;
            //btnDeletePackage.Visible = true;
            btnCancelPackage.Visible = false;
            btnFinish.Visible = false;
            cboPackageID.Enabled = true;
            dgvPackages.Enabled = true;
            txtStop.Visible = false;
            SelectPackage(firstPackage);
            DisplayPackages();
            DisplayProducts();
           
        }

        private void btnDeletePackage_Click(object sender, EventArgs e)
        {
            //DialogResult ans = MessageBox.Show($"Are you sure you want to delete this package: {selectedPackage.PkgName}? THIS CANNOT BE UNDONE!!!!",
            //        "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //if (ans == DialogResult.Yes)
            //{
            //    using (TravelExpertsContext db = new TravelExpertsContext())
            //    {
            //        //var result2 =  from value in (db.PackagesProductsSuppliers
            //        //               orderby p.PackageId descending
            //        //               where p.PackageId == selectedPackage.PackageId
            //        //               select) );
            //        //
            //        //if (result2 != null)
            //        //{
            //        //    db.Remove(result2);
            //        //    db.SaveChanges();
            //        //}
            //
            //        Package result = (from p in db.Packages
            //                          where p.PackageId == selectedPackage.PackageId
            //                          select p).SingleOrDefault();
            //        db.Remove(result);
            //        db.SaveChanges();
            //    }
            //    SelectPackage(firstPackage);
            //    DisplayPackages();
            //    DisplayProducts();
            //}
        }
    }
}
