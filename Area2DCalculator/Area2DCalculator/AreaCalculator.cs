using System;

namespace MathTrigonometryExtensions
{
    public static class TrigonometryExtension
    {
        /// <summary>
        /// Point representation in 2d Space
        /// </summary>
        public struct Point
        {
            public double x { get; }
            public double y { get; }

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            /// <summary>
            /// Creates string representation of coordinates of the point (x, y)
            /// </summary>
            /// <returns> Returns point coordinates string representation</returns>
            public override string ToString()
            {
                return $"{x}, {y}";
            }
        }


        static bool RightTriangleCheckWithKnownHypotenuse(double hypotenuse, double leg1, double leg2)
        {
            return hypotenuse * hypotenuse == leg1 * leg1 + leg2 * leg2;
        }

        /// <summary>
        /// Checks if triangle is right based on its sides
        /// </summary>
        /// <param name="side1">Preferably a hypotenuse</param>
        /// <returns></returns>
        public static bool RightTriangleCheck(double side1, double side2, double side3)
        {
            if (side1 > side2 && side1 > side3 && RightTriangleCheckWithKnownHypotenuse(side1, side2, side3)) return true;
            if (side2 > side1 && side2 > side3 && RightTriangleCheckWithKnownHypotenuse(side2, side1, side3)) return true;
            if (side3 > side1 && side3 > side2 && RightTriangleCheckWithKnownHypotenuse(side3, side1, side2)) return true;
            return false;
        }

        /// <summary>
        /// Calculates the area of a triangle from its sides length.
        /// </summary>
        /// <returns>Returns -1 if triangle with provided sides is not viable</returns>
        public static double TriangleArea(double side1, double side2, double side3)
        {
            #region Parameter checks
            //Negative/zeros check
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                //Console.WriteLine("Invalid input");
                return -1;
            }

            //Triangle Inequality rule check
            if (side1 > side2 + side3 || side2 > side1 + side3 || side3 > side1 + side2)
            {
                //Console.WriteLine("Triangle rule check failed");
                return -1;
            }
            #endregion

            //Solution for right triangle
            if (side1>side2 && side1>side3 && RightTriangleCheckWithKnownHypotenuse(side1, side2, side3)) return side2 * side3 / 2;
            if (side2>side1 && side2>side3 && RightTriangleCheckWithKnownHypotenuse(side2, side1, side3)) return side1 * side3 / 2;
            if (side3>side1 && side3>side2 && RightTriangleCheckWithKnownHypotenuse(side3, side1, side2)) return side1 * side2 / 2;

            //General solution through semiPerimeter
            double sP = (side1 + side2 + side3) / 2;
            return Math.Sqrt(sP * (sP - side1) * (sP - side2) * (sP - side3));
        }

        /// <summary>
        /// Calculates area of a circle by its radius
        /// </summary>
        /// <returns>Returns -1 if radius<0 </returns>
        public static double CircleArea(double radius)
        {
            if (radius < 0) return -1;
            return Math.PI * radius * radius;
        }

        /// <summary>
        /// Caluculates polygon area by provided points in original sequential order. 
        /// </summary>
        /// <param name="points">Coordinates of points in 2d space.</param>
        /// <returns>Returns -1 if polygon is invalid</returns>
        public static double PolygonArea(Point[] points)
        {
            #region Parameter checks 
            //Figure must have >2 point to calculate its area
            if (points.Length < 3) return -1;

            //Checks for identical points
            for (int i = 0; i < points.Length; ++i)
                for (int j = 0; j < points.Length; ++j)
                {
                    if (i == j) continue;
                    if (points[i].x == points[j].x && points[i].y == points[j].y)
                    {
                        //If points is identical
                        //Console.WriteLine("Identical points");
                        return -1;
                    }
                }

            //Checks if all points lies on the same line
            bool xNotChange = true, yNotChange = true;
            for (int i = 0; i < points.Length; ++i)
                for (int j = 0; j < points.Length; ++j)
                {
                    if (points[i].x != points[j].x) xNotChange = false;
                    if (points[i].y != points[j].y) yNotChange = false;
                }
            if (xNotChange || yNotChange)
            {
                //Console.WriteLine($"Every point lies on the same line {xNotChange} {yNotChange}");
                return -1;
            }
            #endregion

            //Shoelace (Gauss's area) formula implementation
            double sum1 = 0, sum2 = 0;
            for (int i = 0; i < points.Length - 1; ++i)
            {
                sum1 += points[i].x * points[i + 1].y;
                sum2 += points[i + 1].x * points[i].y;
            }

            sum1 += points[points.Length - 1].x * points[0].y;
            sum2 += points[0].x * points[points.Length - 1].y;

            return Math.Abs(sum1 - sum2) / 2;
        }
    }
}
