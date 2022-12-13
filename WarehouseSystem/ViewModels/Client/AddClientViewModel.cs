using WarehouseSystem.Service;
using WarehouseSystem.DTO;
using WarehouseSystem.Models;
using WarehouseSystem.Views;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystem.ViewModels
{
    //ViewModel do widoku AddClientView
    public class AddClientViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private ClientDTO toEdit { get; set; }

        public string CompanyName { get; set; }
        public string CityTown { get; set; }
        public string PostalCode1 { get; set; }
        public string PostalCode2 { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string ButtonLabel { get; set; }

        public AddClientViewModel(ClientDTO client)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            this.toEdit = client;
            CompanyName = client.CompanyName;
            CityTown = client.CityTown;
            PostalCode1 = client.PostalCode.Substring(0, 2);
            PostalCode2 = client.PostalCode.Substring(3, 3);
            Address = client.Address;
            Email = client.Email;
            PhoneNumber = client.PhoneNumber;
            NotifyOfPropertyChange(() => CompanyName);
            NotifyOfPropertyChange(() => PostalCode1);
            NotifyOfPropertyChange(() => PostalCode2);
            NotifyOfPropertyChange(() => Address);
            NotifyOfPropertyChange(() => Email);
            NotifyOfPropertyChange(() => PhoneNumber);
        }

        public AddClientViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void Add()
        {
            if (IsEdit == true)
            {
                toEdit.CompanyName = CompanyName;
                toEdit.PostalCode = string.Format("{0}-{1}", PostalCode1, PostalCode2);
                toEdit.Address = Address;
                toEdit.Email = Email;
                toEdit.PhoneNumber = PhoneNumber;
                ClientService.Edit(toEdit);
            }
            else
            {
                var newClient = new ClientDTO();
                newClient.CompanyName = CompanyName;
                newClient.PostalCode = string.Format("{0}-{1}", PostalCode1, PostalCode2);
                newClient.Address = Address;
                newClient.Email = Email;
                newClient.PhoneNumber = PhoneNumber;
                ClientService.Add(newClient);
            }
            Close();
        }

        public void Close()
        {
            TryClose();
        }
    }
}