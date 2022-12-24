#nullable enable
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.Models.Region;

public class IncludeRegionDO
{
	public int Id { get; set; }

	[Required]
	public string? Name { get; set; }
}