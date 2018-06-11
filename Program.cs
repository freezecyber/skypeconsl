using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skypconsol
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread fhgf = new Thread(new ThreadStart(djf));
            fhgf.SetApartmentState(ApartmentState.STA);
            fhgf.Start();
            Application.DoEvents();
            Thread.Sleep(0);
            
        }

        private static void djf()
        {
            Application.Run(new server.bbrowser());
        }
    }
}
