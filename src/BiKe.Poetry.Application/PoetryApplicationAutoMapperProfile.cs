using AutoMapper;
using System.Linq;

namespace BiKe.Poetry
{
    public class PoetryApplicationAutoMapperProfile : Profile
    {
        public PoetryApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Author, AuthorDto>();

            CreateMap<CreateUpdateAuthorDto, Author>();

            //CreateMap<LunYu, LunYuDto>();

            //CreateMap<CreateUpdateLunYuDto, LunYu>();
        }
    }
}
