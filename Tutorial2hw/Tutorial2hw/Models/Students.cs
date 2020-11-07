using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2hw.Models
{
    public class Students
    {
        [XmlArrayAttribute(elementName: "students")]
        public Student[] students;
    }
}
