using System;
using static MathTrigonometryExtensions.TrigonometryExtension;


namespace DllTestsProg
{
    class Program
    {
        static void ShowTestResultMessage<T>(string testInfo, T result, T expectedResult) where T : IComparable<T>
        {
            string testStatus = (result.CompareTo(expectedResult) == 0) ? "[passed]" : "[ failed ]";
            Console.WriteLine($"{testStatus} {testInfo} - Result:[{result}], Expected result [{expectedResult}]");
        }

        public static void Test_CalulateTriangleArea()
        {
            Console.WriteLine("---Test_CalculateTriangleArea---");
            ShowTestResultMessage("Regular triangle", TriangleArea(12, 23, 14), 69.4509719154455);

            //Right triangle sides (rts)
            double[] rts = new double[3] { 3, 4, 5 };
            bool triangleIsRight = RightTriangleCheck(rts[0], rts[1], rts[2]);
            ShowTestResultMessage("Right triangle check (used in the next method)", triangleIsRight, true);
            ShowTestResultMessage("Right triangle", TriangleArea(rts[0], rts[1], rts[2]), 6);

            ShowTestResultMessage("Incorrect input (negative values)", TriangleArea(-1, 6, 2), -1);
            ShowTestResultMessage("Incorrect input (impossible triangle)", TriangleArea(1, 2, 1000), -1);
            Console.WriteLine();
        }

        public static void Test_CalculateCircleArea()
        {
            Console.WriteLine("---Test_CalculateCircleArea---");
            ShowTestResultMessage("Regular circle", CircleArea(10), Math.PI * 10 * 10);
            ShowTestResultMessage("Incorrect input (negative value)", CircleArea(-100), -1);
            ShowTestResultMessage("Debatale input (zero value). Answer depends on specifics (could be 0 or -1)", CircleArea(-100), -1);
            Console.WriteLine();
        }

        public static void Test_CalulatePolygonArea()
        {
            Console.WriteLine("---Test_CalculatePolygonArea---");
            double result;
            //Clockwise order
            result = PolygonArea(new Point[] { new Point(0,0), new Point(0, 2),
                                               new Point(2, 2), new Point(2, 0)});
            ShowTestResultMessage("Square (points in clockwise order)", result, 4);


            result = PolygonArea(new Point[] { new Point(0,0), new Point(2, 0),
                                               new Point(2, 2), new Point(0, 2)});
            ShowTestResultMessage("Same as prev Square, but points in anticlockwise order", result, 4);


            result = PolygonArea(new Point[] { new Point(0,0), new Point(2, 0),
                                               new Point(0, 2)});
            ShowTestResultMessage("Right triangle", result, 2);


            result = PolygonArea(new Point[] { new Point(0,0), new Point(4, 0),
                                               new Point(3,3), new Point(6, 3),
                                               new Point(4,6), new Point(3, 4),
                                               new Point(2,7), new Point(0, 7)});
            ShowTestResultMessage("Non-convex shape", result, 26);


            result = PolygonArea(new Point[] { new Point(3,0), new Point(4, 0),
                                               new Point(5,0)});
            ShowTestResultMessage("0 area - all points on the same line", result, -1);


            result = PolygonArea(new Point[] { new Point(0, 0), new Point(7, 6) });
            ShowTestResultMessage("Incorrect input (shape with only 2 points)", result, -1);

            //(mb should not be a problem to solve)
            result = PolygonArea(new Point[] { new Point(0,0), new Point(0,1),
                                               new Point(0,2), new Point(0,3),
                                               new Point(3,0)});
            ShowTestResultMessage("Shape with most of the points lying on the same line (triangle with 5 points)", result, 4.5);

            Console.WriteLine();
        }

        static void Main()
        {
            Test_CalulateTriangleArea();
            Test_CalculateCircleArea();
            Test_CalulatePolygonArea();
        }
    }
}
