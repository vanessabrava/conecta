using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SME.Conecta.Application.Messages.Base
{
    [DataContract(Namespace = "http://www.sme.com.br/types/")]
    public class ResponseMessage
    {
        public virtual Dictionary<string, string> DefaultResponseHeaders { get; private set; } = new Dictionary<string, string>();

        public virtual void AddHeader(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            if (DefaultResponseHeaders.Contains(new KeyValuePair<string, string>(key, value)))
                return;

            if (!DefaultResponseHeaders.ContainsKey(key))
                DefaultResponseHeaders.Add(key, value);
            else
                DefaultResponseHeaders[key] = value;
        }

        public virtual string GetHeader(string key) => DefaultResponseHeaders.TryGetValue(key, out string outValue) ? outValue : string.Empty;
    }
}
