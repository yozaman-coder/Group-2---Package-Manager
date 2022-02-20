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
        private Supplier selectedSupplier;
        public Product product;
        public Supplier supplier;
        public ProductsSupplier productSupplier;
        public bool isAdd;
        public int supplierID = 0;
        public int productID = 0;
        // Brett - added public property to get selected product ID for use in frmAddModifyProduct
        public int SelectedProdID
        { get; set; }
    
        // Brett - added public property to get selected supplier ID for use in frmAddModifySupplier
        //public string SelectedSupplierID
        //{get { return ; }}
        
        public frmAddModProdSupp()
        {
            InitializeComponent();
        }

        private void frmAddModProdSupp_Load(object sender, EventArgs e)
        {
            DisplayProducts();
            //DisplaySuppliers();
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
                // Display current product supplier
                //dgvProducts = productSupplier.ProductId;
                //dgvSuppliers = productSupplier.SupplierId;
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = (int)dgvProducts.Rows[e.RowIndex].Cells[0].Value;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var selectedProduct = db.Products.Find(selectedIndex);
                int selectedProdID = selectedProduct.ProductId;
            }
            
            dgvSuppliers.DataSource = SelectSuppFromProdID(selectedIndex);
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
        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            // Brett - modified to redirect to frmAddModifySupplier for addition of new supplier
            frmAddModifySupplier addSupplierForm = new frmAddModifySupplier();
            addSupplierForm.AddSupplier = true;
            addSupplierForm.ShowDialog();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            // Brett - changed this to have the new product function moved to the AddModifyProduct form
            frmAddModifyProduct addProductForm = new frmAddModifyProduct();
            addProductForm.AddProduct = true;
            addProductForm.ShowDialog();
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

        private void btnAddProductToPackage_Click(object sender, EventArgs e)
        {
            // Brett - added code for this method, it was incomplete. Now creates a new instance of the AddPackage class/form and passes the Selected ProductSupplier ID to it via the new public property SelectedProdSupp. 
            //DisplayProductSupplier();
            frmAddPackage addToPackage = new frmAddPackage();
            this.DialogResult = DialogResult.OK;
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

        private void SelectSupplier(int selectedSupplierID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // Load selected product using selected product ID
                selectedSupplier = db.Suppliers.Find(selectedSupplierID);
            }
            // Display product information
            //cboSupplierID.Text = selectedSupplier.SupplierId.ToString();
            //txtSupplierName.Text = selectedSupplier.SupName;
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
               
        private void JoinedProdSuppNames()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var joinedTable =
                (from prodsupp in db.ProductsSuppliers
                 join prod in db.Products on prodsupp.ProductId equals prod.ProductId
                 join supp in db.Suppliers on prodsupp.SupplierId equals supp.SupplierId
                 select new
                 {
                     ProductID = prod.ProductId,
                     ProductName = prod.ProdName,
                     SupplierID = supp.SupplierId,
                     SupplierName = supp.SupName
                 }).ToList();
            }
        }
        
        //private void DisplayProductSupplier()
        //{
        //    supplierID = Convert.ToInt32(lstSuppliers.SelectedItem.ToString());
        //    productID = Convert.ToInt32(lstProducts.SelectedItem.ToString());


        //    using (TravelExpertsContext db = new TravelExpertsContext())
        //    {
        //        try
        //        {
        //            var ProdSup = (from ps in db.ProductsSuppliers
        //                           where ps.ProductId == productID &&
        //                           ps.SupplierId == supplierID
        //                           select ps);

        //            if (ProdSup.FirstOrDefault() == null)
        //            {
        //                try
        //                {
        //                    ProductsSupplier newProdSup = new ProductsSupplier();
        //                    newProdSup.ProductId = productID;
        //                    newProdSup.SupplierId = supplierID;
        //                    db.ProductsSuppliers.Add(newProdSup);
        //                    db.SaveChanges();
        //                    var newnewProdSup = db.ProductsSuppliers.Where(p => p.ProductId == productID && p.SupplierId == supplierID).FirstOrDefault();
        //                    productSupplier = newnewProdSup;

        //                }
        //                catch (DbUpdateConcurrencyException ex)
        //                {
        //                    HandleConcurrencyError(ex);
        //                }
        //                catch (DbUpdateException ex)
        //                {
        //                    HandleDatabaseError(ex);
        //                }
        //                catch (Exception ex)
        //                {
        //                    HandleGeneralError(ex);
        //                }
        //            }

        //            else
        //            {
        //                productSupplier = ProdSup.FirstOrDefault();

        //            }
        //        }
        //        catch (DbUpdateConcurrencyException ex)
        //        {
        //            HandleConcurrencyError(ex);
        //        }
        //        catch (DbUpdateException ex)
        //        {
        //            HandleDatabaseError(ex);
        //        }
        //        catch (Exception ex)
        //        {
        //            HandleGeneralError(ex);
        //        }
        //    }
        //}

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
