﻿namespace HotelListing.Core.Models.Request;

public class PagedResult<T>
{
	public int TotalCount { get; set; }
	public int TotalPages { get; set; }
	public int PageNumber { get; set; }
	public int RecordNumber { get; set; }
	public List<T> Items { get; set; }
}