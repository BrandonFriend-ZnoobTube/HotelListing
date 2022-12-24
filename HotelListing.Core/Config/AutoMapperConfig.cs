using AutoMapper;
using HotelListing.Core.Models.Country;
using HotelListing.Core.Models.Hotel;
using HotelListing.Core.Models.Region;
using HotelListing.Core.Models.Users;
using HotelListing.Data;

namespace HotelListing.Core.Config;

public class AutoMapperConfig : Profile
{
	public AutoMapperConfig()
	{
		CreateMap<Country, PostCountryDO>().ReverseMap();
		CreateMap<Country, GetCountryDO>().ReverseMap();
		CreateMap<Country, CountryDO>().ReverseMap();
		CreateMap<Country, UpdateCountryDO>().ReverseMap();

		CreateMap<Region, RegionDO>().ReverseMap();
		CreateMap<Region, GetRegionDO>().ReverseMap();
		CreateMap<Region, PostRegionDO>().ReverseMap();
		CreateMap<Region, UpdateRegionDO>().ReverseMap();
		CreateMap<Region, IncludeRegionDO>().ReverseMap();

		CreateMap<Hotel, HotelDO>().ReverseMap();
		CreateMap<Hotel, GetHotelDO>().ReverseMap();
		CreateMap<Hotel, UpdateHotelDO>().ReverseMap();

		CreateMap<User, UserDO>().ReverseMap();
		CreateMap<User, AuthResponseDO>().ReverseMap();
		CreateMap<User, UserLoginDO>().ReverseMap();
	}
}