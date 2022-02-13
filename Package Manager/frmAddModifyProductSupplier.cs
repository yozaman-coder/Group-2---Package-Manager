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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Package_Manager
{
    public partial class frmAddModifyProductSupplier : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext();
        public Product selectedProduct;
        private Supplier selectedSupplier;
        public Product product;
        public Supplier supplier;
        public ProductsSupplier productSupplier;
        public bool isAdd;
        public int supplierID = 0;
        public int productID = 0;
                
        // Brett - added public property to get selected product ID for use in frmAddModifyProduct
        public string SelectedProdID
        {
            get { return cboProductID.Text; }
        }

        // Brett - added public property to get selected supplier ID for use in frmAddModifySupplier
        public string SelectedSupplierID
        {
            get { return cboSupplierID.Text; }
        }

        // Brett - added public property to get the combined ProductSupplier ID for use in frmAddModifyPackage
        public string SelectedProdSupp
        {
            get { return lblProdSupID.Text; }
        }

        public frmAddModifyProductSupplier()
        {
            InitializeComponent();
        }

        private void frmAddModifyProductSupplier_Load(object sender, EventArgs e)
        {
            DisplayProducts();
            DisplaySuppliers();
            if(isAdd)
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
                cboProductID.SelectedItem = productSupplier.ProductId;
                cboSupplierID.SelectedItem = productSupplier.SupplierId;
            }
        }

        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get product ID for selection from combo box
            int selectedProductID = Convert.ToInt32(this.cboProductID.GetItemText(this.cboProductID.SelectedItem));
            // Select product with id and display information
            SelectProduct(selectedProductID);
        }

        private void cboSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get supplier ID for selection from combo box
            int selectedSupplierID = Convert.ToInt32(this.cboSupplierID.GetItemText(this.cboSupplierID.SelectedItem));
            // Select supplier with id and display information
            SelectSupplier(selectedSupplierID);
        }


        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            // Brett - modified to redirect to frmAddModifySupplier for addition of new supplier
            frmAddModifySupplier addSupplierForm = new frmAddModifySupplier();
            addSupplierForm.AddSupplier = true;
            addSupplierForm.Show();
            
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            // Brett - changed this to have the new product function moved to the AddModifyProduct form
            frmAddModifyProduct addProductForm = new frmAddModifyProduct();
            addProductForm.AddProduct = true;
            addProductForm.Show();
        }
        

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            // Brett - changed this to have the modify product function moved to the AddModifyProduct form
            frmAddModifyProduct modForm = new frmAddModifyProduct();
            modForm.getselectedProdID = SelectedProdID;
            modForm.Show();
            
                
                //AddProduct = false,
                //Products = selectedProduct
        }
        

        private void btnSupplierModify_Click(object sender, EventArgs e)
        {
            // Brett - changed this to have the modify supplier function moved to the AddModifySupplier form

            frmAddModifySupplier modForm = new frmAddModifySupplier();
            modForm.getselectedSupplierID = SelectedSupplierID;
            modForm.Show();
        }

        private void btnAddProductToPackage_Click(object sender, EventArgs e)
        {
            // Brett - added code for this method, it was incomplete. Now creates a new instance of the AddPackage class/form and passes the Selected ProductSupplier ID to it via the new public property SelectedProdSupp. 
            frmAddPackage addPackage = new frmAddPackage();
            addPackage.newProdSupp = SelectedProdSupp;
            addPackage.Show();
            
        }
                

        private void LoadSupplierData()
        {
            supplier.SupplierId = cboSupplierID.SelectedIndex;
            supplier.SupName = txtSupplierName.Text;
        }

        private void LoadProductData()
        {
            product.ProductId = cboProductID.SelectedIndex;
            product.ProdName = txtProductName.Text;
        }


        private void SelectProduct(int selectedProductID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // Load selected product using selected product ID
                selectedProduct = db.Products.Find(selectedProductID);
            }
            // Display product information
            cboProductID.Text = selectedProduct.ProductId.ToString();
            txtProductName.Text = selectedProduct.ProdName;
        }

        private void SelectSupplier(int selectedSupplierID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // Load selected product using selected product ID
                selectedSupplier = db.Suppliers.Find(selectedSupplierID);
            }
            // Display product information
            cboSupplierID.Text = selectedSupplier.SupplierId.ToString();
            txtSupplierName.Text = selectedSupplier.SupName;
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

                for (var i = 0; i < products.Count; i++)
                {
                    cboProductID.Items.Add(products[i].ProductId);
                }
            }
        }


        private void DisplaySuppliers()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var suppliers = db.Suppliers.Select(s => new
                {
                    s.SupplierId,
                    s.SupName
                }).ToList();

                for (var i = 0; i < suppliers.Count; i++)
                {
                    cboSupplierID.Items.Add(suppliers[i].SupplierId);
                }
            }
        }

        private void DisplayProductSupplier()
        {
            supplierID = Convert.ToInt32(cboSupplierID.Text);
            productID = Convert.ToInt32(cboProductID.Text);


            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                try
                {
                    var ProdSup = (from ps in db.ProductsSuppliers
                                  where ps.ProductId == productID
                                  where ps.SupplierId == supplierID
                                  select ps.ProductSupplierId);
                    
                    if (ProdSup.FirstOrDefault() == 0)
                    {
                        try
                        {
                            ProductsSupplier newProdSup = new ProductsSupplier();
                            newProdSup.ProductId = productID;
                            newProdSup.SupplierId = supplierID;
                            db.ProductsSuppliers.Add(newProdSup);
                            db.SaveChanges();

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

                    else
                        lblProdSupID.Text = ProdSup.FirstOrDefault().ToString();
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
            this.DisplayProducts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayProducts();
            DisplaySuppliers();

        }

        private void btnCheckProdSup_Click(object sender, EventArgs e)
        {
            DisplayProductSupplier();
        }
    }
}
//frmAddModifySupplier addSupplierForm = new frmAddModifySupplier();
//addSupplierForm.AddSupplier = true;
//DialogResult result = addSupplierForm.ShowDialog();
//if (result == DialogResult.OK)
//{
//    try
//    {
//        selectedSupplier = addSupplierForm.Suppliers;
//        context.Suppliers.Add(selectedSupplier);
//        context.SaveChanges();
//        this.DisplaySuppliers();
//    }

//    catch (DbUpdateException ex)
//    {
//        HandleDatabaseError(ex);
//    }
//    catch (Exception ex)
//    {
//        HandleGeneralError(ex);
//    }
//}

//DialogResult result = addProductForm.ShowDialog();
//if (result == DialogResult.OK)
//{
//    try
//    {
//        selectedProduct = addProductForm.Products;
//        context.Products.Add(selectedProduct);
//        context.SaveChanges();
//        this.DisplayProducts();
//    }

//    catch (DbUpdateException ex)
//    {
//        HandleDatabaseError(ex);
//    }
//    catch (Exception ex)
//    {
//        HandleGeneralError(ex);
//    }


//DialogResult result = addModifyProductForm.ShowDialog();
//    if (result == DialogResult.OK)
//    {
//        try
//        {
//            selectedProduct = addModifyProductForm.Products; // Brett - I think this needs to work the other way around. The selectedProduct needs to come from this form, then it can be modified via frmAddModifyProduct. Do you agree?
//            context.SaveChanges();
//            DisplayProducts();
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

//var addModifySupplierForm = new frmAddModifySupplier()
//{
//    AddSupplier = false,
//    Suppliers = selectedSupplier
//};

//DialogResult result = addModifySupplierForm.ShowDialog();
//if (result == DialogResult.OK)
//{
//    try
//    {
//        selectedSupplier = addModifySupplierForm.Suppliers;
//        context.SaveChanges();
//        DisplaySuppliers();
//    }
//            catch (DbUpdateConcurrencyException ex)
//            {
//                HandleConcurrencyError(ex);
//    }
//            catch (DbUpdateException ex)
//            {
//                HandleDatabaseError(ex);
//}
//            catch (Exception ex)
//{
//    HandleGeneralError(ex);
//}
//}