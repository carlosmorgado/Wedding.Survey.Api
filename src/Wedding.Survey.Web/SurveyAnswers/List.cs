using FastEndpoints;
using MediatR;
using Wedding.Survey.Core.SurveyAnswers;

namespace Wedding.Survey.Web.SurveyAnswers;
public class List(IMediator mediator) : Endpoint<ListSurveyAnswersResponse>
{
    public override void Configure()
    {
        this.Get("/survey-answers");
        this.AllowAnonymous();
    }

    public override Task HandleAsync(ListSurveyAnswersResponse req, CancellationToken ct)
    {
        this.Response = new ListSurveyAnswersResponse
        {
            Answers = new List<SurveyAnswersRecord>
            {
                new SurveyAnswersRecord(
                    new List<GuestInformationRecord>
                    {
                        new GuestInformationRecord(
                            "Carlos Morgado",
                            false,
                            false,
                            true,
                            new List<DietRestrictions>
                            {
                                DietRestrictions.Nuts,
                            }),
                    },
                    DateTimeOffset.UtcNow),
            }
        };

        return Task.CompletedTask;
    }
}
