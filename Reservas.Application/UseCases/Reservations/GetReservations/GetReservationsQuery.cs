using System;
using System.Collections.Generic;

namespace Reservas.Application.UseCases.Reservations.GetReservations
{
    public class GetReservationsQuery
    {
        public Guid? UserId { get; set; }
    }
}
