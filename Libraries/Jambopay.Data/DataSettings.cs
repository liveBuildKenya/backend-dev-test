using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Jambopay.Data
{
    public class DataSettings
    {
        /// <summary>
        /// Gets or sets a connection string
        /// </summary>
        [JsonProperty(PropertyName = "DataConnectionString")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets a data provider
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DataProviderType DataProvider { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the information is entered
        /// </summary>
        /// <returns></returns>
        [JsonIgnore]
        public bool IsValid => DataProvider != DataProviderType.Unknown && !string.IsNullOrEmpty(ConnectionString);
    }
}
