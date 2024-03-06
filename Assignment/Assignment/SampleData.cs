using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment;

public class SampleData : ISampleData
{
    // 1.
    public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1);

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        => CsvRows.Select(item => item.Split(',')[6]).Distinct().Order();

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
        => String.Join(',', GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

    // 4.
    public IEnumerable<IPerson> People =>
        (from id in CsvRows
         let item = id.Split(',')
         orderby item[6], item[5], item[7]
         select new Person(item[1], item[2], new Address(item[4], item[5], item[6], item[7]), item[3])
         );

     // 5.
     public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
         Predicate<string> filter) => People.Where(person =>filter(person.EmailAddress)).Select(person =>(person.FirstName, person.LastName));

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people) => people.Select(person => person.Address.State).Distinct().Aggregate((list, state) => $"{list}, {state}");
}

