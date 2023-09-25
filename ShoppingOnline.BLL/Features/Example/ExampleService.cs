using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.Example;
using ShoppingOnline.BLL.DataTransferObjects.Example.Request;
using ShoppingOnline.BLL.Exceptions;
using ShoppingOnline.DAL.Entities.Example;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.BLL.Features.Example;

public class ExampleService : IExampleService
{
	private readonly IExampleRepos _repos;
	private readonly IMapper _mapper;

	public ExampleService(IExampleRepos repos, IMapper mapper)
	{
		_repos = repos;
		_mapper = mapper;
	}

	public async Task<List<ExampleDto>> GetAsync()
	{
		var objColection = await _repos.GetAllAsync();
		var exampleDto = _mapper.Map<List<ExampleDto>>(objColection);

		return exampleDto;
	}

	public Task<ExampleDto> GetById(Guid id)
	{
		throw new NotImplementedException();
	}

	public async Task<Guid> Create(ExampleCreateRequest request)
	{
		try
		{
			var exampleCreate = _mapper.Map<ExampleEntity>(request);
			var result = await _repos.CreateAsync(exampleCreate);
			return result;
		}
		catch (Exception e)
		{
			throw new BadRequestExpection("Invalid Example");
		}
	}

	public async Task Update(ExampleUpdateRequest request)
	{
		var exampleUpdate = _mapper.Map<ExampleEntity>(request);
		var result = await _repos.UpdateAsync(exampleUpdate);

		if (result is null)
		{
			throw new NotFoundException(nameof(ExampleEntity), request.Id);
		}

		if (result == false)
		{
			throw new BadRequestExpection("Unable to update example");
		}
	}

	public async Task Delete(ExampleDeleteRequest request)
	{
		var result = await _repos.DeleteAsync(request.Id);

		if (result is null)
		{
			throw new NotFoundException(nameof(ExampleEntity), request.Id);
		}

		if (result == false)
		{
			throw new BadRequestExpection("Unable to delete example");
		}
	}
}