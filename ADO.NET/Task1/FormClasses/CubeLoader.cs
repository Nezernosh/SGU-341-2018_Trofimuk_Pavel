using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ADO.NET.FormClasses
{
    class CubeLoader
    {
        public static Cube LoadFromTextFile(string path)
        {
            List<Point> vertices = new List<Point>();
            int numberOfCoordinates = 3;
            int numberOfVertices = 8;
            
            using (StreamReader streamReader = new StreamReader(path))
            {
                string line = streamReader.ReadLine();

                while (line != null && vertices.Count != numberOfVertices)
                {
                    string[] coordinates = line.Split(' ');

                    if (coordinates.Length != numberOfCoordinates)
                    {
                        throw new InvalidDataException("Only 3 coordinates allowed");
                    }

                    try
                    {
                        vertices.Add(
                            new Point(
                                double.Parse(coordinates[0]),
                                double.Parse(coordinates[1]),
                                double.Parse(coordinates[2])
                            )
                        );
                    }
                    catch
                    {
                        throw new InvalidDataException("Error with parsing coordinates");
                    }

                    line = streamReader.ReadLine();
                }
            }

            return new Cube(vertices);
        }    
    }
}
