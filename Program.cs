using System;
using System.Threading;

namespace SpinningDonut
{
    class Program
    {
        static void Main(string[] args)
        {
            double xRotation = 0, yRotation = 0, angle1, angle2;
            var depth = new double[7040];
            var screen = new char[1760];

            Console.SetWindowSize(80, 22);
            Console.CursorVisible = false;

            while (true)
            {
                ClearArray(screen, ' ');
                ClearArray(depth, 0.0);

                for (angle2 = 0; angle2 < Math.PI * 2; angle2 += 0.03)
                {
                    for (angle1 = 0; angle1 < Math.PI * 2; angle1 += 0.01)
                    {
                        double sin1 = Math.Sin(angle1);
                        double cos1 = Math.Cos(angle1);
                        double sin2 = Math.Sin(angle2);
                        double cos2 = Math.Cos(angle2);

                        double sinX = Math.Sin(xRotation);
                        double cosX = Math.Cos(xRotation);
                        double sinY = Math.Sin(yRotation);
                        double cosY = Math.Cos(yRotation);

                        double shapeWidth = cos2 + 2;
                        double zInverse = 1 / (sin1 * shapeWidth * sinX + sin2 * cosX + 5);
                        double zDepth = sin1 * shapeWidth * cosX - sin2 * sinX;

                        int x = (int)(40 + 30 * zInverse * (cos1 * shapeWidth * cosY - zDepth * sinY));
                        int y = (int)(12 + 15 * zInverse * (cos1 * shapeWidth * sinY + zDepth * cosY));
                        int index = x + 80 * y;
                        int brightness = (int)(8 * ((sin2 * sinX - sin1 * cos2 * cosX) * cosY - sin1 * cos2 * sinX - sin2 * cosX - cos1 * cos2 * sinY));

                        if (y >= 0 && y < 22 && x >= 0 && x < 80 && zInverse > depth[index])
                        {
                            depth[index] = zInverse;
                            screen[index] = ".,-~:;=!*#$@"[Math.Max(0, Math.Min(11, brightness))];
                        }
                    }
                }

                AddNewLines(screen);
                Console.SetCursorPosition(0, 0);
                Console.Write(new string(screen));
                Thread.Sleep(10);

                xRotation += 0.04;
                yRotation += 0.02;
            }
        }

        static void ClearArray<T>(T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }

        static void AddNewLines(char[] buffer)
        {
            for (int i = 79; i < buffer.Length; i += 80)
            {
                buffer[i] = '\n';
            }
        }
    }
}
