﻿using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdateClubCommandHandler : IRequestHandler<UpdateClubDto, int>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public UpdateClubCommandHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubDto request, CancellationToken cancellationToken)
        {
            return await _clubRepository.UpdateAsync(_mapper.Map<Club>(request), cancellationToken);
        }
    }
}
