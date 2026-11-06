using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace SalesSystem.CLASSES.Initialization
{
    class ServerSetting
    {


        public static string serverName= Properties.Settings.Default.Server;

        [Category("Server Settings")]
        [Description("Server name")]       
        [DefaultValue("Default Value")]
        [DisplayName("Server name :")]
        public string SeverName
        {
            get { return serverName; }
            set { serverName = value; }
        }



        public static string databaseName= Properties.Settings.Default.DataBase;

        [Category("Database Settings")]
        [TypeConverter(typeof(MyPropertyTypeConverter))]
        [Description("Database name")]
        [DisplayName("Database name :")]
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }


        public static bool isMod = Properties.Settings.Default.Mode=="SQL"? false:true;

        [Category("Database Settings")]
        [Description("Mod or SQL")]
        public bool IsMod
        {
            get { return isMod; }
            set
            {
                isMod = value;
            }
        }



        public static string userName= Properties.Settings.Default.Username;
        [Category("Database Settings")]
        [Description("User name")]
        [DisplayName("User name :")]
        [Browsable(true)]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public static string password= Properties.Settings.Default.Password;
        [Category("Database Settings")]
        [Description("Password")]
        [DisplayName("Password :")]
        [PasswordPropertyText(true)]        
        [Browsable(true)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }



        public bool ShouldSerializeUserName()
        {
            return this.IsMod;
        }

        public bool ShouldSerializePassword()
        {
            return this.IsMod;
        }

        public void ResetUserName()
        {
            this.UserName = string.Empty;
        }

        public void ResetPassword()
        {
            this.Password = string.Empty;
        }

    }

    public class MyPropertyTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            // يجعل الخاصية غير قابلة للكتابة
            return true;
        }
       

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
                        
            return new StandardValuesCollection(getDbname(CLASSES.Initialization.ServerSetting.serverName, Properties.Settings.Default.Mode));
        }  

        public static List<string> getDbname(string servername,string mod)
        {
            List<string> dbname = new List<string>();

            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = servername,
                InitialCatalog = CLASSES.Initialization.ServerSetting.databaseName,
                IntegratedSecurity = mod!= "SQL"
            };

            if (!connectionStringBuilder.IntegratedSecurity)
            {
                connectionStringBuilder.UserID = CLASSES.Initialization.ServerSetting.userName;
                connectionStringBuilder.Password = CLASSES.Initialization.ServerSetting.password;
            }

            using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ToString()))
            {
                connection.Open();

                DataTable databases = connection.GetSchema("Databases");
                foreach (DataRow row in databases.Rows)
                {
                    string databaseName = row.Field<string>("database_name");
                    dbname.Add(databaseName);
                }
            }
            return dbname;
        }
    }
}
