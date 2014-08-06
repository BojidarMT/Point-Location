using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Point_Location
{
    static void Main(string[] args)
    {
        Console.WriteLine("How many vertices the polygon has? ");
        int rows = int.Parse(Console.ReadLine());
        int cols = 2;
        int[,] points = new int[rows, 2];
        Console.WriteLine("Enter x coordinate of the searching point: ");
        double xq = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter y coordinate of the searching point: ");
        double yq = double.Parse(Console.ReadLine());

        for (int i = 0; i < rows; i++)
        {
            for (int k = 0; k < cols; k++)
            {
                Console.WriteLine("Enter coordinates of the vertices[{0}, {1}]", i, k);
                string coord = Console.ReadLine();
                points[i, k] = int.Parse(coord);
            }

        }
        Console.WriteLine();
        for (int i = 0; i < points.GetLength(0); i++)
        {
            for (int k = 0; k < points.GetLength(1); k++)
            {

                Console.Write("{0} ", points[i, k]);

            }
            Console.WriteLine();
        }

        double sumx = 0;
        double sumy = 0;
        for (int i = 0; i < 3; i++)
        {
            sumx = sumx + points[i, 0];
            sumy = sumy + points[i, 1];
        }

        double[] g = new double[2] { sumx / 3, sumy / 3 };

        var area = (points[0, 0] * g[1] + points[0, 1] * points[1, 0] + points[1, 1] * g[0])
                       - (g[1] * points[1, 0] + points[0, 1] * g[0] + points[0, 0] * points[1, 1]);

        Console.WriteLine();
        Console.WriteLine("Coordinates of a G median: " + "x= " + g[0] + " " + "y= " + g[1]);


        int start = 1;
        int end = rows;
        int medium;
        double anglePGQ;
        double anglePGSR;
        double[] pstart = new double[2];
        double[] pend = new double[2];
        while (end - start > 1)
        {
            pstart[0] = (points[start - 1, 0]);
            pstart[1] = (points[start - 1, 1]);

            pend[0] = (points[end - 1, 0]);
            pend[1] = (points[end - 1, 1]);

            medium = (start + end) / 2;
            double[] pmedium = new double[2] { points[medium - 1, 0], points[medium - 1, 1] };

            double[] vectorGP = new double[2] { pstart[0] - g[0], pstart[1] - g[1] };
            double[] vectorGQ = new double[2] { xq - g[0], yq - g[1] };
            double[] vectorGPmedium = new double[2] { pmedium[0] - g[0], pmedium[1] - g[1] };


            double radians1 = Math.Atan2(vectorGP[0], vectorGP[1]) - Math.Atan2(vectorGQ[0], vectorGQ[1]); // angle between the vectors
            anglePGQ = radians1 * (180 / Math.PI);
            double radians2 = Math.Atan2(vectorGP[0], vectorGP[1]) - Math.Atan2(vectorGPmedium[0], vectorGPmedium[1]);
            anglePGSR = radians2 * (180 / Math.PI);
            if (anglePGQ < anglePGSR)
            {
                end = medium;
            }
            else start = medium;


        }
        Console.WriteLine();
        Console.WriteLine("The point is in the region Point{0} - Gmedian - Point{1}", start, end);
        Console.WriteLine();

        double area2 = (pstart[0] * pend[1] + pstart[1] * xq + yq * pend[0]
                      - pend[1] * xq - pstart[1] * pend[0] - pstart[0] * yq);
        Console.WriteLine("Area " + area2);
        Console.WriteLine();
        if (area2 <= 0)
        {
            Console.WriteLine("The point don`t belongs to the polygon!");
        }

        else Console.WriteLine("The point belongs to the polygon!");
        Console.WriteLine();
    }
}

