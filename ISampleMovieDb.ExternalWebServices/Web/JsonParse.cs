using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ISampleMovieDb.ExternalWebServices.Web
{
    public static class JsonParse
    {

        public static V Post<T,V>(string url, T Request) where V : class
        {
            V Response = null;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(Request);
                    streamWriter.Write(json);
                }


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Response = JsonConvert.DeserializeObject<V>(result);
                }

                return Response;
            }
            catch
            {
                return Response;
            }
        }

        public static T Get<T>(string url) where T : class
        {
            T Response = null;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    Response = JsonConvert.DeserializeObject<T>(json);
                    return Response;
                }
            }
            catch (Exception)
            {
                return Response;                
            }
        }
    }
}
