using AutoMapper;

namespace RiebreabApi.Modules.Quotes;

public class QuoteMapper : Profile
{
    public QuoteMapper()
    {
        CreateMap<Quote, QuoteResponse>();
        CreateMap<CreateQuoteRequest, Quote>();
        CreateMap<UpdateQuoteRequest, Quote>();
    }
}
