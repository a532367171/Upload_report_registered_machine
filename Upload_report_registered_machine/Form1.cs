using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Upload_report_registered_machine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string  S= monthCalendar1.SelectionStart.ToString("yyyy-MM-dd")+";"+"3" + ";"+ textBox1.Text+";" + "2";
            textBox2.Text = DES.Encrypt(DES.Encrypt(S, "z>{6-Ke*"), "R-@.3Ci2");
        }
    }

    public class DES
    {
        private const string KEY64 = "i?>.Oh-9";

        private const string IV_64 = "i?>.Oh-9";

        public static string Encrypt(string data)
        {
            return DES.Encrypt(data, "i?>.Oh-9");
        }

        public static string Decrypt(string data)
        {
            return DES.Decrypt(data, "i?>.Oh-9");
        }

        public static string Encrypt(string data, string seckey)
        {
            byte[] byKey = System.Text.Encoding.ASCII.GetBytes(seckey);
            byte[] by_IV = System.Text.Encoding.ASCII.GetBytes(seckey);
            System.Security.Cryptography.DESCryptoServiceProvider cryptoProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cst = new System.Security.Cryptography.CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, by_IV), System.Security.Cryptography.CryptoStreamMode.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return System.Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        public static string Decrypt(string data, string seckey)
        {
            byte[] byKey = System.Text.Encoding.ASCII.GetBytes(seckey);
            byte[] by_IV = System.Text.Encoding.ASCII.GetBytes(seckey);
            byte[] byEnc;
            string result;
            try
            {
                byEnc = System.Convert.FromBase64String(data);
            }
            catch
            {
                result = null;
                return result;
            }
            System.Security.Cryptography.DESCryptoServiceProvider cryptoProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byEnc);
            System.Security.Cryptography.CryptoStream cst = new System.Security.Cryptography.CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, by_IV), System.Security.Cryptography.CryptoStreamMode.Read);
            System.IO.StreamReader sr = new System.IO.StreamReader(cst);
            result = sr.ReadToEnd();
            return result;
        }
    }
}
