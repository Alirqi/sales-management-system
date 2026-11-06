using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesSystem.FR
{
    public partial class For_ConnectDb : DevExpress.XtraEditors.XtraForm
    {

        public For_ConnectDb()
        {
            InitializeComponent();
        }


        private void btnOpenConnection_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server = txtServer.Text.Trim();
            Properties.Settings.Default.DataBase = txtDataBase.Text.Trim();
            CLASSES.Initialization.ServerSetting.databaseName = txtDataBase.Text.Trim();
            CLASSES.Initialization.ServerSetting.serverName = txtServer.Text.Trim();


            if (toggleSwitch1.IsOn)
            {
                Properties.Settings.Default.Mode = "Mode";
                Properties.Settings.Default.Username = "";
                CLASSES.Initialization.ServerSetting.userName = "";
                CLASSES.Initialization.ServerSetting.password = "";
                Properties.Settings.Default.Password = "";
            }
            else
            {
                Properties.Settings.Default.Mode = "SQL";
                Properties.Settings.Default.Username = txtUsername.Text.Trim();
                CLASSES.Initialization.ServerSetting.userName = txtUsername.Text.Trim();
                CLASSES.Initialization.ServerSetting.password = txtPassword.Text.Trim();
                Properties.Settings.Default.Password = txtPassword.Text.Trim();
            }

            Properties.Settings.Default.Save();

            var dbConnection = new CLASSES.DAL.ConnectDB();
            dbConnection.OpenConnection();
        }

        private void btnCloseConnection_Click_1(object sender, EventArgs e)
        {
            //var dbConnection = new CLASSES.DAL.ConnectDB();
            //dbConnection.CloseConnection();

            this.Close();
            if (Application.OpenForms["For_Main"] != null)
                ((For_Main)Application.OpenForms["For_Main"]).ClosTap();
        }

        private void For_ConnectDb_Load(object sender, EventArgs e)
        {

            txtServer.Text = Properties.Settings.Default.Server;
            txtDataBase.Properties.DataSource = CLASSES.Initialization.MyPropertyTypeConverter.getDbname(Properties.Settings.Default.Server, Properties.Settings.Default.Mode);
            txtDataBase.Text = Properties.Settings.Default.DataBase;
            if (Properties.Settings.Default.Mode == "SQL")
            {
                toggleSwitch1.IsOn = false;
            }
            else
            {
                toggleSwitch1.IsOn = true;
            }
            txtUsername.Text = Properties.Settings.Default.Username;
            txtPassword.Text = Properties.Settings.Default.Password;
            CLASSES.FormFunction.splashScreenManager.splashScreenManager1.CloseWaitForm();
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                layoutControlItem3.ContentVisible = false;
                layoutControlItem4.ContentVisible = false;

            }
            else
            {
                layoutControlItem3.ContentVisible = true;
                layoutControlItem4.ContentVisible = true;

            }
        }

        private void txtServer_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDataBase.Properties.DataSource = CLASSES.Initialization.MyPropertyTypeConverter.getDbname(txtServer.Text, Properties.Settings.Default.Mode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}