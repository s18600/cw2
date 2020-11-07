using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2hw.Models
{
    public class Student
    {
        [XmlAttribute(attributeName: "index")]
        public string IndexNumber { get; set; }

        [XmlElement(elementName: "fname")]
        public string FirstName { get; set; }

        [XmlElement(elementName: "lname")]
        public string LastName { get; set; }

        [XmlElement(elementName: "birthdate")]
        public string Birhtdate { get; set; }

        [XmlElement(elementName: "email")]
        public string Email { get; set; }

        [XmlElement(elementName: "mothersName")]
        public string MothersName { get; set; }

        [XmlElement(elementName: "fathersName")]
        public string FathersName { get; set; }

        [XmlElement(elementName: "studies")]

        public Studies studies;             

    }
}
