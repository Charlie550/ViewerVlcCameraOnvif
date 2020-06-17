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
    public partial class Form1 : Form
    {

        VlcControl vlcPlayer;

        UriBuilder deviceUri;
        Media.Media2Client media;
        Media.MediaProfile[] profiles;

        public Form1()
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
            panel1.Controls.Add(vlcPlayer);
        }


        private void btn_conectar_Click(object sender, EventArgs e)
        {
            deviceUri = new UriBuilder("http:/onvif/device_service");

            string[] addr = txt_url.Text.Split(':');
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
                    media.ClientCredentials.HttpDigest.ClientCredential.UserName = txt_user.Text;
                    media.ClientCredentials.HttpDigest.ClientCredential.Password = txt_password.Text;
                    media.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                    try
                    {
                        profiles = media.GetProfiles(null, null);
                        if (profiles != null)
                        {
                            foreach (var p in profiles)
                            {
                                listBox1.Items.Add(p.Name);
                            }
                        }
                    }
                    catch (System.ServiceModel.ProtocolException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (System.ServiceModel.EndpointNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_captura_Click(object sender, EventArgs e)
        {
            vlcPlayer.TakeSnapshot(txt_ruta.Text + "/img.jpg");
        }      

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (profiles != null && listBox1.SelectedIndex >= 0)
            {
                UriBuilder uri = new UriBuilder(media.GetStreamUri("RtspOverHttp", profiles[listBox1.SelectedIndex].token));
                uri.Host = deviceUri.Host;
                uri.Port = deviceUri.Port;
                uri.Scheme = "rtsp";
                txt_estado.Text = uri.Path;

                string[] options = { ":rtsp-http", ":rtsp-http-port=" + uri.Port, ":rtsp-user=" + txt_user.Text, ":rtsp-pwd=" + txt_password.Text, };



                vlcPlayer.VlcMediaPlayer.Play(uri.Uri, options);

            }
        }

        private void btn_subirImg_Click(object sender, EventArgs e)
        {

            try
            {

                string host = txt_urlFTP.Text;//"192.168.100.8"
                string user = txt_usrFTP.Text;
                string pass = txt_passFTP.Text;
                string fileName = txt_ruta.Text + @"\img.jpg";
                string folderName = txt_rutaRemota.Text;


                FtpWebRequest request;

                string absoluteFileName = Path.GetFileName(fileName);

                request = WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", host, folderName, absoluteFileName))) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential(user, pass);
                request.ConnectionGroupName = "group";

                using (FileStream fs = File.OpenRead(fileName))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }

                MessageBox.Show("Se ha enviado la imagen al servidor");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
