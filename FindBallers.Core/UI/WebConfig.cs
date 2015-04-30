using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.UI
{
    public class WebConfig
    {

        #region AppSettings
        /// <summary>Gets and validates a specific appSetting from the web.config</summary>
        /// <param name="appSettingName">The name of the appSetting in the web.config</param>
        /// <returns>The value of the appSetting in the web.config</returns>
        protected static string GetAppSetting(string appSettingName)
        {
            //Check if null
            if (ConfigurationManager.AppSettings[appSettingName] == null)
                throw new ArgumentNullException(appSettingName, appSettingName + " value cannot be null or empty in the web.config.");

            return ConfigurationManager.AppSettings[appSettingName];
        }

        /// <summary>Gets and validates a specific appSetting from the web.config</summary>
        /// <param name="appSettingName">The name of the appSetting in the web.config</param>
        /// <returns>The value of the appSetting in the web.config</returns>
        protected static bool GetBoolAppSetting(string appSettingName)
        {
            return Convert.ToBoolean(GetAppSetting(appSettingName));
        }

        /// <summary>Gets and validates a specific appSetting from the web.config</summary>
        /// <param name="appSettingName">The name of the appSetting in the web.config</param>
        /// <returns>The value of the appSetting in the web.config</returns>
        protected static string[] GetStringArraySetting(string appSettingName)
        {
            string[] values = GetAppSetting(appSettingName).Split(new char[] { ',' });
            return values;
        }

        /// <summary>Gets and validates a specific appSetting from the web.config</summary>
        /// <param name="appSettingName">The name of the appSetting in the web.config</param>
        /// <returns>The value of the appSetting in the web.config</returns>
        protected static DateTime GetDateTimeAppSetting(string appSettingName)
        {
            DateTime dt;
            if (!DateTime.TryParse(GetAppSetting(appSettingName), out dt))
                throw new ArgumentException("Value of " + appSettingName + " is an invalid DateTime object.", appSettingName);

            return dt;
        }


        #endregion

        #region ConnectionStrings
        /// <summary>Gets and validates a specific connectionString from the web.config</summary>
        /// <param name="connectionStringName">The name of the connectionString in the web.config</param>
        /// <returns>The value of the connectionString in the web.config</returns>
        protected static string GetConnectionString(string connectionStringName)
        {
            //Check if the connection string exists
            if (ConfigurationManager.ConnectionStrings[connectionStringName] == null)
                throw new ArgumentNullException(connectionStringName, connectionStringName + " cannot be null in the web.config.");

            //Check if the connection string is null or empty
            if (String.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                throw new ArgumentNullException(connectionStringName, connectionStringName + " value cannot be null or empty in the web.config.");

            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }


        public static string CMSConnectionString
        {
            get { return GetConnectionString("CMSConnectionString"); }
        }


        #endregion

        public static string LDAPPath
        {
            get { return GetAppSetting("LDAPPath"); }
        }
    }
}

