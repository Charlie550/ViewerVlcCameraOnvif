using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.IO;
using Vlc.DotNet.Forms;
using System.Net;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
/*Agregar referencias a servicios:
https://www.onvif.org/ver10/device/wsdl/devicemgmt.wsdl (Devide)
https://www.onvif.org/ver20/media/wsdl/media.wsdl (Media)

importar paquetes nuget
Vlc.DotNet.Forms
(Vlc.DotNet.Core y Vlc.DotNet.Core.Interops)

copiar los dll en debug
axvlc.dll
libvlc.dll
libvlccore.dll
plugins(carpeta)
*/



namespace pruebaVLC
{
    public partial class MainForm : Form
    {        
        Loading loading;

        VlcControl vlcPlayer;

        UriBuilder deviceUri;
        Media.Media2Client media;
        Media.MediaProfile[] profiles;

        public MainForm()
        {
            InitializeComponent();

            vlcPlayer = new VlcControl();

            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            var libDirectory = new DirectoryInfo(currentDirectory);
            vlcPlayer.BeginInit();
            vlcPlayer.VlcLibDirectory = libDirectory;
            vlcPlayer.Dock = DockStyle.Fill;
            vlcPlayer.EndInit();
            //panel1.Controls.Add(vlcPlayer);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            show();
            button1.Enabled = false;
            Task oTask = new Task(TomarCaptura);
            oTask.Start();
            await oTask;
            hide();
            button1.Enabled = true;
        }


        public void TomarCaptura()
        {

            //--------------------- datos de conexion ---------------------

            //string url = "172.16.0.155";
            string url = "10.64.125.113";

            string user, password;
            //user = "Contel";
            //password = "Contel123.";
            user = "Bascula";
            password = "Aamexico20.";

            string ruta = @"C:/Users/jgomez/Desktop";//guardar las imagenes

            string urlPostMethod = "http://localhost:60673/Home/SubirArchivo";//metodo en el sistema web que recibe la imagen por post

            //--------------------------------------------------------------

            List<string> perfiles = new List<string>();
            deviceUri = new UriBuilder("http:/onvif/device_service");

            string[] addr = url.Split(':');
            deviceUri.Host = addr[0];
            if (addr.Length == 2)
                deviceUri.Port = Convert.ToInt16(addr[1]);

            System.ServiceModel.Channels.Binding binding;
            HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();
            httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Digest;
            binding = new CustomBinding(new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, Encoding.UTF8), httpTransport);

            Device.DeviceClient device = new Device.DeviceClient(binding, new EndpointAddress(deviceUri.ToString()));

            try
            {
                Device.Service[] services = device.GetServices(false);
                Device.Service xmedia = services.FirstOrDefault(s => s.Namespace == "http://www.onvif.org/ver20/media/wsdl");
                if (xmedia != null)
                {
                    media = new Media.Media2Client(binding, new EndpointAddress(xmedia.XAddr));
                    media.ClientCredentials.HttpDigest.ClientCredential.UserName = user;
                    media.ClientCredentials.HttpDigest.ClientCredential.Password = password;
                    media.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                    try
                    {
                        profiles = media.GetProfiles(null, null);
                        if (profiles != null)
                        {
                            foreach (var p in profiles)
                            {                                
                                perfiles.Add(p.Name);
                            }
                        }
                    }
                    catch (System.ServiceModel.ProtocolException ex)
                    {
                        MessageBox.Show("Error al obtener los perfiles del dispositivo: " + ex.Message);
                        return;
                    }
                }
            }
            catch (System.ServiceModel.EndpointNotFoundException ex)
            {
                MessageBox.Show("Error al intentar conectar con el dispositivo: " + ex.Message);
                return;
            }




            if (profiles != null && perfiles.Count >= 0)
            {
                UriBuilder uri = new UriBuilder(media.GetStreamUri("RtspOverHttp", profiles[0].token));
                uri.Host = deviceUri.Host;
                uri.Port = deviceUri.Port;
                uri.Scheme = "rtsp";
                //txt_estado.Text = uri.Path;

                string[] options = { ":rtsp-http", ":rtsp-http-port=" + uri.Port, ":rtsp-user=" + user, ":rtsp-pwd=" + password, };

                vlcPlayer.VlcMediaPlayer.Play(uri.Uri, options);
            }

            

            string[] imgList = Directory.GetFiles(ruta,"*.jpg");
            int noImagenes = imgList.Length;
            int noImagenesN;
            do
            {
                vlcPlayer.TakeSnapshot(ruta + "/img" + noImagenes + ".jpg");
                imgList = Directory.GetFiles(ruta, "*.jpg");
                noImagenesN = imgList.Length;

            } while (noImagenesN <= noImagenes);



            try
            {
                using (WebClient client = new WebClient())
                {
                    client.UploadFile(urlPostMethod, ruta + @"\img.jpg");
                }

                MessageBox.Show("Se ha subido la imagen al servidor");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar mandar la imagen al servidor: " + ex.Message);
                return;
            }
        }

        public void show()
        {
            loading = new Loading();
            loading.Show();
        }

        public void hide()
        {
            if (loading != null)
                loading.Close();
        }

        
    }
}
