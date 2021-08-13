using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebStoreClient
{
    public partial class WebStoreForm : Form
    {
        private readonly WebStoreServerHandler session;
        private readonly string currentUser;
        private readonly string[] products;
        private string[] orderList;
        public WebStoreForm(WebStoreServerHandler _session, string _products, string _currentUser)
        {
            InitializeComponent();
            session = _session;
            products = _products.Split('|');
            currentUser = _currentUser;
        }

        private void WebStoreForm_Load(object sender, EventArgs e)
        {
            this.Text = $"WebStore, User:{currentUser}";  // indicate the connected user's name.
            foreach(var product in products)
            {
                productcomboBox.Items.Add(product.Split(',')[0]);
                // load products into combobox.
            }
        }

        private void purchaseBtn_Click(object sender, EventArgs e)
        {
            string orders = null;
            int i = 0;
            session.writer.WriteLine(productcomboBox.Text);  // send order selection to server.
            session.writer.Flush();
            string orderResponse = session.reader.ReadLine();  // get server response.
            if(orderResponse == "NOT_AVAILABLE")  // error message if product is invalid.
            {
                MessageBox.Show("The product is not avaliable", "Product Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (orderResponse == "NOT_VALID")  // error message if an invalid product is selected.
            {
                MessageBox.Show("The specified product is not valid", "Invalid Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else  // get back order summary if order is successful.
            {
                orders = orderResponse.Split(':')[1];
                orderList = orders.Split('|');
                foreach(var order in orderList)
                {
                    orderListPanel.Controls.Add(new Label
                    {
                        Text = order,
                        Left = 10,
                        Top = (i + 1) * 20,
                        AutoSize = true,
                        MaximumSize = new Size(550, 20)
                    });
                    i++;  // add order to display panel.
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            orderListPanel.Refresh();
        }
    }
}
