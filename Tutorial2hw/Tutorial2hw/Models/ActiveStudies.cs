using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2hw.Models
{
    public class ActiveStudies
    {
        [XmlAttribute(attributeName: "name")]
        public string name{ get; set; }
    }
}
