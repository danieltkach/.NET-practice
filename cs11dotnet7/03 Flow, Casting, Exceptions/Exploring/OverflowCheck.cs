namespace Exploring
{
    public static class OverflowCheck
    {
        public static void TestOverflow()
        {
            int max = 500;
            try
            {
                checked
                {
                    for (byte i = 0; i < max; i++)
                    {
                        Console.Write($"{i} ");
                    }
                }

            }
            catch (OverflowException)
            {
                Console.WriteLine("Operation overflow.\n");
            }
        }
    }
}
