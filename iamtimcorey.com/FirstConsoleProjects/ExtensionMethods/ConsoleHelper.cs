using System;

namespace ExtensionMethods
{
    public static class ConsoleHelper
    {
        public static string RequestString(this string message)
        {
            string output = "";

            while (string.IsNullOrEmpty(output))
            {
                Console.Write(message);
                output = Console.ReadLine();
            }

            return output;
        }

        public static int RequestInt(this string message)
        {
            return message.RequestInt(false);
        }

        public static int RequestInt(this string message, int minValue, int maxValue)
        {
            return message.RequestInt(true, minValue, maxValue);
        }

        private static int RequestInt(this string message, bool useMinMax, int minValue = 0, int maxValue = 0)
        {
            int output = 0;
            bool isValid = false;
            bool isInValidRange = true;

            while (isValid == false || isInValidRange == false)
            {
                Console.Write(message);
                isValid = int.TryParse(Console.ReadLine(), out output);

                if (useMinMax)
                {
                    isInValidRange = (output >= minValue && output <= maxValue);
                }
            }

            return output;
        }
    }
}
