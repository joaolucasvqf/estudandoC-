using AutoMapper;
using System.Collections.Generic;
using TalkToApi.V1.Models;
using TalkToApi.V1.Models.DTO;

namespace TalkToApi.Helpers
{
    public class DTOMapperProfile : Profile
    {
        public DTOMapperProfile()
        {
            CreateMap<ApplicationUser, UsuarioDTO>()
                .ForMember(
                    dest => dest.Nome, 
                    orig => orig.MapFrom(
                        src => src.FullName
                    )
                );
            //CreateMap<PaginationList<Palavra>, PaginationList<PalavraDTO>>();
        }
    }
}
