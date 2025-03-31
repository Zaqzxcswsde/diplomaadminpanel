using dotenv.net;

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
            //DotEnv.Load(options: new DotEnvOptions(probeForEnv: true, probeLevelsToSearch: 2));
            DotEnv.Load();
            ApplicationConfiguration.Initialize();
            Application.Run(new Forms.FormMain());
            //Application.Run(new Forms.FormCustomCheckboxFilter());
        }
    }
}