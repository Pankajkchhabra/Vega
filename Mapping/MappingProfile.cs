using AutoMapper;
using vega.Models;
using Vega.Controllers.Resources;

namespace Vega.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
        }
    }
}