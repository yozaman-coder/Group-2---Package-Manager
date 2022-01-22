using System;
using System.Windows.Forms;
using ProductData;

namespace Package_Manager
{
    /* Brett - below is a work in progress. Will not run at the moment because the frmAddModifyPackage.GetPackages() method needs to run first.
     * Needs to get on-click events from the Add Product and Modify Product buttons on frmAddModifyPackage
     * form.
     */
    public partial class frmAddModifyProduct : Form
    {
        // adding public class to access the ProductData.Product class 
        public Product Products;
        // creating new public boolean variable to allow for modal form functionality (switching between Add and Modify product)
        public bool AddProduct;
        // accesssing DB Context
        private TravelExpertsContext context = new TravelExpertsContext();

        public frmAddModifyProduct()
        {
            InitializeComponent();
        }

        private void frmAddModifyProduct_Load(object sender, EventArgs e)
        {
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
    }
}
