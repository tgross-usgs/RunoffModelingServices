using System;
using System.IO;
using System.Net.Http;
using RunoffModelingServices.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using TR55Agent.Resources;

namespace RunoffModelingServices.ServiceAgents
{
    public class TDServiceAgent
    {
        #region Properties
        public TDSettings settings{ get; set; }
        public Dictionary<double, double> hyetograph = new Dictionary<double, double>();

        #endregion
        #region Constructors
        public TDServiceAgent(TDSettings settings)

        {
            this.settings = settings;
        }
        #endregion
        #region Methods
        public async Task<bool> ReadTDAsync(int dur)
        {
            string result = "";
            string msg;
            
            try
            {
                //pub/hdsc/data/sa/sa_general_6h_temporal.csv
                string urlString = String.Format(getURI(assignSType(dur)));

                var handler = new HttpClientHandler();                              //discontinue use when NOAA renews their certificate
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;  //

                handler.ServerCertificateCustomValidationCallback =                 //
                    (httpRequestMessage, cert, cetChain, policyErrors) =>           //
                    {                                                               //
                        return true;                                                //
                    };                                                              //

                using (HttpClient conn = new HttpClient(handler))                   //remove handler argument
                {
                    conn.BaseAddress = new Uri(settings.baseurl);

                    var reply = await conn.GetAsync(urlString, default(System.Threading.CancellationToken));
                    string message = await reply.Content.ReadAsStringAsync();
                    string parsedString = Regex.Unescape(message);
                    byte[] isoBites = Encoding.GetEncoding("ISO-8859-1").GetBytes(parsedString);
                    result = Encoding.UTF8.GetString(isoBites, 0, isoBites.Length);

                    CollectData(result);
                }


                if (isDynamicError(result, out msg)) throw new Exception(msg);

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }//end PostFeatures

        public Dictionary<double, double> PassHyeto()
        {
            return hyetograph;
        }
        #endregion
        #region Helper Methods
        private serviceType assignSType(int pdur)
        {
            switch (pdur)
            {
                case 6:
                    return serviceType.e_6hrdistribution;
                case 24:
                    return serviceType.e_24hrdistribution;
                default:
                    return serviceType.e_24hrdistribution + 1;
            }

        }
        private String getURI(serviceType sType)
        {
            string uri = string.Empty;
            switch (sType)
            {
                case serviceType.e_6hrdistribution:
                    uri = settings.resources["6h_duration"];
                    break;

                case serviceType.e_24hrdistribution:
                    uri = settings.resources["24h_duration"];
                    break;
            }

            return uri;
        }//end getURL
        private Boolean isDynamicError(dynamic obj, out string msg)
        {
            msg = string.Empty;
            try
            {
                var error = obj.error;
                if (error == null) throw new Exception();
                msg = error.message;
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        //select generic storm event, All Cases and 50% probability
        public void CollectData(string result)
        {
            //
            string rpercent = "";
            string mytable = "";
            string r50 = "";
            //int first = result.IndexOf("All");
            int first = result.IndexOf("CUMULATIVE PERCENTAGES OF TOTAL PRECIPITATION FOR ALL CASES");
            int last = result.Length - first;
            List<string> plist;
            //List<string> vlist;

            /* SW REGION
            //collect first line of table (percent of duration,0.0, 9.1...)
            mytable = result.Substring(first, last);

            first = mytable.IndexOf("percent");
            last = mytable.Length - first;

            rpercent = mytable.Substring(first, last);
            rpercent = rpercent.Substring(0, rpercent.IndexOf("\r\n"));

            plist = rpercent.Split(',').ToList();

            //collect 50% probability values
            first = mytable.IndexOf("50%");
            last = mytable.Length - first;

            r50 = mytable.Substring(first, last);
            r50 = r50.Substring(0, r50.IndexOf("\r\n"));

            vlist = r50.Split(',').ToList();

            //pair the values
            for (var i = 1; i < plist.Count; i++)
            {
                double x = double.Parse(plist[i]);
                double y = double.Parse(vlist[i]);

                hyetograph.Add(x, y);
            }

            */ //end SW Region

            //NW Region
            //collect ALL CASES table 
            mytable = result.Substring(first, last);
            using (StringReader reader = new StringReader(mytable))
            {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    if (Regex.IsMatch(line, @"^\d")) {
                        plist = line.Split(',').ToList();
                        hyetograph.Add(double.Parse(plist[0]), double.Parse(plist[5]));
                    }
                }
            }
            //end NW Region
        }
        #endregion
        #region Enumerations
        public enum serviceType
        {
            e_6hrdistribution, e_24hrdistribution
        }

        #endregion
    }
}
