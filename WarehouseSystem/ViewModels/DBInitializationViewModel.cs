using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WarehouseSystem.Models;

namespace WarehouseSystem.ViewModels
{
    public class DBInitializationViewModel : Screen
    {
        private readonly WarehouseSystemContext context;

        public Visibility DbNotCreated { get; set; }

        public Visibility IsInitClicked { get; set; }

        public bool WithSeed { get; set; }

        public DBInitializationViewModel(WarehouseSystemContext context)
        {
            this.context = context;
            DbNotCreated = Visibility.Visible;
            IsInitClicked = Visibility.Hidden;
        }

        public void InitDB()
        {
            if (context.Database.Exists())
                TryClose();

            Task.Run(() => { CreatDB(); TryClose(); });
            ReloadGrid();
        }

        public void CreatDB()
        {
            context.Database.Create();
            WarehouseSystemContext.Seed(context);
        }

        public void ReloadGrid()
        {
            DbNotCreated = Visibility.Hidden;
            IsInitClicked = Visibility.Visible;
            NotifyOfPropertyChange(() => DbNotCreated);
            NotifyOfPropertyChange(() => IsInitClicked);
        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}