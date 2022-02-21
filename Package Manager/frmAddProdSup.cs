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

                newProdSup.ProductId = db.Products
                    .Where(p => p.ProdName == cboProd.Text)
                    .Select(p => p.ProductId)
                    .FirstOrDefault();

                newProdSup.SupplierId = db.Suppliers
                    .Where(p => p.SupName == cboSup.Text)
                    .Select(p => p.SupplierId)
                    .FirstOrDefault();

                var check = db.ProductsSuppliers
                    .Where(p => p.ProductId == newProdSup.ProductId && p.SupplierId == newProdSup.SupplierId)
                    .FirstOrDefault();

                if(newProdSup.SupplierId == null || newProdSup.ProductId == null)
                {
                    MessageBox.Show("Error");
                    this.Close();
                }
                else
                {
                    if (check == null)
                    {
                        db.Add(newProdSup);
                        db.SaveChanges();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
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
