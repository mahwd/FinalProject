using System;
using System.Text;
using Java.Net;
using Java.IO;
using System.IO;

namespace WAU.Data
{
    public class HTTPDataHandler
    {
        public static String stream = null;
        public HTTPDataHandler(){}
        public String GetHTTPData(String urlString)
        {
            try
            {
                URL url = new URL(urlString);
                HttpURLConnection urlConnection = (HttpURLConnection)url.OpenConnection();
                if (urlConnection.ResponseCode == HttpStatus.Ok)  //200
                {
                    BufferedReader br = new BufferedReader(new InputStreamReader(urlConnection.InputStream));
                    StringBuilder strBuilder = new StringBuilder();
                    String line;
                    while ((line = br.ReadLine()) != null)
                    {
                        strBuilder.Append(line);
                        stream = strBuilder.ToString();
                        urlConnection.Disconnect();
                    }
                }
            }
            catch{ }

            return stream;
        }

        public void PostHTTPData(String urlString, String json)
        {
            try
            {
                URL url = new URL(urlString);
                HttpURLConnection urlConnection = (HttpURLConnection)url.OpenConnection();

                urlConnection.RequestMethod = "POST";
                urlConnection.DoOutput = true;

                byte[] _out = Encoding.UTF8.GetBytes(json);
                int length = _out.Length;

                urlConnection.SetFixedLengthStreamingMode(length);
                urlConnection.SetRequestProperty("Content-Type", "application/json");
                urlConnection.SetRequestProperty("charset", "utf-8");

                urlConnection.Connect();

                try
                {
                    Stream str = urlConnection.OutputStream;
                    str.Write(_out, 0, length);
                }
                catch{}

                var status = urlConnection.ResponseCode;
            }
            catch {}
        }

        public void PutHTTPData(String urlString, String json)
        {
            try
            {
                URL url = new URL(urlString);
                HttpURLConnection urlConnection = (HttpURLConnection)url.OpenConnection();

                urlConnection.RequestMethod = "PUT";
                urlConnection.DoOutput = true;

                byte[] _out = Encoding.UTF8.GetBytes(json);
                int length = _out.Length;

                urlConnection.SetFixedLengthStreamingMode(length);
                urlConnection.SetRequestProperty("Content-Type", "application/json");
                urlConnection.SetRequestProperty("charset", "utf-8");

                urlConnection.Connect();

                try
                {
                    Stream str = urlConnection.OutputStream;
                    str.Write(_out, 0, length);
                }
                catch{}

                var status = urlConnection.ResponseCode;
            }
            catch { }
        }

        public void DeleteHTTPData(String urlString, String json)
        {
            try
            {
                URL url = new URL(urlString);
                HttpURLConnection urlConnection = (HttpURLConnection)url.OpenConnection();

                urlConnection.RequestMethod = "Delete";
                urlConnection.DoOutput = true;

                byte[] _out = Encoding.UTF8.GetBytes(json);
                int length = _out.Length;

                urlConnection.SetFixedLengthStreamingMode(length);
                urlConnection.SetRequestProperty("Content-Type", "application/json");
                urlConnection.SetRequestProperty("charset", "utf-8");

                urlConnection.Connect();

                try
                {
                    Stream str = urlConnection.OutputStream;
                    str.Write(_out, 0, length);
                }
                catch {}

                var status = urlConnection.ResponseCode;
            }
            catch {}
        }
    }

}