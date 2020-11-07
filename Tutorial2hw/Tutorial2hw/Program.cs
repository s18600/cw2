using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Tutorial2hw.Models;

namespace Tutorial2hw
{
    class Program
    {
        public static void Main(string[] args)
        {

            var pathSource = @"C:\Users\Oskar Gałczyński\Desktop\Tutorial2\Tutorial2hw\Tutorial2hw\DATA\dane.csv";
            var pathDest = @"result.xml";
            var dataType = "XML";

            if (File.Exists(pathSource))
            {
                var fileSource = new FileInfo(pathSource);
                var listOfStudents = new HashSet<Student>(new CustomComparer());
                var studiesName = new List<string>();

                using (var stream = new StreamReader(fileSource.OpenRead()))
                {
                    using var sw = new StreamWriter(@"log.txt");
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');
                        if (columns.Length != 9)
                        {
                            sw.WriteLine($"Osoba \"{line}\" nie spełnia wymagań - za mało kolumn");
                        }
                        else
                        {
                            bool a = false;
                            for (int i = 0; i < columns.Length; i++)
                            {
                                if (string.IsNullOrWhiteSpace(columns[i])) a = true;
                            }
                            if (a)
                            {
                                
                                sw.WriteLine($"Osoba \"{line}\" nie spełnia wymagań - jedno albo więcej pól jest pustych.");
                            }
                            else
                            {
                                Studies tempStudies = new Studies { name = columns[2], mode = columns[3] };
                                Student tempStudent = new Student
                                {
                                    IndexNumber = columns[4],
                                    FirstName = columns[0],
                                    LastName = columns[1],
                                    Birhtdate = columns[5],
                                    Email = columns[6],
                                    MothersName = columns[7],
                                    FathersName = columns[8],
                                    studies = tempStudies
                                };
                                if (!listOfStudents.Contains(tempStudent))
                                {
                                    listOfStudents.Add(tempStudent);
                                    if (!studiesName.Contains(tempStudies.name))
                                    {
                                        studiesName.Add(tempStudies.name);
                                    }

                                }
                                else
                                {
                                    sw.WriteLine($"Osoba \"{line}\" nie spełnia wymagań - duplikat");
                                }

                            }
                        }
                    }
                }

                var writer = new FileStream(pathDest, FileMode.Create);
                var serializer = new XmlSerializer(typeof(HashSet<Student>),
                                                    new XmlRootAttribute("uczelnia"));
                serializer.Serialize(writer, listOfStudents);

            }
            else
            {
                using var sw = new StreamWriter(@"log.txt");
                sw.WriteLine($"Plik nie istnieje");
                return;
            }

        }
    }
}
