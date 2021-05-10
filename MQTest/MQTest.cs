using IBM.WMQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MQTest
{
    public partial class MQTest : Form
    {
        AditMQHelper MyMQHelper;

        public MQTest()
        {
            MyMQHelper = new AditMQHelper();

            InitializeComponent();
        }

        private void btPut_Click(object sender, EventArgs e)
        {
            SetMQHelperParams();
            try
            {
                if (MyMQHelper.Connect())
                {
                    if (MyMQHelper.Put(tbMessage.Text))
                    {
                        MessageBox.Show(this, "Message successfully put.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyMQHelper.Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + "\n\n" + ex.StackTrace, "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btGet_Click(object sender, EventArgs e)
        {
            SetMQHelperParams();
            string result = "";
            try
            {
                if (MyMQHelper.Connect())
                {
                    if (MyMQHelper.Get(out result))
                    {
                        tbMessage.Text = result;
                        MessageBox.Show(this, "Message successfully get.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyMQHelper.Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + "\n\n" + ex.StackTrace, "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetMQHelperParams()
        {
            MyMQHelper.Host = tbServer.Text;
            MyMQHelper.Port = tbPort.Text;
            MyMQHelper.QM = tbQManager.Text;
            MyMQHelper.Channel = tbChannel.Text;
            MyMQHelper.QueueName = tbQName.Text;
        }
    }
}
