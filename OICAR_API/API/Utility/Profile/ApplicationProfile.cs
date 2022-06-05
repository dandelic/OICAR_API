using API.Dto;
using API.Models;
using API.Models.DTO;
using API.Models.DTO.Add;

namespace API.Utility.Profile
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Client, ClientDto>()
                .ReverseMap();
            CreateMap<City, CityDto>()
             .ReverseMap();
            CreateMap<County, CountyDto>()
             .ReverseMap();
            CreateMap<ChatConversation, ChatConversationDto>()
             .ReverseMap();
            CreateMap<ChatReply, ChatReplyDto>()
         .ReverseMap();         
            CreateMap<Review, ReviewDto>()
         .ReverseMap();
            CreateMap<ServiceCategory, ServiceCategoryDto>()
         .ReverseMap();
            CreateMap<ServiceSubcategory, ServiceSubcategoryDto>()
         .ReverseMap();
            CreateMap<Client, ClientAddDto>()
      .ReverseMap();
            CreateMap<Offer, OfferDto>()
                .ReverseMap();
                CreateMap<Offer, OfferAddDto>()
                .ReverseMap();
            CreateMap<ChatConversation, ChatConversationAddDto>()
                .ReverseMap();
            CreateMap<ChatReply, ChatReplyAddDto>()
             .ReverseMap();

        }
    }
}
