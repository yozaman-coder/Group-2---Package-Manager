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
    /* Package Form
     * 
     * Allows user to create new package and modify packages in database also routes to ProductSupplier forms and adds new products
     * Author: James Straka 
     * When: Jan-Feb2022
     * 
     */
    public partial class frmAddPackage : Form
    {
        // Declaring class level variables
        Package selectedPackage = null; 
        ProductsSupplier selectedProductSupplier = null;
        decimal? commissionPercentage = null; 
        bool calcUpdated = true; // For tracking if calculation is up to date
        bool succesfullAddition = true; // Used for tracking state of form for denying access to UI
        // Selection event kept getting called when database was updating so made this to stop the selection event
        bool dontCallSelectionEvent = false;
        int firstPackage = 1; //Default package
        // Brett - added a new property to receive the ID of the ProductSupplier combination from the AddModifyProductSupplier form. Need to find a way to append it to the products list for the selected package.
        public string newProdSupp
        {
            set { lblReceivedProdSupp.Text = value; } // Brett - I just set this to an invisible text label right now. Probably a better place for this value to be stored...
        }
        

        public frmAddPackage()
        {
            InitializeComponent();
        }

        private void frmAddPackage_Load(object sender, EventArgs e)
        {
            try
            {
                //Make sure to load the first package. This is important because the first package could have been deleted
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    var fp = db.Packages.Select(a => a.PackageId).First();
                    firstPackage = fp;
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
            // Select the first package
            SelectPackage(firstPackage);
            // Display package and its products
            DisplayPackages();
            DisplayProducts();
        }

        private void DisplayPackages()
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    // Get all packages from database
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

                    // Populate data grid view and don't call the selection event when doing so
                    dontCallSelectionEvent = true;
                    dgvPackages.DataSource = packages;
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
            // You can now call the selection event again
            dontCallSelectionEvent = false;

        }

        private void DisplayProducts()
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    // Select and display Product supplier ID, Product Name, and Supplier Name
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
                    dgvProducts.DataSource = productsList; // Give the data grid view the packages
                    dgvProducts.ClearSelection();
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
            // Style for alternating rows
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Makes sure user cannot select multiple rows or select individual components
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            
        }

        private void SelectPackage(int selectedPackageID)
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    // Load selected package using selected package ID
                    selectedPackage = db.Packages.Find(selectedPackageID);
                }
            }
            catch (DbUpdateException ex)
            {
                HandleDatabaseError(ex);
            }
            catch (Exception ex)
            {
                HandleGeneralError(ex);
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
                // Display comission
                txtComissionPrice.Text = selectedPackage.PkgAgencyCommission?.ToString("c");
                // Display commission as percentage rounded up
                commissionPercentage = (selectedPackage.PkgAgencyCommission / selectedPackage.PkgBasePrice);
                txtCommissionPerc.Text = Decimal.Round(commissionPercentage.Value*100, 2).ToString();
                calcUpdated = true; // The commission calculation is up to date
            }
            else // There is no commission
            {
                txtComissionPrice.Text = 0.ToString("c");
                txtCommissionPerc.Text = 0.ToString();
                calcUpdated = true; // The commission calculation is up to date
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
                    try
                    {
                        using (TravelExpertsContext db = new TravelExpertsContext())
                        {
                            // Sets up new packages product supplier bridge table 
                            PackagesProductsSupplier newProd = new PackagesProductsSupplier();
                            // Use package ID from selected package
                            newProd.PackageId = selectedPackage.PackageId;
                            // And product supplier id from product supplier from ProductSupplier form
                            newProd.ProductSupplierId = secondForm.productSupplier.ProductSupplierId;
                            // Add new prod as new product to package
                            db.PackagesProductsSuppliers.Add(newProd);
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
            // A new package is being created so we disable some elements so the user cant fuck everything up.
            succesfullAddition = false;
            cboPackageID.Enabled = false;
            dgvPackages.Enabled = false;
            txtStop.Visible = true;
            // No longer update, now the finish button is available
            btnUpdate.Visible = false;
            btnFinish.Visible = true;
            btnCancelPackage.Visible = true; // Show cancel button
            //btnDeletePackage.Visible = false;

            // Set up some default values for new package.
            selectedPackage.PkgName = "";
            selectedPackage.PkgStartDate = DateTime.Now;
            selectedPackage.PkgEndDate = DateTime.Now;
            selectedPackage.PkgDesc = "";
            selectedPackage.PkgBasePrice = 0m;
            selectedPackage.PkgAgencyCommission = null;
            int mostRecentID = 0;
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    //db.Packages.Add( new Package() { PkgName = selectedPackage.PkgName, PkgStartDate = selectedPackage.PkgStartDate
                    //, PkgEndDate = selectedPackage.PkgEndDate, PkgDesc = selectedPackage.PkgDesc, PkgBasePrice = selectedPackage.PkgBasePrice, 
                    //PkgAgencyCommission = selectedPackage.PkgAgencyCommission});
                    //db.SaveChanges();

                    // Get the most recent ID from database for incrementing
                    mostRecentID = db.Packages.OrderBy(x => x.PackageId).LastOrDefault().PackageId;
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

            // Increment package ID by 1 and assign it to the selectedPackage
            selectedPackage.PackageId = mostRecentID + 1;
            // Display default values
            cboPackageID.Text = selectedPackage.PackageId.ToString();
            txtName.Text = selectedPackage.PkgName;
            txtDescription.Text = selectedPackage.PkgDesc;
            dateStartDate.Value = DateTime.Now;
            dateEndDate.Value = DateTime.Now;
            txtBasePrice.Text = selectedPackage.PkgBasePrice.ToString();
            txtComissionPrice.Text = selectedPackage.PkgAgencyCommission.ToString();
            txtCommissionPerc.Text = "";
            // Clear datasource and reset selected product supplier
            dgvProducts.DataSource = null;
            selectedProductSupplier = null;
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
                if (selectedProductSupplier != null)
                {
                    frmAddModifyProductSupplier secondForm = new frmAddModifyProductSupplier();
                    secondForm.isAdd = false; // Tells second form that this is a modify action
                    secondForm.productSupplier = selectedProductSupplier;

                    DialogResult result = secondForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        try
                        {
                            using (TravelExpertsContext db = new TravelExpertsContext())
                            {
                                try 
                                {
                                    // Selects old product and deletes it from the package
                                    var oldPckgsPrdSpl = (from p in db.PackagesProductsSuppliers
                                                          where p.PackageId == selectedPackage.PackageId
                                                          where p.ProductSupplierId == selectedProductSupplier.ProductSupplierId
                                                          select p).SingleOrDefault();

                                    db.PackagesProductsSuppliers.Remove(oldPckgsPrdSpl);
                                    db.SaveChanges();
                                }
                                catch (DbUpdateException ex)
                                {
                                    this.HandleDatabaseError(ex);
                                }
                                catch (Exception ex)
                                {
                                    this.HandleGeneralError(ex);
                                }
                               
                                // Sets up new packages product supplier bridge table 
                                PackagesProductsSupplier newProd = new PackagesProductsSupplier();
                                // Use package ID from selected package
                                newProd.PackageId = selectedPackage.PackageId;
                                // And product supplier id from product supplier from ProductSupplier form
                                newProd.ProductSupplierId = secondForm.productSupplier.ProductSupplierId;
                                // Update package with new product
                                db.PackagesProductsSuppliers.Add(newProd);
                                db.SaveChanges();
                                // Re-displays products for selected package
                                DisplayProducts();
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
                else // Just in case something weird happens
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
                if (selectedProductSupplier != null) // Product supplier is selected
                {
                    // Confirm if user wants to delete the product from the package
                    DialogResult ans = MessageBox.Show($"Are you sure you want to delete this product from package with ProductSupplierID: {selectedProductSupplier.ProductSupplierId}? THIS CANNOT BE UNDONE!!!!",
                            "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (ans == DialogResult.Yes) // user confirms
                    {
                        try // Try to delete the product from the package
                        {
                            using (TravelExpertsContext db = new TravelExpertsContext())
                            {
                                var result = (from p in db.PackagesProductsSuppliers
                                              where p.PackageId == selectedPackage.PackageId
                                              where p.ProductSupplierId == selectedProductSupplier.ProductSupplierId
                                              select p).SingleOrDefault();

                                db.Remove(result);
                                db.SaveChanges();
                            }
                            // Re-display products
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
            // If application is not needing the selection event to be called don't do anything
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
            // If application is not needing the selection event to be called don't do anything
            if (dontCallSelectionEvent == false)
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
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    // Load selected product using selected product ID
                    selectedProductSupplier = db.ProductsSuppliers.Find(selectedProductSupplierID);
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

        // Calculates commission using a percentage
        private void btnCalcCommission_Click(object sender, EventArgs e)
        {
            // Strip comission percentage and base of everything but numbers and .
            // Could of probably just parsed but this is the way I did it lol
            string strippedCommissionPerc = Regex.Replace(txtCommissionPerc.Text.ToString(), @"[^0-9.-]+", "");
            string strippedBase = Regex.Replace(txtBasePrice.Text.ToString(), @"[^0-9.]+", "");
            decimal tmpValue;
            decimal? decCommissionPerc = 0;
            // Sets decComissionPerc to 0 if null or unable to parse or uses parsed value if not null
            if (Decimal.TryParse(strippedCommissionPerc, out tmpValue))
                decCommissionPerc = tmpValue; 

            if (Convert.ToDecimal(strippedBase) <= 0) // Checks to see if base value is 0 before calculating
            {
                MessageBox.Show("Package price cannot be less than 0 when calculating commission", "Error");
            }
            else // Base is not 0
            {
                if (decCommissionPerc == 0 | strippedCommissionPerc == "") // if commission percentage is null
                {
                    selectedPackage.PkgAgencyCommission = null;
                    txtComissionPrice.Text = 0.ToString("c");
                    calcUpdated = true; // Calc is up to date
                }
                else if (decCommissionPerc < 1 | decCommissionPerc > 50) // Checks if comission precent is less than 1 or greater than 50
                {
                    MessageBox.Show("Commission percent cannot be less than 1 or greater than 50", "Error");
                }
                else // There is a comission percentage
                {
                    // Calc commission total
                    decimal commissionTotal = (Decimal.Parse(strippedCommissionPerc) / 100) * Decimal.Parse(strippedBase);
                    selectedPackage.PkgAgencyCommission = commissionTotal; // Assign commission to selected package
                    // Display selected package commission
                    txtComissionPrice.Text = Decimal.Round(selectedPackage.PkgAgencyCommission.Value, 2).ToString("c");
                    calcUpdated = true; // Calc is up to date
                }
            }
        }

        private void txtCommissionPerc_TextChanged(object sender, EventArgs e)
        {
            // If user changes commission percentage the calc is no longer up to date
            calcUpdated = false; 
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (calcUpdated != true) // Checks if commission percentage is up to date
            {
                MessageBox.Show("Commission percentage has changed and must be recalculated! Press Calc Commission", "Commission Uncalculated");
            }
            else
            {
                CreatePackage();
                if (succesfullAddition == true) // Package creation was succesfull
                {
                    // Return user to default view and enable controls
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
            // Validate package information
            if (Validator.StringIsWithinRange(txtName, 1, 50) &&
                Validator.StringIsWithinRange(txtDescription, 1, 50) &&
                Validator.DecimalIsWithinRange(txtBasePrice, 10, 1000000000) &&
                Validator.DateTimeIsWithinRange(dateStartDate, dateStartDate.MinDate, dateEndDate.Value) &&
                Validator.DateTimeIsWithinRange(dateEndDate, dateStartDate.Value, dateEndDate.MaxDate))
            {
                int packageIDForRedisplay = 0;
                // Assign selected package the data from the text fields
                selectedPackage.PkgName = txtName.Text;
                selectedPackage.PkgStartDate = dateStartDate.Value;
                selectedPackage.PkgEndDate = dateEndDate.Value;
                selectedPackage.PkgDesc = txtDescription.Text;
                string strippedBase = Regex.Replace(txtBasePrice.Text.ToString(), @"[^0-9.]+", "");
                selectedPackage.PkgBasePrice = Decimal.Parse(strippedBase);
                string strippedCommission = Regex.Replace(txtComissionPrice.Text.ToString(), @"[^0-9.-]+", "");
                decimal commissionDecimal = Decimal.Parse(strippedCommission);
                if (commissionDecimal == 0m) // Commission is null
                {
                    selectedPackage.PkgAgencyCommission = null; // assign null to selected package
                }
                else
                {
                    selectedPackage.PkgAgencyCommission = commissionDecimal;
                }
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        // Add new package to db with selectedPackage details
                        db.Packages.Add(new Package()
                        {
                            PkgName = selectedPackage.PkgName,
                            PkgStartDate = selectedPackage.PkgStartDate,
                            PkgEndDate = selectedPackage.PkgEndDate,
                            PkgDesc = selectedPackage.PkgDesc,
                            PkgBasePrice = selectedPackage.PkgBasePrice,
                            PkgAgencyCommission = selectedPackage.PkgAgencyCommission
                        });
                        db.SaveChanges();
                        // Select last package from db
                        var lp = db.Packages.OrderBy(a => a.PackageId).Select(a => a.PackageId).Last();
                        packageIDForRedisplay = lp;
                        succesfullAddition = true; // Db add made it this far so the addition of new package must be succesfull
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

                DisplayPackages();
                // Select last package from db which should be the one that was just added
                SelectPackage(packageIDForRedisplay);
                DisplayProducts();
                selectedProductSupplier = null;
            }
        }

        private void UpdatePackage(int selectedPackageId)
        {
            // Validate package information
            if (Validator.StringIsWithinRange(txtName, 1, 50) &&
                Validator.StringIsWithinRange(txtDescription, 1, 50) &&
                Validator.DecimalIsWithinRange(txtBasePrice, 10, 1000000000) &&
                Validator.DateTimeIsWithinRange(dateStartDate, dateStartDate.MinDate, dateEndDate.Value) &&
                Validator.DateTimeIsWithinRange(dateEndDate, dateStartDate.Value, dateEndDate.MaxDate))
            {
                int packageIDForRedisplay = 0;
                // Assign selected package the data from the text fields
                selectedPackage.PkgName = txtName.Text;
                selectedPackage.PkgStartDate = dateStartDate.Value;
                selectedPackage.PkgEndDate = dateEndDate.Value;
                selectedPackage.PkgDesc = txtDescription.Text;
                string strippedBase = Regex.Replace(txtBasePrice.Text.ToString(), @"[^0-9.]+", "");
                selectedPackage.PkgBasePrice = Decimal.Parse(strippedBase);
                string strippedCommission = Regex.Replace(txtComissionPrice.Text.ToString(), @"[^0-9.-]+", "");
                decimal commissionDecimal = Decimal.Parse(strippedCommission);
                if(commissionDecimal == 0m)// Commission is null
                {
                    selectedPackage.PkgAgencyCommission = null;
                }
                else
                {
                    selectedPackage.PkgAgencyCommission = commissionDecimal;
                }
                try
                {
                    // Updates package with new information and then saves changes to package
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
                        succesfullAddition = true; // Update was succesfull
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
               
                DisplayPackages();
                // Displays updated package
                SelectPackage(packageIDForRedisplay);
                DisplayProducts();
                selectedProductSupplier = null;
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

        // Cancels out of adding new package and redisplays first package
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
        // Allows user to delete packages although disabled for now as I realise that you would not want to delete a package that has been booked
        // because you would lose information on that booking. Could make a check for that and enable later.
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

        private void txtBasePrice_TextChanged(object sender, EventArgs e)
        {
            if(txtComissionPrice.Text != "$0.00")
            {
                calcUpdated = false; // If base price is changed calc is no longer up to date
            }
        }
    }
}
