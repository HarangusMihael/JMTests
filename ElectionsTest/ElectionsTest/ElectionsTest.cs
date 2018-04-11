using System;
using Xunit;

namespace ElectionsTest
{
    public class ElectionsTest
    {
        [Fact]
        public void Test1()
        {
            var section1 = new Candidate[] { new Candidate("first", 15), new Candidate("second", 10) };
            var section2 = new Candidate[] { new Candidate("first", 20), new Candidate("second", 30) };
            var Total = new PollingStation[] { new PollingStation(section1), new PollingStation(section2) };
            var expected = new Candidate[] { new Candidate("second", 40), new Candidate("first", 35) };            
            Assert.Equal(expected, IndividualTotalNumberOfVotes(Total));
        }

        [Fact]
        public void Test2()
        {
            var names = new Candidate[] { new Candidate("ac", 1), new Candidate("c", 1), new Candidate("ab", 1) };
            var result = new Candidate[] { new Candidate("ab", 1), new Candidate("ac", 1), new Candidate("c", 1) };
            Assert.Equal(result, MergeSort(names, true));
        }

        [Fact]
        public void Test3()
        {
            var names = new Candidate[] { new Candidate("a", 1), new Candidate("c", 3), new Candidate("b", 2) };
            var result = new Candidate[] { new Candidate("c", 3), new Candidate("b", 2), new Candidate("a", 1) };
            Assert.Equal(result, MergeSort(names, false));
        }

        [Fact]
        public void Test4()
        {
            var section1 = new Candidate[] { new Candidate("first", 15), new Candidate("second", 10), new Candidate("third", 20) };
            var section2 = new Candidate[] { new Candidate("first", 20), new Candidate("second", 30), new Candidate("third", 10) };
            var Total = new PollingStation[] { new PollingStation(section1), new PollingStation(section2) };
            var expected = new Candidate[] { new Candidate("second", 40), new Candidate("first", 35), new Candidate("third", 30) };
            Assert.Equal(expected, IndividualTotalNumberOfVotes(Total));
        }

        Candidate[] IndividualTotalNumberOfVotes(PollingStation[] total)
        {
            return OrderCandidatesByNumberOfVotes(CentralizeVotes(total));
        }

        private Candidate[] CentralizeVotes(PollingStation[] total)
        {
            Candidate[] result = OrderCandidatesByName(total[0].Candidates);
            for (int i = 1; i < total.Length; i++)
            {
                result = AddVotes(result, OrderCandidatesByName(total[i].Candidates));
            }

            return result;
        }

        Candidate[] OrderCandidatesByNumberOfVotes(Candidate[] input)
        {
            return OrderCandidates(input, false);
        }

        Candidate[] OrderCandidatesByName(Candidate[] input)
        {
            return OrderCandidates(input, true);
        }

        Candidate[] OrderCandidates(Candidate[] input, bool sortByName)
        {
            return sortByName == true ? MergeSort(input, sortByName) : MergeSort(input, false);
        }

        void MergeSort(Candidate[] input, int left, int right, bool sortByName)
        {
            if (input.Length <= 1 || left >= right)
            {
                return;
            }

            var mid = (left + right) / 2;
            MergeSort(input, left, mid, sortByName);
            MergeSort(input, mid + 1, right, sortByName);
            Merge(input, left, mid, right, sortByName);
        }

        Candidate[] MergeSort(Candidate[] input, bool sortByName)
        {
            MergeSort(input, 0, input.Length - 1, sortByName);
            return input;
        }

        private Candidate[] AddVotes(Candidate[] result, Candidate[] toAdd)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i].NumberOfVotes += toAdd[i].NumberOfVotes;
            }
            
            return result;
        }

        void Merge(Candidate[] input, int left, int mid, int right, bool sortByName = true)
        {
            int i = left;
            int j = mid + 1;
            int k = 0;
            Candidate[] result = new Candidate[right - left + 1];

            while (i <= mid && j <= right)
            {
                if (input[i].Compare(input[j], sortByName))
                {
                    result[k] = input[i];
                    i++;
                }
                else
                {
                    result[k] = input[j];
                    j++;
                }

                k++;
            }

            while (i <= mid)
            {
                result[k] = input[i];
                i++;
                k++;
            }

            while (j <= right)
            {
                result[k] = input[j];
                j++;
                k++;
            }

            Array.Copy(result, 0, input, left, result.Length);
        }
        
        struct Candidate
        {
            public int NumberOfVotes;
            public string Name;

            public Candidate(string name, int votes)
            {
                this.NumberOfVotes = votes;
                this.Name = name;
            }

            public bool Compare(Candidate other, bool byName)
            {
                return byName
                    ? string.Compare(Name, other.Name, true) == -1
                    : NumberOfVotes > other.NumberOfVotes;
            }

            public override string ToString()
            {
                return $"{Name} - {NumberOfVotes}";
            }
        }

        struct PollingStation
        {
            public Candidate[] Candidates;

            public PollingStation(Candidate[] section)
            {
                this.Candidates = section;
            }
        }
    }
}
