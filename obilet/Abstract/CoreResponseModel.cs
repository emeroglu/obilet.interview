﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using obilet.Enum;

namespace obilet.Abstract
{
    public class CoreResponseModel<DataModelType> where DataModelType : CoreDataModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "status")]
        public ResponseStates Status { get; set; }

        [JsonProperty(PropertyName = "data")]
        public DataModelType Data { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "user-message")]
        public string UserMessage { get; set; }

        [JsonProperty(PropertyName = "api-request-id")]
        public string ApiRequestId { get; set; }

        [JsonProperty(PropertyName = "controller")]
        public string Controller { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}