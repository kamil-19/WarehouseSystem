using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using WarehouseSystem.Models;
using WarehouseSystem.ViewModels;

namespace WarehouseSystem
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            //using (var ctx = new WarehouseSystemContext())
            //{
            //    ctx.SaveChanges();
            //}

            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<StartUpViewModel>();
        }
    }
}