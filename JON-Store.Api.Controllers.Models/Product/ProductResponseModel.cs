using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JON_Store.Api.Controllers.Models.Product
{
    public class ProductResponseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
