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

            User user = new User("Test", "Testing", "Test123");
            userBusiness.InsertUser(user);

            foreach(var u in userBusiness.GetAllUsers())
            {
                Console.WriteLine(u.ToString());
            }
        }
    }
}
