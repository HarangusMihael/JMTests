using System;
using Xunit;

namespace CyclometerTest
{
    public class CyclometerTest
    {
        public enum Diameter
        {
            Diameter1=10,
            Diameter2=10          
        }
        [Fact]
        public void TotalDistance()
        {
            Participant FirstParticipant = new Participant(new int[] { 1,2,3,2,1}) ;
            Participant SecondParticipant = new Participant(new int[] { 1, 2, 2, 2, 1,1 });
            Assert.Equal((decimal)282.6+(decimal)282.6,
            actual: CalculateTotalDistance(FirstParticipant)+CalculateTotalDistance(SecondParticipant));
        }
       
        decimal CalculateTotalDistance(Participant Participant)
        {
            decimal TotalNumberOfRotations = 0;
            foreach(int i in Participant.RotationsPerSecond)
            {
                TotalNumberOfRotations += i;
            }
            return (int)Diameter.Diameter1*(decimal)3.14*TotalNumberOfRotations;
        }

        struct Participant
        {
            public int[] RotationsPerSecond;          
            public Participant(int[] RPS)
            {
                this.RotationsPerSecond = RPS;
            }
        }

    }
}
