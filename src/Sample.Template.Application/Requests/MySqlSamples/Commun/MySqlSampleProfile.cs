using AutoMapper;
using Sample.Template.Application.Requests.MySqlSamples.Create;
using Sample.Template.Application.Requests.MySqlSamples.Update;
using Sample.Template.Domain;

namespace Sample.Template.Application.Requests.MySqlSamples.Commun
{
    public class MySqlSampleProfile : Profile
    {
        public MySqlSampleProfile()
        {
            CreateMap<MySqlSample, MySqlSampleDto>();

            CreateMap<CreateMySqlSampleRequest, CreateMySqlSampleCommandRequest>()
                .AfterMap((src, dest) => dest.MySqlSampleId = Guid.NewGuid());

            CreateMap<CreateMySqlSampleCommandRequest, MySqlSample>();
            CreateMap<UpdateMySqlSampleCommandRequest, MySqlSample>();
        }
    }
}
