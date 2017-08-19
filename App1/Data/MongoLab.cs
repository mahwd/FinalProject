using System;
using System.Text;
using WAU.Model;

namespace WAU.Data
{
    public class MongoLab
    {
        private static string dbName = "mapdb";
        private static string collectionName = "user";
        private static string apiKey = "t4-O8eFHO055sa-IDjU1VVDR60OFTmt9";

        public static string GetAddressSingle(User _user)
        {
            String baseUrl = $"https://api.mlab.com/api/1/databases/{ dbName}/collections/{collectionName}";
            StringBuilder stringBuilder = new StringBuilder(baseUrl);
            stringBuilder.Append($"/{_user._id.id}?apiKey={apiKey}");
            return stringBuilder.ToString();
        }

        public static string GetAddressAPI()
        {
            String baseUrl = $"https://api.mlab.com/api/1/databases/{dbName}/collections/{collectionName}";
            StringBuilder stringBuilder = new StringBuilder(baseUrl);
            stringBuilder.Append($"?apiKey={apiKey}");
            return stringBuilder.ToString();
        }
        public static string SelectWithQuery(string query)
        {
            String baseUrl = $"https://api.mlab.com/api/1/databases/{dbName}/collections/{collectionName}";
            StringBuilder stringBuilder = new StringBuilder(baseUrl);
            stringBuilder.Append($"/?apiKey={apiKey}");
            stringBuilder.Append($"&q={{{query}}}");
            return stringBuilder.ToString();
        }
    }
}