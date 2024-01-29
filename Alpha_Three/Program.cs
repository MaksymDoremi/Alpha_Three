using Alpha_Three.src.application;

namespace Alpha_Three
{
    class Program
    {
        public static void Main(string[] args)
        {
            Application.Print_message_line(DateTime.Now.ToString());
            Application app = new Application();
            int line = 30;

            Application.Print_message_line(String.Concat(Enumerable.Repeat("=", line)));
            Application.Print_message_line("Alpha_Three");
            Application.Print_message_line(String.Concat(Enumerable.Repeat("=", line)));
            Application.Print_message_line("");

            app.Run();

            Application.Print_message_line("");
            Application.Print_message_line(String.Concat(Enumerable.Repeat("=", line)));
            Application.Print_message_line("Alpha_Three shutdown");
            Application.Print_message_line(String.Concat(Enumerable.Repeat("=", line)));
        }
    }
}