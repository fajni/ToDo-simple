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

            User newUser = null;

            foreach(var user in userBusiness.GetAllUsers())
            {
                if(user.GetSetUserId == 2)
                {
                    newUser = user;
                }
            }

            Console.WriteLine("New user to Update: "+newUser.ToString());

            //newUser.GetSetUserId = 2;
            newUser.GetSetName = "Veljko";
            newUser.GetSetLastname = "Fajni";
            newUser.GetSetPassword = "veljko123";

            Console.WriteLine(userBusiness.UpdateUser(newUser));

            foreach(var user in userBusiness.GetAllUsers())
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
}
