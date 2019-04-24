using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

using System.Net.Http;
using System.Xml;
using System.Net;

namespace GGProject
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            CbG();
       
        }
        public async void CbG ()
        {
            string url = "http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1=02/03/2001&date_req2=14/03/2001&VAL_NM_RQ=R01235";
            HttpClient client = new HttpClient();
            HttpResponseMessage sdfs = null;
            while(sdfs==null)
            {
                try
                {
                    sdfs = await client.GetAsync(url);
                }
                catch
                {

                }
            }
            
            string WithSomeShit = await sdfs.Content.ReadAsStringAsync();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(WithSomeShit);
            string json = JsonConvert.SerializeXmlNode(xmlDocument);
            try
            {

                

                dynamic SomeKIndOfDoupShit2 = JsonConvert.DeserializeObject(json);

                
                    //l2.Text = SomeKIndOfDoupShit2.Record[0].Value;
                    //l3.Text = SomeKIndOfDoupShit2.Record[1].Value;
                    //l4.Text = SomeKIndOfDoupShit2.Record[2].Value;
                    //l5.Text = SomeKIndOfDoupShit2.Record[3].Value;
                    //l6.Text = SomeKIndOfDoupShit2.Record[4].Value;
                    //l7.Text = SomeKIndOfDoupShit2.Record[5].Value;
                    //l8.Text = SomeKIndOfDoupShit2.Record[6].Value;
                    CurencyValue.Text = SomeKIndOfDoupShit2.ValCurs.Record[7].Value ;
                
                
            }
            
            catch (WebException e)
            {
                l2.Text = "Ну ты и дебил " + e.Message;
            }
            catch (Exception e)
            {
                l2.Text = "Ну ты и дебил " + e.Message;
            }
        }
    }
}
