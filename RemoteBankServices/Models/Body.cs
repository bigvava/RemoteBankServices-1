using System;
using System.Xml.Serialization;

namespace RemoteBankServices.Models
{
    [Serializable]
    [XmlRoot("body")]
    public class Body
    {
        //<body>
        public string language_prefix { get; set; }
        public DateTime created_at { get; set; }
        public string interest { get; set; }
        public string first_name_short { get; set; } 
        public string geocheckbox { get; set; }
        [XmlElement("e-mail-short")]
        public string email_short { get; set; } //e-mail-short
        public int uuid { get; set; }
        public int id { get; set; }
        [XmlElement("phone-short")]
        public string phone_short { get; set; } //phone-short
        public string surname_short { get; set; }
        public int formtype { get; set; }
        //</body>


    }
}

//<body>
//  <language_prefix>ka</language_prefix>
//  <created_at>2022-08-25 08:16:22</created_at>
//  <interest>flexfund-overdraft</interest>
//  <first_name_short>ზვიად</first_name_short>
//  <geocheckbox>on</geocheckbox>
//  <e-mail-short>zchunashvili@yahoo.com</e-mail-short>
//  <uuid>800365</uuid>
//  <id>67997</id>
//  <phone-short>577054486</phone-short>
//  <surname_short>ჭუნაშვილი</surname_short>
//  <formtype>3</formtype>
//</body>