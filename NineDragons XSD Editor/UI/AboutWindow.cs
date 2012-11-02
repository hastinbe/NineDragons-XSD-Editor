//  Copyright (c) 2012 Beau Hastings. All rights reserved.
//  License: GNU GPL version 2, see LICENSE for more details.
//  Author: Beau Hastings <beausy@gmail.com>
using Microsoft.Win32;              // Required for registry classes
using System;
using System.Diagnostics;           // Required for process classes
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;                    // Required for Path class
using System.Reflection;            // Required for assembly classes
using System.Windows.Forms;

namespace NineDragons_XSD_Editor.UI
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();

            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;

            this.linkWebsite.Click += delegate
            {
                Process.Start(this.linkWebsite.Text);
            };
            this.linkAuthorEmail.Click += delegate
            {
                Process.Start("http://www.elitepvpers.com/forum/members/499233-saweet.html");
            };
            this.buttonOk.Click += delegate { this.Close(); };
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            Rectangle BaseRectangle =
                new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            Color darkblue = Color.FromArgb(13, 80, 143);

            Brush Gradient_Brush =
                new LinearGradientBrush(
                BaseRectangle,
                darkblue, Color.AliceBlue,
                LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(Gradient_Brush, BaseRectangle);
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            Color mediumblue = Color.FromArgb(128, 172, 223);
            Color lightblue = Color.FromArgb(216, 234, 248);

            Rectangle TopRectangle =
                new Rectangle(0, 1, this.Width - 1, 20);

            Rectangle MidRectangle =
                new Rectangle(0, TopRectangle.Height, this.Width - 1, this.Height - 1 - TopRectangle.Height);

            Brush TopBrush = new LinearGradientBrush(
                TopRectangle,
                mediumblue, lightblue,
                LinearGradientMode.Vertical);

            Brush MidBrush = new LinearGradientBrush(
                MidRectangle,
                lightblue, mediumblue,
                LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(TopBrush, TopRectangle);
            e.Graphics.FillRectangle(MidBrush, MidRectangle);
        }

        private void buttonSystemInfo_Click(object sender, EventArgs e)
        {
            string strSysInfo = string.Empty;

            if (GetMsinfo32Path(ref strSysInfo))
            {
                try
                {
                    Process.Start(strSysInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private bool GetMsinfo32Path(ref string strPath)
        {
            strPath = string.Empty;
            object objTmp = null;
            RegistryKey regKey = Registry.LocalMachine;

            if (regKey != null)
            {
                regKey = regKey.OpenSubKey(
                     "Software\\Microsoft\\Shared Tools\\MSInfo");
                if (regKey != null)
                    objTmp = regKey.GetValue("Path");

                if (objTmp == null)
                {
                    regKey = regKey.OpenSubKey(
                       "Software\\Microsoft\\Shared Tools Location");
                    if (regKey != null)
                    {
                        objTmp = regKey.GetValue("MSInfo");
                        if (objTmp != null)
                            strPath = Path.Combine(
                               objTmp.ToString(), "MSInfo32.exe");
                    }
                }
                else
                    strPath = objTmp.ToString();

                try
                {
                    FileInfo fi = new FileInfo(strPath);
                    return fi.Exists;
                }
                catch (ArgumentException)
                {
                    strPath = string.Empty;
                }
            }

            return false;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        #endregion
    }
}
