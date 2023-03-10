using HotelListing.Core.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.Core.Contracts;

public interface IAuthManager
{
	Task<IEnumerable<IdentityError>> Register(UserDO userDO);
	Task<AuthResponseDO> Login(UserLoginDO userLoginDO);
	Task<string> CreateRefreshToken();
	Task<AuthResponseDO> VerifyRefreshToken(AuthResponseDO request);
}