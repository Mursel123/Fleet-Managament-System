using AutoMapper;
using FMA.Application.Commands.Facturen.Create;
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            //Mapping
            CreateMap<Document, DocumentDTO>();
            CreateMap<CreateDocumentCommand, Document>(MemberList.Source)
                .ForSourceMember(x => x.HerstellingId, x => x.DoNotValidate());
        }
    }
}
