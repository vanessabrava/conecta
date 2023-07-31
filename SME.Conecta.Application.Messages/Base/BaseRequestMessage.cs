using Microsoft.AspNetCore.Http;
using SME.Conecta.Infra.CrossCutting.Common.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SME.Conecta.Application.Messages.Base
{
    [DataContract(Namespace = "http://www.sme.com.br/types/")]
    public abstract class BaseRequestMessage
    {
        public BaseRequestMessage() { }

        public string Protocol => GetHeader(ConstHeaders.Protocolo);

        public virtual IDictionary<string, string> DefaultRequestHeaders { get; private set; } = new Dictionary<string, string>();

        public HttpRequest OriginalHttpRequest { get; private set; }

        public virtual void AddHeader(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            if (DefaultRequestHeaders.Contains(new KeyValuePair<string, string>(key, value)))
                return;

            if (!DefaultRequestHeaders.ContainsKey(key))
                DefaultRequestHeaders.Add(key, value);
            else
                DefaultRequestHeaders[key] = value;
        }

        public virtual string GetHeader(string key) => DefaultRequestHeaders.TryGetValue(key, out string outValue) ? outValue : string.Empty;

        public void SetHttpRequestMessage(HttpRequest httpRequest)
        {
            if (OriginalHttpRequest == null)
                OriginalHttpRequest = httpRequest;
        }
    }
}
