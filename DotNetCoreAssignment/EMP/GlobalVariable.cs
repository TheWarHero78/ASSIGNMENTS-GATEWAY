using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EMP
{
    public static class GlobalVariable
    {
        public static readonly HttpClient webapiclient = new HttpClient();
        static GlobalVariable()
        {
            webapiclient.BaseAddress = new Uri("https://localhost:44304/api/");
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
