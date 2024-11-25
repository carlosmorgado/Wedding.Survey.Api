using FastEndpoints;
using MediatR;
using Wedding.Survey.Core.SurveyAnswers;
using Wedding.Survey.UseCases.SurveyAnswers.ListAll;
using Wedding.Survey.Web.SurveyAnswers.Extenrions;

namespace Wedding.Survey.Web.SurveyAnswers;
public class List(IMediator mediator) : EndpointWithoutRequest<ListSurveyAnswersResponse>
{
    private readonly IMediator mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    public override void Configure()
    {
        this.Get("/survey-answers");
        this.AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var answerDtos = await this.mediator.Send(new ListAllSurveyAnswersQuery());
        
        this.Response = answerDtos.ToResponse();
    }
}
