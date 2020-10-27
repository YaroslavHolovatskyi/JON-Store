using System;
using System.Collections.Generic;
using System.Text;

namespace JON_Store.Api.Controllers.Models.Paging
{
    public class PagingResponseModel<TResponse>
    {
        public int TotalAmount { get; private set; }
        public TResponse Data { get; private set; }

        public PagingResponseModel(TResponse data, int totalAmount)
        {
            Data = data;
            TotalAmount = totalAmount;
        }
    }
}
