using Alpha_Three.src.application;

namespace Alpha_Three
{
    class Program
    {
        public static void Main(string[] args)
        {
            Application app = new Application();
            int line = 30;

            Console.WriteLine(String.Concat(Enumerable.Repeat("=", line)));
            Console.WriteLine("Alpha_Three");
            Console.WriteLine(String.Concat(Enumerable.Repeat("=", line)));
            Console.WriteLine();

            app.Run();

            Console.WriteLine();
            Console.WriteLine(String.Concat(Enumerable.Repeat("=", line)));
            Console.WriteLine("Alpha_Three shutdown");
            Console.WriteLine(String.Concat(Enumerable.Repeat("=", line)));
        }
    }
}