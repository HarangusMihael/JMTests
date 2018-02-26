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

                TotalDistance += Participant[i].IndividualDistance;
            }
            return TotalDistance;
        }

        

        string NameOfFastest(Participant[] Participant)
        {
            decimal speed = 0;
            decimal TopSpeed = 0;
            int k = 0;
            for (int i = 0; i < Participant.Length; i++)
            {
                speed = Participant[i].TopRotation;
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
                second = Participant[i].TopRotation;
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
             IndividualSpeed = Participant[i].IndividualDistance / Participant[i].RotationsPerSecond.Length;
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
            public decimal TopRotation;
            public decimal IndividualDistance;
            public Participant(int[] RPS,int diameter,string name)
            {
                this.RotationsPerSecond = RPS;
                this.Diameter = diameter;
                this.Name = name;

                decimal CalculateTopRotation(int[] RotationsPerSecond)
                {
                    int k = 0;
                    foreach (int i in RotationsPerSecond)
                    {
                        if (i > k)
                            k = i;
                    }

                    return diameter * k * (decimal)3.14;
                }
                this.TopRotation = CalculateTopRotation(RPS);

                decimal CalculateIndividualDistance(int[] RotationsPerSecond)
                {
                    decimal NumberOfRotations = 0;
                    foreach (int i in RotationsPerSecond)
                    {
                        NumberOfRotations += i;
                    }
                    return diameter * (decimal)3.14 * NumberOfRotations;
                }
                this.IndividualDistance = CalculateIndividualDistance(RPS);
            }
            
        }

    }
}
