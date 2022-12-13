using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DTO;

namespace WarehouseSystem.Authentication
{
    public class Authentication
    {
        public string Username { get; set; }
        public bool isLogged { get; set; }
        public bool isAdmin { get; set; }
        public UserDTO User { get; set; }

        private static Authentication m_oInstance = null;
        private int m_nCounter = 0;

        public static Authentication Instance
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new Authentication();
                }
                return m_oInstance;
            }
        }

        private Authentication()
        {
            m_nCounter = 1;

            Username = string.Empty;
            isLogged = false;
            isAdmin = false;
            User = null;
        }
    }
}