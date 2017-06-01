using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;

namespace CsvParsingDemo_Core
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public override string ToString() => $"Person (Name = '{FirstName} {LastName}', Age={Age})";
        

        public static IEnumerable<Person> ReadAllFrom(TextReader reader)
        {
            var config = new CsvConfiguration();
            config.HasHeaderRecord = true;
            config.RegisterClassMap<PersonMap>();
            using (var csv = new CsvHelper.CsvReader(reader, config))
            {
                while (csv.Read())
                {
                    yield return csv.GetRecord<Person>();
                }
            }
        }

        private class PersonMap : CsvClassMap<Person>
        {
            public PersonMap()
            {
                Map(m => m.FirstName).Name("First Name");
                Map(m => m.LastName).Name("Last Name");
                Map(m => m.Age).Name("Age");
            }
        }
    }

}
