using System;
using System.Xml.Serialization;

namespace RecurlySharp.DTO{
    [Serializable]
    public class SubscriptionAddOns{
        [XmlElement("subscription_add_on")]
        public SubscriptionAddOn SubscriptionAddOn { get; set; }
    }
}