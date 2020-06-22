using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APIConsume.Models
{
    public class WebService 
    {
        private readonly string apiUrl;
        private readonly string apiKey;

        public WebService(string apiUrl, string apiKey)
        {
            this.apiUrl = MakeValidApiUrl(apiUrl);
            this.apiKey = apiKey;
        }

        private string MakeValidApiUrl(string url)
        {
            if (url[url.Length - 1] != '/')
            {
                url += '/';
            }

            return url;
        }

        public Task<XElement> Add(string resource, XElement xml)
        {
            throw new NotImplementedException();
        }

    }
}
