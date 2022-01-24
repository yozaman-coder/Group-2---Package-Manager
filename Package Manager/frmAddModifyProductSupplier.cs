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
        private Product selectedProduct;
        private Supplier selectedSupplier;
        public Product product;
        public Supplier supplier;
        public ProductsSupplier productSupplier;
        public bool isAdd;
        public frmAddModifyProductSupplier()
        {
            InitializeComponent();
        }

        private void frmAddModifyProductSuppier_Load(object sender, EventArgs e)
        {
            DisplayProducts();
            DisplaySuppliers();
            if(isAdd)
            {
                this.Text = "Add Product Supplier";
            }
            else
            {
                this.Text = "Modify Product Supplier";
                if(productSupplier == null)
                {
                    MessageBox.Show("There is no product supplier selected!", "Modify Error");
                    this.Close();
                }
                // Display current product supplier
                cboProducts.SelectedItem = productSupplier.ProductId;
                cboSuppliers.SelectedItem = productSupplier.SupplierId;
            }
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            frmAddModifySupplier addSupplierForm = new frmAddModifySupplier();
            addSupplierForm.AddSupplier = true;
            DialogResult result = addSupplierForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedSupplier = addSupplierForm.Suppliers;
                    context.Suppliers.Add(selectedSupplier);
                    context.SaveChanges();
                    this.DisplaySuppliers();
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

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            frmAddModifyProduct addProductForm = new frmAddModifyProduct();
            addProductForm.AddProduct = true;
            DialogResult result = addProductForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedProduct = addProductForm.Products;
                    context.Products.Add(selectedProduct);
                    context.SaveChanges();
                    this.DisplayProducts();
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


        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            var addModifyProductForm = new frmAddModifyProduct()
            {
                AddProduct = false,
                Products = selectedProduct
            };
            
            DialogResult result = addModifyProductForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        selectedProduct = addModifyProductForm.Products; // Brett - I think this needs to work the other way around. The selectedProduct needs to come from this form, then it can be modified via frmAddModifyProduct. Do you agree?
                        context.SaveChanges();
                        DisplayProducts();
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

        private void btnSupplierModify_Click(object sender, EventArgs e)
        {
            var addModifySupplierForm = new frmAddModifySupplier()
            {
                AddSupplier = false,
                Suppliers = selectedSupplier
            };

            DialogResult result = addModifySupplierForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedSupplier = addModifySupplierForm.Suppliers;
                    context.SaveChanges();
                    DisplaySuppliers();
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

        private void btnAddProductToPackage_Click(object sender, EventArgs e)
        {
            this.LoadProductData();
            this.LoadSupplierData();
            this.DialogResult = DialogResult.OK;
        }

        private void LoadSupplierData()
        {
            supplier.SupName = cboSuppliers.SelectedIndex.ToString();
            supplier.SupplierId = Convert.ToInt32(txtSupCode.Text);
        }

        private void LoadProductData()
        {
            product.ProdName = cboProducts.SelectedIndex.ToString();
            product.ProductId = Convert.ToInt32(txtProdCode.Text);
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
                    cboProducts.Items.Add(products[i].ProdName);
                    txtProdCode.Text = products[i].ProductId.ToString();
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
                    cboSuppliers.Items.Add(suppliers[i].SupName);
                    txtSupCode.Text = suppliers[i].SupplierId.ToString();
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

        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();
            var state = context.Entry(selectedProduct).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted selected product", "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated selected product.\n" + "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplayProducts();
        }


    }
}
