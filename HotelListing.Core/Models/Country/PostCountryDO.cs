using System.ComponentModel.DataAnnotations;
using HotelListing.Core.Models.Region;

namespace HotelListing.Core.Models.Country;

public class PostCountryDO : BaseCountryDO
{
	[Required]
	public GetRegionDO Region { get; set; }
}