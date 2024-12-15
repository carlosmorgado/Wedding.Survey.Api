using FastEndpoints;
using MediatR;
using Wedding.Survey.Web.SurveyAnswers.Extenrions;

namespace Wedding.Survey.Web.SurveyAnswers;

public class Create(IMediator mediator)
    : Endpoint<CreateSurveyAnswerRequest>
{
    private readonly IMediator mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    public override void Configure()
    {
        this.Post("/survey-answers");
        this.AllowAnonymous();
        this.Options(b => b.RequireCors(x => x.AllowAnyOrigin()));
    }

    public override async Task HandleAsync(
        CreateSurveyAnswerRequest req,
        CancellationToken ct)
    {
       await this.mediator.Send(req.ToCommand());


    }
}
