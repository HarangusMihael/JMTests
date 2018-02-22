using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Alarm alarm = new Alarm ( "Monday", 8 );
            Assert.True(SetAlarm(alarm,8));
        }

        bool SetAlarm(Alarm Day,int hour)
        {
            if (Day.hour == hour)
            {
                return true;
            }
            return false;
        }

        struct Alarm
        {
           public string day;
           public int hour;
            public Alarm(string Day, int Hour)
            {
                this.day = Day;
                this.hour = Hour;
            }

        }
    }
}
