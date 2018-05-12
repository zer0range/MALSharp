using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MALSharp.Service
{
    class MALServices
    {
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                var xml = await response.Content.ReadAsStreamAsync();
                T result = (T)serializer.Deserialize(xml);
                return result;
            }
        }
    }
}
