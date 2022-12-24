using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.Models.Region;

public class PostRegionDO : BaseRegionDO
{
	[Required]
	public string Name { get; set; }
}