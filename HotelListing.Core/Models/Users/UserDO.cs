using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.Models.Users;

public class UserDO : UserLoginDO
{
	[Required]
	public string FirstName { get; set; }

	[Required]
	public string LastName { get; set; }
}