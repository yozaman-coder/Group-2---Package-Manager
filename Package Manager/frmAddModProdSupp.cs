/* Add/Modify ProductSupplier Form - Add products, and associated supplier, to the travel package. Modify products/suppliers than are currently in a travel package.
 * Author: Brett Dawson
 * Created: January 21, 2022
 * Last Updated: February 20, 2022
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductData;

namespace Package_Manager
{
    public partial class frmAddModProdSupp : Form
    {
        public Product selectedProduct;
        public Supplier selectedSupplier;
        public Product product;
        public Supplier supplier;
        public ProductsSupplier productSupplier;
        public bool isAdd;
        public int supplierID = 0;
        public int productID = 0;
        public int selectedProdID = 1;
        public int selectedSuppID = 1;
        // Brett - added public property to get selected product ID for use in frmAddModifyProduct
        public int SelectedProdID
        { get { return selectedProdID; } }

        // Brett - added public property to get selected supplier ID for use in frmAddModifySupplier
        public int SelectedSupplierID
        { get { return selectedSuppID; } }

        public frmAddModProdSupp()
        {
            InitializeComponent();
        }

        private void frmAddModProdSupp_Load(object sender, EventArgs e)
        {
            DisplayProducts();

            if (isAdd)
            {
                this.Text = "Add Product Supplier";
                btnAddProductToPackage.Text = "Add product to package";
            }
            else
            {
                this.Text = "Modify Product Supplier";
                btnAddProductToPackage.Text = "Confirm changes";
                if (productSupplier == null)
                {
                    MessageBox.Show("There is no product supplier selected!", "Modify Error");
                    this.Close();
                }
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex_Prod = (int)dgvProducts.Rows[e.RowIndex].Cells[0].Value;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var selectedProduct = db.Products.Find(selectedIndex_Prod);
                selectedProdID = selectedProduct.ProductId;
            }

            dgvSuppliers.DataSource = SelectSuppFromProdID(selectedProdID);
            dgvSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.MultiSelect = false;
            dgvSuppliers.RowHeadersVisible = false;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Consolas", 10, FontStyle.Bold);
            dgvSuppliers.Columns[0].Width = 50;
            dgvSuppliers.Columns[1].Width = 400;
            dgvSuppliers.Columns[2].Width = 0;
            dgvSuppliers.Columns[3].Width = 0;
        }
        // Brett - generate list of suppliers from the ProductSupplier table that have the passed-in Product ID
        private List<Supplier> SelectSuppFromProdID(int prodID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var suppliers = db.ProductsSuppliers.Where(ps => ps.ProductId == prodID).Select(s => s.Supplier).ToList();
                return suppliers;
            }
        }
        private void btnNewProduct_Click_1(object sender, EventArgs e)
        {
            // Brett - changed this to have the new product function moved to the AddModifyProduct form
            frmAddModifyProduct addProductForm = new frmAddModifyProduct();
            addProductForm.AddProduct = true;
            addProductForm.ShowDialog();
            if(addProductForm.DialogResult == DialogResult.OK)
            {
                DisplayProducts();
            }
        }

        private void btnNewSupplier_Click_1(object sender, EventArgs e)
        {
            // Brett - modified to redirect to frmAddModifySupplier for addition of new supplier
            frmAddModifySupplier addSupplierForm = new frmAddModifySupplier();
            addSupplierForm.AddSupplier = true;
            addSupplierForm.ShowDialog();
            if (addSupplierForm.DialogResult == DialogResult.OK)
            {
                DisplayProducts();
            }
        }

        private void dgvSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex_Supp = (int)dgvSuppliers.Rows[e.RowIndex].Cells[0].Value;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var selectedSupp = db.Suppliers.Find(selectedIndex_Supp);
                selectedSuppID = selectedSupp.SupplierId;
            }

        }
        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            // Brett - changed this to have the modify product function moved to the AddModifyProduct form
            frmAddModifyProduct modForm = new frmAddModifyProduct();
            //modForm.getselectedProdID = SelectedProdID;
            modForm.ShowDialog();
        }

        private void btnSupplierModify_Click(object sender, EventArgs e)
        {
            // Brett - changed this to have the modify supplier function moved to the AddModifySupplier form

            frmAddModifySupplier modForm = new frmAddModifySupplier();
            //modForm.getselectedSupplierID = SelectedSupplierID;
            modForm.ShowDialog();
        }

        private void DisplayProducts()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var products = db.Products.Select(p => new
                {
                    p.ProductId,
                    p.ProdName
                }).ToList();

                dgvProducts.DataSource = products;
                dgvProducts.ClearSelection();
            }
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Consolas", 10, FontStyle.Bold);
            dgvProducts.Columns[dgvProducts.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DisplayProductSupplier()
        {
            productID = selectedProdID;
            supplierID = selectedSuppID;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                try
                {
                    var ProdSup = (from ps in db.ProductsSuppliers
                                   where ps.ProductId == productID &&
                                   ps.SupplierId == supplierID
                                   select ps);
                    if (ProdSup.FirstOrDefault() == null)
                    {
                        try
                        {
                            ProductsSupplier newProdSup = new ProductsSupplier();
                            newProdSup.ProductId = productID;
                            newProdSup.SupplierId = supplierID;
                            db.ProductsSuppliers.Add(newProdSup);
                            db.SaveChanges();
                            var newnewProdSup = db.ProductsSuppliers.Where(p => p.ProductId == productID && p.SupplierId == supplierID).FirstOrDefault();
                            productSupplier = newnewProdSup;
                        }
                        catch (DbUpdateConcurrencyException ex)
                        { HandleConcurrencyError(ex); }
                        catch (DbUpdateException ex)
                        { HandleDatabaseError(ex); }
                        catch (Exception ex)
                        { HandleGeneralError(ex); }
                    }
                    else
                    {
                        productSupplier = ProdSup.FirstOrDefault();
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
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

        private void btnAddProductToPackage_Click_1(object sender, EventArgs e)
        {
            // Brett - added code for this method, it was incomplete. Now creates a new instance of the AddPackage class/form and passes the Selected ProductSupplier ID to it via the new public property SelectedProdSupp. 
            DisplayProductSupplier();
            frmAddPackage addToPackage = new frmAddPackage();
            this.DialogResult = DialogResult.OK;
        }

        private void btnNewProdSupply_Click(object sender, EventArgs e)
        {
            return;
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

        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {

            using (TravelExpertsContext context = new TravelExpertsContext())
            {
                ex.Entries.Single().Reload();
                var state = context.Entry(selectedProduct).State;
                if (state == EntityState.Detached)
                {
                    MessageBox.Show("another user has deleted selected product", "concurrency error");
                }
                else
                {
                    string message = "another user has updated selected product.\n" + "the current database values will be displayed.";
                    MessageBox.Show(message, "concurrency error");
                }
            }
            this.DisplayProducts();
        }
        //private void JoinedProdSuppNames()
        //{
        //    using (TravelExpertsContext db = new TravelExpertsContext())
        //    {
        //        var joinedTable =
        //        (from prodsupp in db.ProductsSuppliers
        //         join prod in db.Products on prodsupp.ProductId equals prod.ProductId
        //         join supp in db.Suppliers on prodsupp.SupplierId equals supp.SupplierId
        //         select new
        //         {
        //             ProductID = prod.ProductId,
        //             ProductName = prod.ProdName,
        //             SupplierID = supp.SupplierId,
        //             SupplierName = supp.SupName
        //         }).ToList();
        //    }
        //}
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProdSup_Click(object sender, EventArgs e)
        {
            frmAddProdSup secondForm = new frmAddProdSup();
            DialogResult result = secondForm.ShowDialog();
            if (result == DialogResult.OK) // New product supplier was added
            {
                DisplayProducts(); // Update display
                using(TravelExpertsContext db = new TravelExpertsContext())
                {
                    // Get newest products supplier id and Product name
                    int id = db.ProductsSuppliers.OrderBy(p => p.ProductSupplierId).Select(p => p.ProductId).LastOrDefault().Value;
                    string idName = db.ProductsSuppliers.OrderBy(p => p.ProductSupplierId).Select(p => p.Product.ProdName).LastOrDefault().ToString();
                    foreach(DataGridViewRow row in dgvProducts.Rows) // Search DGV for name of product
                    {
                        if(row.Cells[1].Value.ToString().Equals(idName)) // Find product name
                        {
                            row.Selected = true; // Selects that row
                            dgvSuppliers.DataSource = SelectSuppFromProdID(id);// Updates supplier data grid view
                        }
                    }
                    

                }
               
                MessageBox.Show("Products supplier added successfully!");
                //using (TravelExpertsContext db = new TravelExpertsContext())
                //{
                //    db.Add(secondForm.newProductSupplier);
                //}
            }
        }
    }
}
//private void SelectProduct(int selectedProductID)
//{
//    using (TravelExpertsContext db = new TravelExpertsContext())
//    {
//        // Load selected product using selected product ID
//        selectedProduct = db.Products.Find(selectedProductID);
//    }
//    // Display product information
//    int selectedProduct = dgvProducts.Rows.ProductId.ToString();
//    //txtProductName.Text = selectedProduct.ProdName;
//}

//private void SelectSupplier(int selectedSupplierID)
//{
//    using (TravelExpertsContext db = new TravelExpertsContext())
//    {
//        // Load selected product using selected product ID
//        selectedSupplier = db.Suppliers.Find(selectedSupplierID);
//    }
//    // Display product information
//    //cboSupplierID.Text = selectedSupplier.SupplierId.ToString();
//    //txtSupplierName.Text = selectedSupplier.SupName;
//}