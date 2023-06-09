using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers;

/// <summary>
/// Creates map convensions
/// </summary>
public class MappingProfile : Profile
{

    public MappingProfile()
	{
        CreateMap<User, User>();
    }

}
