using Alpha_Three.src.application;
using Alpha_Three.src.db;
using Alpha_Three.src.logger;
using System.Data;

namespace Alpha_Three
{
    class Program
    {
        public static void Main(string[] args)
        {
            Application app = new Application();
            int line = 30;

            Application.Print_message_line(String.Concat(Enumerable.Repeat("=", line)));
            Application.Print_message_line("Alpha_Three");
            Application.Print_message_line(String.Concat(Enumerable.Repeat("=", line)));
            Application.Print_message_line("");

            try
            {
                // try to open connection
                if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
                {
                    DatabaseConnection.GetConnection().Open();
                }

                DatabaseConnection.GetConnection().Close();
                //Run application
                app.Run();
            }
            catch (Exception ex)
            {
                Application.Print_message_line("Couldn't connect to database. We are gonna try 3 more times with 2 second interval.\n");
                Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                // In case database can't connect
                // try to connect 3 times

                int attempts = 3;

                for (int i = 0; i < attempts; i++)
                {
                    try
                    {
                        Thread.Sleep(2000);
                        if (DatabaseConnection.GetConnection().State == ConnectionState.Closed)
                        {
                            DatabaseConnection.GetConnection().Open();
                        }
                        DatabaseConnection.GetConnection().Close();
                        Application.Print_message_line($"Attempt {i + 1}. Success.\n");
                        Application.Print_message_line($"Run application\n");
                        //Run again after successful connection
                        app.Run();
                        break;
                    }
                    catch (Exception ex2)
                    {
                        Application.Print_message_line($"Attempt {i + 1}. Couldn't connect to database.\n");
                        Logger.WriteLog($"{ex.Message}\n{ex.StackTrace}", true);
                    }
                }
            }
            finally
            {
                Application.Print_message_line("");
                Application.Print_message_line(String.Concat(Enumerable.Repeat("=", line)));
                Application.Print_message_line("Alpha_Three shutdown");
                Application.Print_message_line(String.Concat(Enumerable.Repeat("=", line)));
            }



        }
    }
}