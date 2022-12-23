﻿namespace HotelListing.API.Models.Request
{
    public class QueryParameters
    {
        int _pageSize = 15;

        public int StartIndex { get; set; }
        public int PageNumber { get; set; }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value;
        }
    }
}
