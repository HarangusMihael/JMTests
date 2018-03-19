using System;
using Xunit;

namespace ElectionsTest
{
    public class ElectionsTest
    {
        [Fact]
        public void Test1()
        {
            var Section1 = new Candidates[] { new Candidates("first", 15), new Candidates("second", 10) };
            var Section2= new Candidates[] { new Candidates("first", 20), new Candidates("second", 10) };
            var Total = new PollingStation[] { new PollingStation(Section1), new PollingStation(Section2) };
            var expected = new Candidates[] { new Candidates("first", 35), new Candidates("second", 20) };
            Assert.Equal();
        }

        Candidates[] TotalNumberOfVotes(PollingStation[] List)
        {
            Candidates[] length = List[0];
            Candidates[] FinalList = new Candidates[];

            return null;
        }
       
        struct Candidates
        {
            public int NumberOfVotes;
            public string Name;
            public Candidates(string name, int votes)
            {
                this.NumberOfVotes = votes;
                this.Name = name;
            }
        }

        struct PollingStation
        {
            public Candidates[] SectionNumber;
            public PollingStation(Candidates[] section)
            {
                this.SectionNumber = section;
            }
        }
    }
}
