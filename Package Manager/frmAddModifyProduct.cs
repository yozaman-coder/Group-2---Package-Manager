using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductData;

namespace Package_Manager
{
    public partial class frmAddModifyProduct : Form
    {
        // adding public class to access the ProductData.Product class 
        public Product Products;
        // creating new public boolean variable to allow for modal form functionality (switching between Add and Modify product)
        public bool AddProduct;
        // adding private reference to DB Context
        private TravelExpertsContext context = new TravelExpertsContext();

        public frmAddModifyProduct()
        {
            InitializeComponent();
        }

        private void frmAddModifyProduct_Load(object sender, EventArgs e)
        {

        }

        private void btnAddModifyProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
