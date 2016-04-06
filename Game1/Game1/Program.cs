using System;

namespace Game1
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Connect con = new Connect();
            con.RunSQLStatement("select * from user where username = ?", "dahlan1337");
            
            using (var game = new Game1())
               game.Run();
            
            
        }
    }
#endif
}
