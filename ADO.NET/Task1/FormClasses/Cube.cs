using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ADO.NET.FormClasses
{
    class Cube
    {
        private List<Point> _vertices;

        public List<Point> Vertices
        {
            get => _vertices;
            private set
            {
                if (value == null || value.Any(x => x == null)) throw new ArgumentNullException();
                if (!IsValid(value)) throw new InvalidDataException();
                _vertices = value;
            }
        }
        public double EdgeLength { get; private set; }
        public double Area { get; }
        public double Volume { get; }

        public Cube(List<Point> vertices)
        {            
            Vertices = vertices;
            EdgeLength = GetLength();
            Area = GetArea();
            Volume = GetVolume();
        }

        private double GetLength()
        {
            return Vertices.OrderBy(x => x.GetDistance(Vertices.First()))
                .ElementAt(1).GetDistance(Vertices.First());
        }

        private double GetArea()
        {
            return EdgeLength * EdgeLength;
        }

        private double GetVolume()
        {
            return Area * EdgeLength;
        }

        private bool IsValid(List<Point> vertices)
        {
            double edgeLength = vertices.OrderBy(x => x.GetDistance(vertices.First()))
                .ElementAt(1).GetDistance(vertices.First());
            bool valid = false;

            const double Accuracy = 0.0001;
  
            double cubeEdgeDiagonal = Math.Sqrt(2) * edgeLength;
            double cubeDiagonal = Math.Sqrt(3) * edgeLength;
            int cubeEdgeCounter = 0,
                cubeEdgeDiagonalCounter = 0,
                cubeDiagonalCounter = 0;

            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = 0; j < vertices.Count; j++)
                {
                    if (Math.Abs(vertices[i].GetDistance(vertices[j]) - edgeLength) < Accuracy)
                    {
                        cubeEdgeCounter++;
                        continue;
                    }

                    if (Math.Abs(vertices[i].GetDistance(vertices[j]) - cubeEdgeDiagonal) < Accuracy)
                    {
                        cubeEdgeDiagonalCounter++;
                        continue;
                    }

                    if (Math.Abs(vertices[i].GetDistance(vertices[j]) - cubeDiagonal) < Accuracy)
                    {
                        cubeDiagonalCounter++;
                    }
                }

                if (cubeEdgeCounter == 3 && cubeEdgeDiagonalCounter == 3 && cubeDiagonalCounter == 1)
                {
                    valid = true;
                }
            }

            return valid;
        }
    }
}
