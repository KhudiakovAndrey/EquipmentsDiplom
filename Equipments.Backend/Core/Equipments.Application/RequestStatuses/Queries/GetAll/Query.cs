using MediatR;
using System.Collections.Generic;

namespace Equipments.Application.RequestStatuses.Queries
{
    public partial class GetAll
    {
        public class Query : IRequest<List<RequestStatusDto>>
        {
        }
    }
}
