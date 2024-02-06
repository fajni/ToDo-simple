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

            Obligation newObligation = new Obligation
            {
                GetSetUserId = 1,
                GetSetTitle = "Delete",
                GetSetDate = DateTime.Now,
                GetSetNote = "Obligation to delete!"
            };

            obligationBusiness.InsertObligation(newObligation);

            foreach(var obligation in obligationBusiness.GetAllObligations())
            {
                Console.WriteLine(obligation.ToString());
            }

            foreach (var obligation in obligationBusiness.GetAllObligations())
            {
                if(obligation.GetSetTitle.Contains("Delete"))
                    Console.WriteLine(obligationBusiness.DeleteObligation(obligation.GetSetId));
            }

            foreach (var obligation in obligationBusiness.GetAllObligations())
            {
                Console.WriteLine(obligation.ToString());
            }
        }
    }
}
