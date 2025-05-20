namespace SOLID.utils
{
    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"LOG: {message}");
            Console.ReadLine();
        }
    }
}
