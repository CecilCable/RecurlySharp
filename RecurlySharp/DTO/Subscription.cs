using System.Xml.Serialization;

namespace RecurlySharp.DTO{
    /// <summary>
    ///   RestSharp ignores XmlElement attibute. You are allowed to Pascal (or camel case the attribute) Supposed to be able to use [SerializeAsAttribute]. But That didn't seam to work
    /// </summary>
    [XmlRoot("subscription")]
    public class Subscription{
        [XmlElement("state")]
        public string State { get; set; }

        [XmlElement("uuid")]
        public string Uuid { get; set; }

        [XmlElement("unit_amount_in_cents")]
        public int UnitAmountInCents { get; set; }

        [XmlElement("remaining_billing_cycles")]
        public int RemainingBillingCycles { get; set; }

        [XmlElement("account")]
        public Account Account { get; set; }

        /// <summary>
        ///   field doulble as the next billing date. is a string in ISO 8601 date format
        /// </summary>
        [XmlElement("current_period_ends_at")]
        public string CurrentPeriodEndsAt { get; set; }

        [XmlElement("subscription_add_ons")]
        public SubscriptionAddOns SubscriptionAddOns { get; set; }

        //<subscription_add_ons type="array">
        //  <subscription_add_on>
        //    <add_on_code>guests-number</add_on_code>
        //    <unit_amount_in_cents type="integer">1875</unit_amount_in_cents>
        //    <quantity type="integer">10</quantity>
        //  </subscription_add_on>
        //</subscription_add_ons>
    }
}