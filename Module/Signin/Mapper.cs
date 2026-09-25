using AutoMapper;

namespace RiebreabApi.Modules.SignIns;

public class SignInMapper : Profile
{
    public SignInMapper()
    {
        CreateMap<SignIn, SignInResponse>();
        CreateMap<CreateSignInRequest, SignIn>();
        CreateMap<UpdateSignInRequest, SignIn>();
    }
}
