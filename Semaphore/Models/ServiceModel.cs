using System.Runtime.Serialization;

namespace Semaphore.Models
{
    [DataContract]
    internal class ServiceModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "display-name")]
        public string DisplayName { get; set; }
    }
}
