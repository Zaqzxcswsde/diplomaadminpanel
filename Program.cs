namespace diplomaadminpanel
{
    internal static class Program
    {
        //public static SynchronizationContext? UISyncContext;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            DotNetEnv.Env.Load();
            ApplicationConfiguration.Initialize();
            Application.Run(new Forms.FormMain());
        }
    }
}