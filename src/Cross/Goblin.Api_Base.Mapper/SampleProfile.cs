using AutoMapper;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;
using Goblin.Api_Base.Contract.Repository.Models;
using Goblin.Api_Base.Share.Models;

namespace Goblin.Api_Base.Mapper
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<GoblinApi_BaseCreateSampleModel, SampleEntity>()
                .IgnoreAllNonExisting();
            
            CreateMap<SampleEntity, GoblinApi_BaseSampleModel>()
                .IgnoreAllNonExisting();
        }
    }
}