using HotelListing.Core.Models.Hotel;

namespace HotelListing.Core.Models.Country;

public class CountryDO : BaseCountryDO
{
	public int Id { get; set; }

	public List<HotelDO> HotelList { get; set; }
}