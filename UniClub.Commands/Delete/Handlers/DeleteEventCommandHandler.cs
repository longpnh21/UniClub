﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventDto, int>
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<int> Handle(DeleteEventDto request, CancellationToken cancellationToken)
        {
            return await _eventRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
