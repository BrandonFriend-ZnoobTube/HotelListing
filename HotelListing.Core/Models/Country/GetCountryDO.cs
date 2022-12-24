#nullable enable
using HotelListing.Core.Models.Region;

namespace HotelListing.Core.Models.Country;

public class GetCountryDO : BaseCountryDO
{
	public int Id { get; set; }

	public IncludeRegionDO? Region { get; set; }
}