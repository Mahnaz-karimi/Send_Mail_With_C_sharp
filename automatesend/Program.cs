
using System.Timers;

namespace automatesend
{
    
    internal static class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Form1 myform = new Form1();            
            Application.Run(myform);
            ListController listCont = new ListController();
            listCont.ReadDatafromCSV();



        }
        
    }
}