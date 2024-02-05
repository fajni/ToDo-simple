using BusinessLayer;
using Shared.Models;
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

            UserBusiness userBusiness = new UserBusiness();
            ObligationBusiness obligationBusiness = new ObligationBusiness();

            foreach(var user in userBusiness.GetAllUsers())
            {
                Console.WriteLine(user.ToString());
            }

            foreach(var obligation in obligationBusiness.GetAllObligations())
            {
                Console.WriteLine(obligation.ToString());
            }

            Obligation newObligation1 = new Obligation 
            {
                GetSetUserId = 1,
                GetSetTitle = "First Insert",
                GetSetDate = DateTime.Parse("30-Jan-2024"),
                GetSetNote = "Note For First New Obligation"
            };

            Obligation newObligation2 = new Obligation
            {
                GetSetUserId = 1,
                GetSetTitle = "Second Insert",
                GetSetDate = Convert.ToDateTime("28-Feb-2024")
            };

            Console.WriteLine(obligationBusiness.InsertObligation(newObligation1));
            Console.WriteLine(obligationBusiness.InsertObligation(newObligation2));

            foreach (var obligation in obligationBusiness.GetAllObligations())
            {
                Console.WriteLine(obligation.ToString());
            }
        }
    }
}
