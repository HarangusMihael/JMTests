using System;
using Xunit;

namespace IntersectionTest
{
    public enum Directions
    {
        Left,
        Right,
        Up,
        Down

    }
    public class UnitTest1
    {
        [Fact]
        public void IntersectionAndPointOfIntersection()
        {
            Directions[] Direction = new Directions[] { Directions.Right, Directions.Down,Directions.Right,
                                                        Directions.Up,Directions.Left };
            Assert.True(Verify(ArePointsIntersected(Direction)));
            Assert.Equal(new Point(1, 0), PointOfIntersection(ArePointsIntersected(Direction)));
        }



        Point[] ArePointsIntersected(Directions[] direction)
        {
            Point[] array = new Point[direction.Length];
            int x = 0;
            int y = 0;
            for(int i = 0; i < direction.Length; i++)
            {
                if (direction[i] == Directions.Right)
                    array[i] = new Point(x + 1, y);
                if (direction[i] == Directions.Left)
                    array[i] = new Point(x - 1, y);
                if (direction[i] == Directions.Up)
                    array[i] = new Point(x, y+1);
                if (direction[i] == Directions.Down)
                    array[i] = new Point(x, y-1);
            }

            return array;
            
        }

        bool Verify(Point[] Points)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                for (int j = i+1; j < Points.Length; j++)
                    if (Points[i].x == Points[j].x && Points[i].y==Points[j].y)
                        return true;
            }
            return false;
        }

        Point PointOfIntersection(Point[] Points)
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
            return new Point(0, 0);
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
