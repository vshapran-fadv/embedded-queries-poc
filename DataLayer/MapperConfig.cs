using AutoMapper;
using DataLayer.Model;

namespace DataLayer
{
    public static class MapperConfig
    {
        public static void AddDataLayer(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CustomerData, Customer>();
        }
    }
}