using FMA.Application.DTOs.Aanvragen;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.Aanvragen.ReadAanvraagNotification
{
    public class ReadAanvraagNotificationQuery: IRequest<List<AanvraagNotificationListDTO>>
    {
        public string Email { get; set; } = string.Empty;
    }
}
