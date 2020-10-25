using System;
using System.Collections.Generic;
using System.Text;

namespace JON_Store.Api.Controllers.Models.Product
{
    public class GetSingleProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public double Price { get; set; }
    }
}
