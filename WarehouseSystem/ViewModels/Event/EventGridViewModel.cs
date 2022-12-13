using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using WarehouseSystem.DTO;
using WarehouseSystem.Service;

namespace WarehouseSystem.ViewModels.Event
{
    public class EventGridViewModel : Screen
    {
        public List<EventDTO> Events { get; set; } = new List<EventDTO>();

        public EventGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddEventPage()
        {
            IWindowManager manager = new WindowManager();
            AddEventViewModel add = new AddEventViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyEventPage(EventDTO customEvent)
        {
            IWindowManager manager = new WindowManager();
            AddEventViewModel modify = new AddEventViewModel(customEvent);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(EventDTO customEvent)
        {
            IWindowManager manager = new WindowManager();
            EventService.Delete(customEvent);
            Reload();
        }

        public void Reload()
        {
            Events = EventService.GetAll();
            NotifyOfPropertyChange(() => Events);
        }
    }
}