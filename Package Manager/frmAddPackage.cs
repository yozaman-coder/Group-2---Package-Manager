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
    public partial class frmAddPackage : Form
    {
        public frmAddPackage()
        {
            InitializeComponent();
        }

        private void frmAddPackage_Load(object sender, EventArgs e)
        {

            GetPackages();
            DisplayProducts();
            DisplayPackages();
        }

        private void GetPackages()
        {
            throw new NotImplementedException();
        }

        private void DisplayPackages()
        {
            throw new NotImplementedException();
        }

        private void DisplayProducts()
        {
            throw new NotImplementedException();
        }

        private void cboPackageID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPackage();
            DisplayProducts();
        }

        private void SelectPackage()
        {
            throw new NotImplementedException();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Opens secondForm and passes selectedProduct
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update selected package with form information
            DisplayProducts();
            DisplayPackages();
        }

        private void btnNewPackage_Click(object sender, EventArgs e)
        {
            // Adds new blank package
        }
    }
}
