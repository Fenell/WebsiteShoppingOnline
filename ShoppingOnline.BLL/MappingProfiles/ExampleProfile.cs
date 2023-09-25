using AutoMapper;
using ShoppingOnline.BLL.DataTransferObjects.Example;
using ShoppingOnline.BLL.DataTransferObjects.Example.Request;
using ShoppingOnline.DAL.Entities.Example;

namespace ShoppingOnline.BLL.MappingProfiles;

public class ExampleProfile:Profile
{
	public ExampleProfile()
	{
		CreateMap<ExampleEntity, ExampleDto>();
		CreateMap<ExampleCreateRequest, ExampleEntity>();
		CreateMap<ExampleDeleteRequest, ExampleEntity>();
	}
}