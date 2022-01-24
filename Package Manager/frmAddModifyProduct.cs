/* Brett - this form opens in response to on-click events from the btnNewProduct and btnModifyProduct 
 * buttons on the frmAddModifyProducerSupplier form. 
*/
using System;
using System.Windows.Forms;
using ProductData;
using System.Data;
using System.Drawing;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Package_Manager
{
    
    public partial class frmAddModifyProduct : Form
    {
        // class-level variable to access the ProductData.Product class 
        public Product Products;
        // class-level boolean variable to allow for modal form functionality (switching between Add and Modify product)
        public bool AddProduct;
        // class-level varialbe to access the DB Context
        private TravelExpertsContext context = new TravelExpertsContext();
        Product selectedProduct = null;

        public frmAddModifyProduct()
        {
            InitializeComponent();
        }

        private void frmAddModifyProduct_Load(object sender, EventArgs e)
        {
            LoadProducts();
            if (AddProduct)
            {
                this.Text = "Add Product";
                txtProductID.ReadOnly = false;
            }
            else
            {
                this.Text = "Modify Product";
                txtProductID.ReadOnly = true;
                this.DisplayProduct();
            }
        }

        private void LoadProducts()
        {
            using (TravelExpertsContext db = new TravelExpertsContext()) // Establishes a connection with the database.
            {
                dgvListProducts.Columns.Clear(); // Calls the DataGridView's Clear() method
                /*The below implicitly-typed variable stores the results of a lambda expression that gets each of the 
                 * public properties from the Products class, representing attributes/columns from the Products table
                 * and stores them in a list. Note that */
                var products = db.Products.Select(p => new
                    {
                        p.ProductId,
                        p.ProdName
                    }).ToList();

                dgvListProducts.DataSource = products; /* gets the entries stored in the products local variable and sets 
                                                        * them as the DataGridView's datasource. */
                                
                dgvListProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold); //setting DGV's header font 
                
                // format the first column
                dgvListProducts.Columns[0].HeaderText = "Product ID";
                dgvListProducts.Columns[0].Width = 200;
                // format the second column
                dgvListProducts.Columns[1].HeaderText = "Product Name";
                dgvListProducts.Columns[dgvListProducts.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void DisplayProduct()
        {
            txtProductID.Text = Products.ProductId.ToString();
            txtProductName.Text = Products.ProdName;

        }

        private void btnAddModifyProduct_Click(object sender, EventArgs e)
        {
            frmAddModifyProduct formAddModify = new frmAddModifyProduct();
            DialogResult result = formAddModify.ShowDialog();
            context.SaveChanges();
            if(result == DialogResult.OK)
            {
                MessageBox.Show("New record was added to the database.");
            }
        }
        private void dgvListProducts_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListProducts.SelectedRows.Count > 0)
            {
                // Get the selected product code based on the row index of the cell that is clicked on, store in local variable
                int selectedRowIndex = dgvListProducts.SelectedCells[0].RowIndex;
                // Get selected row using the index
                DataGridViewRow selectedRow = dgvListProducts.Rows[selectedRowIndex];
                // Get Package id from selected row
                string selectedProductID = selectedRow.Cells["ProductID"].Value.ToString();
                // Select package with package id
                SelectProduct(Convert.ToInt32(selectedProductID));
                /* search for this product code in the database context, assign the result in variable named selectedProduct.*/
            }
        }
        private void SelectProduct(int selectedProductID)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // Load selected product using selected product ID
                selectedProduct = db.Products.Find(selectedProductID);
            }
        }
    }
}
