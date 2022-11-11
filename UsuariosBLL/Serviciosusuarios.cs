using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using UsuariosBLL.Dto;

namespace UsuariosBLL
{
    public partial class Serviciosusuarios
    {
        private string BASE_URL = "http://localhost:49900/ServiceUsuarios.svc/";

        public List<UsuarioDto> findAll()
        {
            try
            {
                var webclient = new WebClient();
                var json = webclient.DownloadString(BASE_URL + "findall");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<UsuarioDto>>(json);
            }
            catch
            {
                return null;
            }
        }

        public UsuarioDto find(string id)
        {
            try
            {
                var webclient = new WebClient();
                string url = string.Format(BASE_URL + "find/{0}", id);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<UsuarioDto>(json);
            }
            catch
            {
                return null;
            }
        }

        public bool create(UsuarioDto Usuario)
        {
            try
            {

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UsuarioDto));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, Usuario);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient clienteweb = new WebClient();
                clienteweb.Headers["Content-type"] = "application/json";
                clienteweb.Encoding = Encoding.UTF8;
                clienteweb.UploadString(BASE_URL + "create", "POST", data);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool edit(UsuarioDto Usuario)
        {
            try
            {

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UsuarioDto));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, Usuario);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient clienteweb = new WebClient();
                clienteweb.Headers["Content-type"] = "application/json";
                clienteweb.Encoding = Encoding.UTF8;
                clienteweb.UploadString(BASE_URL + "edit", "PUT", data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(UsuarioDto Usuario)
        {
            try
            {

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UsuarioDto));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, Usuario);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient clienteweb = new WebClient();
                clienteweb.Headers["Content-type"] = "application/json";
                clienteweb.Encoding = Encoding.UTF8;
                clienteweb.UploadString(BASE_URL + "delete", "DELETE", data);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
