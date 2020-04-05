using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;
using System.Web;
namespace XXAboodTurbo
{
    public partial class Form1 : Form
    {
        public bool Status { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }
        private bool GetUsername(string username)
        {
            using (HttpRequest httpRequest = new HttpRequest())
            {
                httpRequest.AddHeader("User-Agent", "Instagram 20.6.4 Android (18/4.3; 480dpi; 1080x1812; HUAWEI; HUAWEI VNS-L31; HWVNS-H; hi6250; es_ES)");
                httpRequest.AddHeader("Cookie", api.String13);
                httpRequest.AddHeader("X-IG-Connection-Type", "WIFI");
                httpRequest.AddHeader("X-IG-Capabilities", "3ToAAA==");
                httpRequest.AddParam("gender", (object)"1");
                httpRequest.AddParam("_csrftoken", (object)"missing");
                httpRequest.AddParam("_uuid", (object)Guid.NewGuid().ToString().ToUpper());
                httpRequest.AddParam("_uid", (object)"3");
                httpRequest.AddParam("external_url", (object)"www.bruh.com");
                httpRequest.AddParam(nameof(username), (object)username);
                httpRequest.AddParam("email", (object)api.String5);
                httpRequest.AddParam("phone_number", (object)"");
                httpRequest.AddParam("biography", (object)"me when my bio is made for no reason bruh");
                httpRequest.AddParam("first_name", (object)"commit die");
                int num = (int)Interaction.MsgBox((object)httpRequest.Post("https://i.instagram.com/api/v1/accounts/edit_profile/").ToString(), MsgBoxStyle.OkOnly, (object)null);
            }
            return false;
        }
        private bool Checkusername()
        {
            while (!this.Status)
            {
                try
                {
                    string text = new WebClient()
                    {
                        Headers = {
              {
                "User-Agent",
                "Instagram 20.6.4 Android (18/4.3; 480dpi; 1080x1812; HUAWEI; HUAWEI VNS-L31; HWVNS-H; hi6250; es_ES)"
              },
              {
                "Cookie",
                api.String13
              }
            },
                        Proxy = ((IWebProxy)null)
                    }.DownloadString("https://i.instagram.com/api/v1/feed/user/" + this.textBox3.Text + "/username/");
                    this.textBox6.AppendText(text);
                    if (text.Contains("{\"items\": [], \"num_results\": 0, \"status\": \"ok\"}"))
                    {
                        this.GetUsername(this.textBox3.Text);
                    }
                    else
                    {
                        textBox5.Text = Conversions.ToString(Conversions.ToDouble(textBox5.Text) + 1.0);
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                }
                Thread.Sleep(Conversions.ToInteger(textBox4.Text));
            }
            return false;
        }
        public void runthreads()
        {
            new Thread((ThreadStart)(() => this.Checkusername())).Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(api.Method((object)this.textBox1.Text, (object)this.textBox2.Text))))))) || !Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(api.Method3())))))))
                return;
            this.runthreads();
        }
    }
    
}
