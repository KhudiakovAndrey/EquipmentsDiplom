using AutoMapper;
using Equipments.Application.Common.Exceptions;
using Equipments.Application.Interfaces;
using Equipments.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipments.Application.Equipments.Commands
{
    public partial class AddEquipment
    {
        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly IEquipmentsDbContext _dbContext;
            private readonly IMapper _mapper;

            public CommandHandler(IEquipmentsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var statusModel = await _dbContext.StatusEquipments.FirstOrDefaultAsync(status => status.IdStatusEquipment == request.IdStatus,
                    cancellationToken);
                var typeModel = await _dbContext.TypeEquipments.FirstOrDefaultAsync(type => type.IdTypeEquipment == request.IdType,
                    cancellationToken);
                if (statusModel == null || typeModel == null)
                {
                    throw new NotFoundException($"{nameof(StatusEquipment)} и {nameof(TypeEquipment)}", $"{statusModel?.IdStatusEquipment} и {typeModel?.IdTypeEquipment}");
                }

                var equipment = new Equipment()
                {
                    Title = request.Title,
                    Fulltitle = request.FullTitle,
                    Isgroup = request.IsGroup,
                    IdStatusEquipment = request.IdStatus,
                    IdTypeEquipment = request.IdType
                };

                await _dbContext.Equipments.AddAsync(equipment, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
