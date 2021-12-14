using System;

namespace CommitLogView
{
    public class Startup
    {
        [STAThread]
        public static void Main(string[] args) 
        {
            App app = new App();
            app.Run();
        }
    }
}
