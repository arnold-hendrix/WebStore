using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebStoreClient
{
    public partial class LoginForm : Form
    {
        private readonly WebStoreServerHandler session;
        public LoginForm(WebStoreServerHandler _session)
        {
            InitializeComponent();
            session = _session;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if(hostNametxtbox.Text == session.HostName) // host name verification.
            {
                session.Start();  // begin server session.
                session.writer.WriteLine(accountNotxtbox.Text);  // send account no. input to server.
                session.writer.Flush();
                string loginResponse = session.reader.ReadLine();  // get login response

                if(loginResponse == "CONNECT_ERROR" || loginResponse == "NOT_VALID")  // error messages for unsuccessful login attempts.
                {
                    MessageBox.Show("Invalid client number", "Invalid Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else  // successful response code block.
                {
                    string user = loginResponse;
                    string getProducts = session.reader.ReadLine();
                    string[] products = getProducts.Split(':');
                    new WebStoreForm(session, products[1], user).ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // incorrect host name exception.
            }
        }

        private void accountNotxtbox_TextChanged(object sender, EventArgs e)
        {
            connectBtn.Enabled = true;
        }
    }
}
