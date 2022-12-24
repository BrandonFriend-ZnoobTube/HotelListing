using AutoMapper;
using HotelListing.Core.Contracts;
using HotelListing.Data;

namespace HotelListing.Core.Repository;

public class RegionsRepository : GenericRepository<Region>, IRegionsRepository
{
	public RegionsRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
	{
	}
}