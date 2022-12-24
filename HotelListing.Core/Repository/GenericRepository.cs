﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListing.Core.Contracts;
using HotelListing.Core.Exceptions;
using HotelListing.Core.Models.Request;
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Core.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	readonly HotelListingDbContext _context;
	readonly IMapper _mapper;

	public GenericRepository(HotelListingDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task<T> GetAsync(int? id)
	{
		if (id == null) { throw new NotFoundException(typeof(T).Name, id.HasValue ? $"key: {id}" : "No key provided"); }

		var result = await _context.Set<T>().FindAsync(id);

		if (result == null) { throw new NotFoundException(nameof(GetAsync), id); }

		return result;
	}

	public async Task<TResult> GetAsync<TResult>(int? id)
	{
		var result = await _context.Set<T>().FindAsync(id);

		if (result == null) { throw new NotFoundException(typeof(T).Name, id.HasValue ? id : "No key provided"); }

		return _mapper.Map<TResult>(result);
	}

	public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

	public async Task<List<TResult>> GetAllAsync<TResult>() => await _context.Set<T>().ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync().ConfigureAwait(false);

	public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters)
	{
		var totalSize = await _context.Set<T>().CountAsync();
		var items = await _context.Set<T>()
			.Skip(queryParameters.StartIndex)
			.Take(queryParameters.PageSize)
			.ProjectTo<TResult>(_mapper.ConfigurationProvider)
			.ToListAsync();

		return new PagedResult<TResult>
		{
			Items = items,
			PageNumber = queryParameters.PageNumber,
			RecordNumber = queryParameters.PageSize,
			TotalCount = totalSize
		};
	}

	public async Task<T> AddAsync(T entity)
	{
		await _context.AddAsync(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
	{
		var entity = _mapper.Map<T>(source);

		await _context.AddAsync(entity);
		await _context.SaveChangesAsync();

		return _mapper.Map<TResult>(entity);
	}

	public async Task UpdateAsync(T entity)
	{
		_context.Update(entity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync<TSource>(int id, TSource source)
	{
		var entity = await GetAsync<TSource>(id);

		if (entity == null) { throw new NotFoundException(typeof(T).Name, id); }

		_context.Update(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var entity = await GetAsync(id);

		if (entity == null) { throw new NotFoundException(typeof(T).Name, id); }

		_context.Set<T>().Remove(entity);
		await _context.SaveChangesAsync();
	}

	public async Task<bool> Exists(int id)
	{
		var entity = await GetAsync(id);
		return entity != null;
	}
}