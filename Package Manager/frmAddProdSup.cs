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
    public partial class frmAddProdSup : Form
    {
        public ProductsSupplier newProductsSupplier;
        public frmAddProdSup()
        {
            InitializeComponent();
        }

        private void frmAddProdSup_Load(object sender, EventArgs e)
        {
            LoadProductsAndSuppliers();
        }

        private void LoadProductsAndSuppliers()
        {
            // Gets all products and suppliers and displays them in combo box
            var prodList = ProductManager.GetAllProducts();
            cboProd.DataSource = prodList.Select(p => p.ProdName).ToList();
            var supList = SupplierManager.GetAllSuppliers();
            cboSup.DataSource = supList.Select(s => s.SupName).ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            using(TravelExpertsContext db = new TravelExpertsContext())
            {
                ProductsSupplier newProdSup = new ProductsSupplier();

                // Searches for product id with name from combo box
                newProdSup.ProductId = db.Products
                    .Where(p => p.ProdName == cboProd.Text)
                    .Select(p => p.ProductId)
                    .FirstOrDefault();

                // Searches for supplier id with name from combo box
                newProdSup.SupplierId = db.Suppliers
                    .Where(p => p.SupName == cboSup.Text)
                    .Select(p => p.SupplierId)
                    .FirstOrDefault();

                // Checks for product supplier that already exists
                var check = db.ProductsSuppliers
                    .Where(p => p.ProductId == newProdSup.ProductId && p.SupplierId == newProdSup.SupplierId)
                    .FirstOrDefault();

                // Little error check to check for null supplier Id or prod Id somehow
                if(newProdSup.SupplierId == null || newProdSup.ProductId == null)
                {
                    MessageBox.Show("Error");
                    this.Close();
                }
                else
                {
                    if (check == null) // There is no product supplier in db
                    {
                        db.Add(newProdSup); // Create a new product supplier
                        db.SaveChanges();
                        this.DialogResult = DialogResult.OK;
                    }
                    else // There already is a product supplier with this combo
                    {
                        MessageBox.Show("This product supplier already exists!");
                    }
                }
                
                //db.ProductsSuppliers.Include(p => p.Product).Include(s => s.Supplier).Select(p => p.ProductId).FirstOrDefault();
              
                //var check = db.PackagesProductsSuppliers.Where(p => p.PackageId == newProd.PackageId &&
                //                                                   p.ProductSupplierId == newProd.ProductSupplierId)
                //                                                   .FirstOrDefault();
            }
               
        }
    }
}
