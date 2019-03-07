﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace obilet.Agents
{
    public class HttpPostAgent<RequestModelType, ResponseModelType>
    {        
        public string Url { get; set; }
        public RequestModelType Body { get; set; }

        public Action<ResponseModelType> OnSuccess { get; set; }

        public void Send()
        {
            string result = SendAsync().Result;

            ResponseModelType response = JsonConvert.DeserializeObject<ResponseModelType>(result);

            OnSuccess(response);
        }

        private async Task<string> SendAsync()
        {
            string body = JsonConvert.SerializeObject(Body);

            StringContent content = new StringContent(body);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await Agency.HttpClient.PostAsync(Url, content).Result.Content.ReadAsStringAsync();            
        }
    }
}