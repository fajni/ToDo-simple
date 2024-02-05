using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());

            ObligationBusiness obligationBusiness = new ObligationBusiness();

            Console.WriteLine("All Obligations Stored In Database: ");
            foreach (var obligation in obligationBusiness.GetAllObligations())
            {
                Console.WriteLine(obligation.ToString());
            }

            Console.WriteLine("Obligations By User Id: ");
            foreach(var obligation in obligationBusiness.GetObligationsByUserId(2))
            {
                Console.WriteLine(obligation.ToString());
            }
        }
    }
}
