using System.Xml.Serialization;

namespace RecurlySharp.DTO{
    [XmlRoot("account")]
    public class Account{
        [XmlElement("hosted_login_token")]
        public string HostedLoginToken { get; set; }

        [XmlAttribute("href")]
        public string Href { get; set; }
    }
}