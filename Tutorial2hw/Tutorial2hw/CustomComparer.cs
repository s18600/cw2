using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tutorial2hw.Models;

namespace Tutorial2hw
{
    public class CustomComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer
                        .InvariantCultureIgnoreCase
                        .Equals($"{x.IndexNumber} {x.FirstName} {x.LastName} {x.Birhtdate} {x.Email} {x.MothersName} {x.FathersName} {x.studies}",
                                $"{x.IndexNumber} {x.FirstName} {x.LastName} {x.Birhtdate} {x.Email} {x.MothersName} {x.FathersName} {x.studies}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer.
                    CurrentCultureIgnoreCase
                    .GetHashCode($"{obj.IndexNumber} {obj.FirstName} {obj.LastName} {obj.Birhtdate} {obj.Email} {obj.MothersName} {obj.FathersName} {obj.studies}");
        }
    }
}
