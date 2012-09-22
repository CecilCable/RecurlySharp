using System.Collections.Generic;
using System.Xml.Serialization;

namespace RecurlySharp.DTO{
    [XmlRoot("subscriptions")]
    public class Subscriptions{
        [XmlElement("subscription")]
        public List<Subscription> Subscription { get; set; }
    }
}