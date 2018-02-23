using System;
using Xunit;

namespace AlarmTest
{
    public class AlarmTest
    {
        [FlagsAttribute]
        public enum DaysOfTheWeek
        {
            Monday=1,
            Tuesday=2,
            Wednesday=4,
            Thursday=8,
            Friday=16,
            Saturday=32,
            Sunday=64

        }

        [Fact]
        public void Test1()
        {
            int Hour = 8;
            Alarm Alarm = new Alarm(Hour, DaysOfTheWeek.Monday | DaysOfTheWeek.Tuesday);

            Assert.True(Verify(8, DaysOfTheWeek.Monday , Alarm));
            

        }

        bool  Verify(int Hour, DaysOfTheWeek Day, Alarm Alarm)
        {


            return ((Day & Alarm.Days) != 0 && Hour == Alarm.Hour);
          
        }


        struct Alarm
        {
            public int Hour;
            public DaysOfTheWeek Days;
            public Alarm(int Hour,DaysOfTheWeek Days)
            {
                this.Hour = Hour;
                this.Days = Days;
            }
        }
    }
}
