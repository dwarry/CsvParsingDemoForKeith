using System;
using System.IO;
using System.Linq;
using CsvParsingDemo_Core;
using Xunit;
using FluentAssertions;

namespace CsvParsingDemo_Core_Test
{
    public class PersonTests
    {
        [Fact]
        public void CanReadPeopleFromTextReader()
        {
            var data = @"'First Name','Last Name','Age'
'John','Smith',22
'David','Brown',45
'Ethan','Phillips',13
'Jason','Bourne',33
".Replace('\'', '"');

            var reader = new StringReader(data);

            var people = Person.ReadAllFrom(reader).ToList();

            people.Should().NotBeNullOrEmpty();
            people.Should().HaveCount(4);
            people.Should().NotContainNulls();

            people[0].FirstName.Should().Be("John");
            people[0].LastName.Should().Be("Smith");
            people[0].Age.Should().Be(22);

        }
    }
}
