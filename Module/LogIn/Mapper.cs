using AutoMapper;

namespace RiebreabApi.Modules.LogIns;

public class LogInMapper : Profile
{
    public LogInMapper()
    {
        CreateMap<LogIn, LogInResponse>();
        CreateMap<CreateLogInRequest, LogIn>();
        CreateMap<UpdateLogInRequest, LogIn>();
    }
}
