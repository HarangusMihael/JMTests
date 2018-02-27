using System;
using Xunit;

namespace IntersectionTest
{
    public enum Directions
    {
        Left,
        Right,
        Up,
        Down,

    }
    public class UnitTest1
    {
        [Fact]
        public void IntersectionAndPointOfIntersection()
        {
            Directions[] Direction = new Directions[] { Directions.Right, Directions.Down,Directions.Right,
                                                        Directions.Up,Directions.Left};
            Assert.True(Verify(ArePointsIntersected(Direction)));
            Assert.Equal(new Point(1,0),PointOfIntersection(ArePointsIntersected(Direction)));
        }

        Point[] ArePointsIntersected(Directions[] direction)
        {
            Point[] array = new Point[direction.Length];
            int x = 0;
            int y = 0;
            for (int i = 0; i < direction.Length; i++)
            {
                Directions Case = direction[i];
                switch (Case)
                {
                    case Directions.Right:
                        x += 1;
                        array[i] = new Point(x, y);
                        break;
                    case Directions.Left:
                        x -= 1;
                        array[i] = new Point(x, y);
                        break;
                    case Directions.Up:
                        y += 1;
                        array[i] = new Point(x, y);
                        break;
                    case Directions.Down:
                        y -= 1;
                        array[i] = new Point(x, y);
                        break;
                }
            }

            return array;

        }

        bool Verify(Point[] Points)
        {
            for (int i = 0; i < Points.Length - 1; i++)
            {
                for (int j = i + 1; j < Points.Length; j++)
                    if (Points[i].x == Points[j].x && Points[i].y == Points[j].y)
                        return true;                      
            }
            return false;
        }

        dynamic PointOfIntersection(Point[] Points)
        {
            
            for (int i = 0; i < Points.Length; i++)
            {            
                for (int j = i + 1; j < Points.Length; j++)
                {
                    if (Points[i].x == Points[j].x && Points[i].y == Points[j].y)

                        return Points[i];                
                }
                break;
            }
            return false;
        }

        struct Point
        {
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
           
        }
    }
}
