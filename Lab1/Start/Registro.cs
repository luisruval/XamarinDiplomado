using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace XamarinDiplomado
{
    public class ServiceHelper
    {
        MobileServiceClient clienteServicio = new MobileServiceClient(@"http://xamarin-diplomado.azurewebsites.net/");

        private IMobileServiceTable<LabItem> _LabItemTable;

        public async Task InsertarEntidad(string direccionCorreo, string lab, string AndroidId)
        {
            _LabItemTable = clienteServicio.GetTable<LabItem>();

            await _LabItemTable.InsertAsync(new LabItem
            {
                Email = direccionCorreo,
                Lab = lab,
                DeviceId = AndroidId
            });
        }
    }
    public class LabItem
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Lab { get; set; }
        public string DeviceId { get; set; }

    }
}