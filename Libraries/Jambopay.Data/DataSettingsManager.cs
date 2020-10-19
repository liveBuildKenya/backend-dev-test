using Jambopay.Core;
using Jambopay.Core.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Jambopay.Data
{
    /// <summary>
    /// Represents the data settings manager
    /// </summary>
    public static class DataSettingsManager
    {
        #region Fields

        private static bool? _databaseIsInstalled;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether database is already installed
        /// </summary>
        public static bool DatabaseIsInstalled
        {
            get
            {
                if (!_databaseIsInstalled.HasValue)
                    _databaseIsInstalled = !string.IsNullOrEmpty(LoadSettings(reloadSettings: true)?.ConnectionString);

                return _databaseIsInstalled.Value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load data settings
        /// </summary>
        /// <param name="filePath">File path; pass null to use the default settings file</param>
        /// <param name="reloadSettings">Whether to reload data, if they already loaded</param>
        /// <param name="fileProvider">File provider</param>
        /// <returns>Data settings</returns>
        public static DataSettings LoadSettings(string filePath = null, bool reloadSettings = false, IJambopayFileProvider fileProvider = null)
        {
            if (!reloadSettings && Singleton<DataSettings>.Instance != null)
                return Singleton<DataSettings>.Instance;

            fileProvider ??= CommonHelper.DefaultFileProvider;
            filePath ??= fileProvider.MapPath(JambopayDataSettingsDefaults.FilePath);

            //check whether file exists
            if (fileProvider.FileExists(filePath))
            { 
                var text = fileProvider.ReadAllText(filePath, Encoding.UTF8);
                if (string.IsNullOrEmpty(text))
                    return new DataSettings();

                //get data settings from the JSON file
                Singleton<DataSettings>.Instance = JsonConvert.DeserializeObject<DataSettings>(text);

                return Singleton<DataSettings>.Instance;
            }

            return Singleton<DataSettings>.Instance;
        }

        /// <summary>
        /// Reset "database is installed" cached information
        /// </summary>
        public static void ResetCache()
        {
            _databaseIsInstalled = null;
        }

        #endregion
    }
}
