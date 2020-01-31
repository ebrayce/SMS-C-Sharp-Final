using SMS.Controller;
using SMS.Helpers;
using SMS.Model;
using SMS.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class MainForm : Form
    {
        private Company company;
        private IList<Product> products;
        private IList<User> users;
        private IList<SellItem> sellItems = new List<SellItem>();
        private int SellItemNumber = 1;
        private double GrandTotal;

        public IList<User> loadAllUsers()
        {
           return UsersController.listOfAllUser();
        }

        private void updateCompanyInfoInForm()
        {
            lbCompanyDescripiton.Text = company.Description;
            lbCompanyLocation.Text = company.Location;
            lbCompanyName.Text = company.Name;
            lbCompanyAddress.Text = company.Address;
        }
        public void loadCompanyInfo()
        {
            IList<Company> companies = CompanyController.listOfAllCompany();
            
            if(companies.Count == 1)
            {
                company = companies[0];
                updateCompanyInfoInForm();

            }
            else
            {

                formUpdateCompanyInformation.Visible = true;

                company = new Company
                {
                    Name = "No name",
                    Address = "No Address",
                    Location = "No  Location",
                    Description =  "No  Description."

                };

                CompanyController.createCompany(company);
                updateCompanyInfoInForm();

            }



        }



        public IList<Product> loadAllProducts()
        {
            return ProductController.listOfAllProduct();
        }

        public void updateGrandTotal()
        {
            GrandTotal = 0;
            foreach (SellItem item in sellItems)
            {
                GrandTotal += item.SUB_TOTAL;
            }

            txtGrandTotal.Text = Convert.ToString(GrandTotal);
        }
        public void udateProduct(int selected)
        {
            products[selected].InStock = Convert.ToInt32(txtShowProductInStock.Value) + Convert.ToInt32(txtPlusProductInStock.Value);
            products[selected].Name = txtShowProductName.Text;
            products[selected].Price = Convert.ToDouble(txtShowProductPrice.Text);
            products[selected].MinStock = Convert.ToInt32(txtShowProductMinStock.Value);

            ProductController.updateProduct(products[selected]);
        }

        public void freshSale()
        {
            //clear gridview
            sellItems.Clear();

            //clear grand total
            GrandTotal = 0;

            //refresh product
            
            //reset itemNo
            SellItemNumber = 1;

        }

        public void updateProductStock()
        {
            foreach (SellItem item in sellItems)
            {
                
                foreach(Product product in products)
                {
                    if (product.Id == item.Product.Id)
                    {
                        product.InStock = product.InStock - item.QUANTITY;
                    }
                }

                ProductController.updateProduct(item.Product);
            }
        }

        public void udateUser(int selected)
        {
            users[selected].Name = txtUserShowName.Text;
            users[selected].Username = txtUserShowUsername.Text;
            users[selected].Password = txtUserShowPassword.Text;


            UsersController.updateUser(users[selected]);
        }

        public void deleteProduct(int selected)
        {
            ProductController.deleteProduct(products[selected]);
        }
        public void deleteUser(int selected)
        {
            UsersController.deleteUser(users[selected]);
        }

        public void updateProductsComboBox()
        {
            cmbProducts.Items.Clear();
            cmbProducts.Text = "";
            cmbSellProducts.Items.Clear();
            cmbSellProducts.Text = "";

            cmbProducts.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProducts.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();

            foreach (Product product in products)
            {
                cmbProducts.Items.Add(product.Name);
                cmbSellProducts.Items.Add(product.Name);
                combData.Add(product.Name);

            }
            

            cmbProducts.AutoCompleteCustomSource = combData;
            cmbSellProducts.AutoCompleteCustomSource = combData;

            
        }
        public void updateUsersComboBox()
        {
            cmbUsers.Items.Clear();

            cmbUsers.Text = "";

            cmbUsers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUsers.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();

            foreach (User user in users)
            {
                cmbUsers.Items.Add(user.Name);
                combData.Add(user.Name);

            }
            

            cmbUsers.AutoCompleteCustomSource = combData;


        }

        public void showProductDetails(int selected)
        {
            txtShowProductInStock.Value = products[selected].InStock;
            txtShowProductName.Text = products[selected].Name;
            txtShowProductPrice.Text = Convert.ToString(products[selected].Price);
            txtShowProductMinStock.Value = products[selected].MinStock;
        }
        public void clearShowProductFields()
        {
            txtShowProductInStock.Value = 0;
            txtShowProductName.Text = "";
            txtShowProductPrice.Text = "";
            txtShowProductMinStock.Value = 0;
            txtPlusProductInStock.Value = 0;
        }


        public void showUserDetails(int selected)
        {
            txtUserShowName.Text = users[selected].Name;
            txtUserShowUsername.Text = users[selected].Username;
            txtUserShowPassword.Text = users[selected].Password;
        }
        public void clearShowUserFields()
        {
            txtUserShowName.Text = "";
            txtUserShowUsername.Text = "";
            txtUserShowPassword.Text = "";
        }

        
        public string getProductName()
        {
            return txtProductName.Text;
        }

        public double getProductPrice()
        {
            return Convert.ToDouble(txtProductPrice.Text);
        }

        public int getProductInStock()
        {
            return Convert.ToInt32(txtProductInStock.Value);
        }

        public int getProductMinStock()
        {
            return Convert.ToInt32(txtProductMinStock.Value);
        }


        private User addUser()
        {
            var username = txtUsersUsername.Text;
            var password = txtUserPassword.Text;
            var name = txtUserName.Text;
            return UserView.addUser(name, username, password);

        }
        private void addProduct()
        {

           products.Add(ProductView.addProductView(getProductName(),getProductPrice(),getProductInStock(),getProductMinStock()));
            updateProductsComboBox();
        }
        void clearAddProductForm()
        {
            txtProductPrice.Text = "";
            txtProductName.Text = "";
            txtProductInStock.Value = 0;
            txtProductMinStock.Value = 0;
        }

        void clearAddUserForm()
        {
            txtUserName.Text = "";
            txtUsersUsername.Text = "";
            txtUserPassword.Text = "";
        }
        private bool validateAddProduct()
        {
            

            return true;
        }

        public MainForm()
        {
            InitializeComponent();
        }

       

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        

        

        //private void Button2_Click(object sender, EventArgs e)
        //{
        //    users.Add(addUser());
        //    updateUsersComboBox();
        //    clearShowUserFields();
        //}

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            lbProductAddedMessage.Text = "";
            addProduct();
            clearAddProductForm();
            lbProductAddedMessage.Text = "Product Created Successfully.";
        }

        private void TxtProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

       
        private void TxtProductMinStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            products = loadAllProducts();
            users = loadAllUsers();

            updateProductsComboBox();
            updateUsersComboBox();
            loadCompanyInfo();
            clearShowUserFields();
        }

        private void CmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int selected = cmbProducts.SelectedIndex;
            
            showProductDetails(selected);
        }

        private void BtnUpdateProduct_Click(object sender, EventArgs e)
        {
            
            int selected = cmbProducts.SelectedIndex;

            if (selected >= 0 && selected < cmbProducts.Items.Count)
            {

                udateProduct(selected);
                updateProductsComboBox();
                clearShowProductFields();
            }
        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            confirmProductDeleteForm.Visible = true;
            
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            confirmProductDeleteForm.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            confirmProductDeleteForm.Visible = false;
            int selected = cmbProducts.SelectedIndex;

            if (selected >= 0 && selected < cmbProducts.Items.Count)
            {
                int canDelete = 1;
                try
                {
                    deleteProduct(selected);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    canDelete = 0;
                }
                
                if(canDelete == 1)
                {
                    products.RemoveAt(selected);
                    updateProductsComboBox();
                    clearShowProductFields();
                }
                else
                {
                    MessageBox.Show("You can't Delete that.");
                }
                
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void CmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = cmbUsers.SelectedIndex;
            showUserDetails(selected);
        }

        //private void BtnAddUser_Click(object sender, EventArgs e)
        //{
        //    users.Add(addUser());
        //    updateUsersComboBox();
        //    clearShowUserFields();
        //}

        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            int selected = cmbUsers.SelectedIndex;

            if (selected >= 0 && selected < cmbUsers.Items.Count)
            {

                udateUser(selected);
                updateUsersComboBox();
                clearShowUserFields();
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            users.Add(addUser());
            updateUsersComboBox();
           
            clearAddUserForm();
        }

        

        private void BtnConfirmUserDeleteNo_Click(object sender, EventArgs e)
        {
            confirmUserDeleteForm.Visible = false;
        }

        private void BtnConfirmUserDeleteYes_Click(object sender, EventArgs e)
        {
            confirmUserDeleteForm.Visible = false;
            int selected = cmbUsers.SelectedIndex;

            if (selected >= 0 && selected < cmbUsers.Items.Count)
            {
                deleteUser(selected);
                users.RemoveAt(selected);
                updateUsersComboBox();
                clearShowUserFields();
            }
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            confirmUserDeleteForm.Visible = true;
        }

        private void BtnAddToList_Click(object sender, EventArgs e)
        {
            
            int sellected = cmbSellProducts.SelectedIndex;

            if(txtQuantityBuying.Value > 0 && sellected >= 0 && sellected <= cmbSellProducts.Items.Count && txtQuantityBuying.Value <= products[sellected].InStock)
            {
                int saleAddWithIndex = -1;
                for(int x = 0; x<sellItems.Count; x++)
                {
                    if (sellItems[x].Product.Id == products[sellected].Id)
                    {
                        //MessageBox.Show("Record Found");
                        saleAddWithIndex = x;
                        
                       break;

                    }
                    
                }

                if (saleAddWithIndex == -1)
                {
                        SellItem sell = new SellItem(SellItemNumber, products[sellected].Name, products[sellected].Price, Convert.ToInt32(txtQuantityBuying.Value), products[sellected].Price * Convert.ToInt32(txtQuantityBuying.Value), products[sellected]);
                        //SellItem sell2 = new SellItem(1, "Ernest", 5.6, 5);
                        SellItemNumber++;
                        sellItems.Add(sell);
                }
                else
                {
                    sellItems[saleAddWithIndex].QUANTITY = sellItems[saleAddWithIndex].QUANTITY + Convert.ToInt32(txtQuantityBuying.Value);
                    sellItems[saleAddWithIndex].SUB_TOTAL = products[sellected].Price * sellItems[saleAddWithIndex].QUANTITY;
                    //MessageBox.Show("It has been added Already at Index " + saleAddWithIndex);
                }
                





                BindingSource binding = new BindingSource();
                binding.DataSource = typeof(SellItem);

                foreach (SellItem item in sellItems)
                {
                    binding.Add(item);
                }

                //soldItemsGridView.AutoGenerateColumns = true;
                soldItemsGridView.ReadOnly = true;
                soldItemsGridView.DataSource = binding;
                cmbSellProducts.Text = "";
                lbShowSellItemInStock.Text = "";
                lbShowSellItemPrice.Text = "";
                txtQuantityBuying.Value = 0;
                updateGrandTotal();
                btnSaveAndPrint.Enabled = true;
            }
            
            


           
        }

        private void Label24_Click(object sender, EventArgs e)
        {

        }

        private void CmbSellProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sellected = cmbSellProducts.SelectedIndex;
            //MessageBox.Show(sellected.ToString() + cmbUsers.Items.Count);
            if (sellected >= 0 && sellected < cmbProducts.Items.Count)
            {

                if(products[sellected].InStock == 0)
                {
                    lbOutOfStock.Visible = true;
                    btnAddToList.Enabled = false;
                }
            }
                if (sellected >= 0 && sellected < cmbProducts.Items.Count)
            {
                lbShowSellItemInStock.Text = Convert.ToString(products[sellected].InStock);
                lbShowSellItemPrice.Text = Convert.ToString(products[sellected].Price);
            }
        }

        private void BtnSaveAndPrint_Click(object sender, EventArgs e)
        {
            //First save the sale
            //Second save the Items
            if (sellItems.Count > 0)
            {
                SaleView.saveSale(sellItems, GrandTotal);

                updateProductStock();
                freshSale();
                MessageBox.Show("Successfully Saved.\n Now Printing .........");
                btnSaveAndPrint.Enabled = false;

            }
            else
            {
                MessageBox.Show("Please select what to sell. Its Empty.");
            }
            

        }

        private void BtnUpdateCompanyInfomation_Click(object sender, EventArgs e)
        {
            formUpdateCompanyInformation.Visible = true;
        }

        private void BtnUpdateCompanyInfoCancel_Click(object sender, EventArgs e)
        {
            formUpdateCompanyInformation.Visible = false;
        }

        private void BtnUpdateCompanyInfoSubmit_Click(object sender, EventArgs e)
        {
            updateCompanyInformation();
            
            formUpdateCompanyInformation.Visible = false;
        }

        private void updateCompanyInformation()
        {
            if(txtCompanyName.Text != "" && txtCompanyAddress.Text != "" && txtCompanyDescription.Text != "" && txtCompanyLocation.Text != "")
            {
                company.Name = txtCompanyName.Text;
                company.Address = txtCompanyAddress.Text;
                company.Description = txtCompanyDescription.Text;
                company.Location = txtCompanyLocation.Text;
                updateCompanyInfoInForm();
                updateCompanyInDB();
            }
            
            

        }

        private void updateCompanyInDB()
        {
            CompanyController.updateCompany(company);
        }
    }
}
