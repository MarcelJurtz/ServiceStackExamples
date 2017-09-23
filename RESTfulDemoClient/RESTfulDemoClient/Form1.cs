using System;
using System.Windows.Forms;

namespace RESTfulDemoClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            using(var client = new RESTfulServiceClient())
            {
                var request = new Hello() { Name = txtRequest.Text };
                try
                {
                    var response = client.GetHelloResponse(request, txtUsername.Text, txtPassword.Text);
                    txtResponse.Text = response.Result;
                }
                catch (ServiceStack.WebServiceException ex)
                {
                    txtResponse.Text = ex.StatusCode + " - " + ex.ErrorMessage;
                }
            }
        }
    }
}
