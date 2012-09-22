using System;
using System.Xml.Serialization;

namespace RecurlySharp.DTO{
    [Serializable]
    public class SubscriptionAddOn{
        [XmlElement("add_on_code")]
        public string AddOnCode { get; set; }

        [XmlElement("unit_amount_in_cents")]
        public int UnitAmountInCents { get; set; }

        [XmlElement("quantity")]
        public int Quantity { get; set; }
    }
}