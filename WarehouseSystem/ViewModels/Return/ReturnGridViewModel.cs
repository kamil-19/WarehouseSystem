using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels.Return
{
    public class ReturnGridViewModel : Screen
    {
        public List<ReturnDTO> Returns { get; set; } = new List<ReturnDTO>();

        public ReturnGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddReturnPage()
        {
            IWindowManager manager = new WindowManager();
            AddReturnViewModel add = new AddReturnViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyReturnPage(ReturnDTO ret)
        {
            IWindowManager manager = new WindowManager();
            AddReturnViewModel modify = new AddReturnViewModel(ret);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(ReturnDTO ret)
        {
            IWindowManager manager = new WindowManager();
            ReturnService.Delete(ret);
            Reload();
        }

        public void Reload()
        {
            Returns = ReturnService.GetAll();
            NotifyOfPropertyChange(() => Returns);
        }
    }
}