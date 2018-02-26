using System;
using Xunit;

namespace CyclometerTest
{
    public class CyclometerTest
    {
        [Fact]
        public void TotalDistance()
        {
            Participant FirstParticipant = new Participant(new int[] { 1,2,4,3},10,"Mike") ;
            Participant SecondParticipant = new Participant(new int[] { 1,3,5,1 },10,"Marc");
            Assert.Equal(628, CalculateTotalDistance(new Participant[] { FirstParticipant, SecondParticipant }));
        }
        [Fact]
        public void TopSpeed()
        {
            Participant FirstParticipant = new Participant(new int[] { 1, 2, 4, 2 }, 10, "Mike");
            Participant SecondParticipant = new Participant(new int[] { 1, 6, 5, 2 }, 10, "Marc");
            Assert.Equal("Marc",NameOfFastest(new Participant[] { FirstParticipant,SecondParticipant}));
            Assert.Equal(2, SecondOfFastest(new Participant[] { FirstParticipant, SecondParticipant }));
        }
       [Fact]
       public void HighestMediumSpeed()
        {
            Participant FirstParticipant = new Participant(new int[] { 1, 2, 4, 2 }, 17, "Mike");
            Participant SecondParticipant = new Participant(new int[] { 1, 6, 5, 2 }, 10, "Marc");
            Assert.Equal("Mike", CalculateTopMediumSpeed(new Participant[] { FirstParticipant, SecondParticipant }));
        }
     
        decimal CalculateTotalDistance(Participant[] Participant)
        {
            decimal TotalDistance = 0;
            for(int i=0;i<Participant.Length;i++)
            {

                TotalDistance += CalculateIndividualDistance(Participant[i]);
            }
            return TotalDistance;
        }

        decimal CalculateIndividualDistance(Participant Participant)
        {
            decimal NumberOfRotations = 0;
            foreach(int i in Participant.RotationsPerSecond)
            {
                NumberOfRotations += i;
            }
            return Participant.Diameter * (decimal)3.14 * NumberOfRotations;
        }

        decimal CalculateTopRotation(Participant Participant)
        {
            int k = 0;
            foreach(int i in Participant.RotationsPerSecond)
            {
                if (i > k)
                    k = i;
            }
            
            return Participant.Diameter*k*(decimal)3.14;

        }
        string NameOfFastest(Participant[] Participant)
        {
            decimal speed = 0;
            decimal TopSpeed = 0;
            int k = 0;
            for (int i = 0; i < Participant.Length; i++)
            {
                speed = CalculateTopRotation(Participant[i]);
                if (speed > TopSpeed)
                {   TopSpeed = speed;
                    k = i;
                }
            }

            return Participant[k].Name;
        }

        decimal SecondOfFastest(Participant[] Participant)
        {
            Participant Temp=new Participant();
            decimal second = 0;
            decimal TopSpeed=0;
            int c = 0;
            for (int i = 0; i < Participant.Length; i++)
            {
                second = CalculateTopRotation(Participant[i]);
                if (second > TopSpeed)
                {
                    TopSpeed = second;
                    Temp = Participant[i];
                }
            }
            second = 0;
            for(int i=0;i< Temp.RotationsPerSecond.Length;i++)
            {
                if (Temp.RotationsPerSecond[i] > c)
                {
                    c = Temp.RotationsPerSecond[i];
                    second = i;
                }
            }

            return second+1;
        }

        string CalculateTopMediumSpeed(Participant[] Participant)
        {
            decimal IndividualSpeed = 0;
            decimal speed = 0;
            int k = 0;
            for (int i=0; i < Participant.Length;i++)
            {
             IndividualSpeed = CalculateIndividualDistance(Participant[i]) / Participant[i].RotationsPerSecond.Length;
                if (IndividualSpeed > speed)
                {
                    speed = IndividualSpeed;
                    k = i;
                }
            }
            return Participant[k].Name;
        }

        struct Participant
        {
            public int[] RotationsPerSecond;
            public int Diameter;
            public string Name;
            public Participant(int[] RPS,int diameter,string name)
            {
                this.RotationsPerSecond = RPS;
                this.Diameter = diameter;
                this.Name = name;
            }
        }

    }
}
