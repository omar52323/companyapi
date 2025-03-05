using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companyapi.Domain.Entities
{
    public class Company
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Direccion_Prinicipal { get; set; }
        public string Nombre_Administrador { get; set; }
        public string OwnerId { get; set; }
        public string Id_GUID { get; set; }

    }
}
