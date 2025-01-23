using System.Net;

namespace MagicVilla_API.Modelos
{
    public class APIResponse
    {
        public HttpStatusCode statusCode { get; set; }

        public bool IsExitoso { get; set; }

        public List<string> ErroresMessage { get; set; }

        public object Resultado { get; set; }
    }
}
