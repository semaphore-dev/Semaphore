using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Semaphore.Models
{
    [DataContract]
    internal class ConfigurationModel
    {
        [DataMember(Name = "interval")]
        public uint Interval { get; set; }

        [DataMember(Name = "services")]
        public List<ServiceModel> Services { get; set; }
    }
}
