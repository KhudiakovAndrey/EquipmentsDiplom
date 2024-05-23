using System;

namespace Equipments.Application.EquipmentsServiceRequest.Queries
{
    public partial class GetCountCreatedRequestByDate
    {
        public class RequestCountDateDto
        {
            public RequestCountDateDto(string date, int count)
            {
                Date = date;
                Count = count;
            }

            public string Date { get; set; }
            public int Count { get; set; }
        }
    }

}
