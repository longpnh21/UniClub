﻿using MediatR;
using System;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Create
{
    public class CreateEventDto : IRequest<int>
    {
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int Point { get; set; }
        public int MaxParticipants { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public EventStatus Status { get; set; }
        public bool IsPrivate { get; set; }
    }
}
