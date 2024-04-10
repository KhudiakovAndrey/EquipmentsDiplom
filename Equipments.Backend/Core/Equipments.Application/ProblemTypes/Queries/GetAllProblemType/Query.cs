using MediatR;
using System.Collections.Generic;

namespace Equipments.Application.ProblemTypes.Queries
{
    public partial class GetAllProblemType
    {
        public class Query : IRequest<List<ProblemTypeDto>>
        {
        }
    }
}
