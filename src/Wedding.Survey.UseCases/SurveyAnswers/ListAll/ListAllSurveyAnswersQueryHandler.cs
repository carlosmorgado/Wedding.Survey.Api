using MediatR;
using Wedding.Survey.Core;
using Wedding.Survey.UseCases.SurveyAnswers.Extensions;

namespace Wedding.Survey.UseCases.SurveyAnswers.ListAll;
public class ListAllSurveyAnswersQueryHandler(ISurveyContext surveyContext)
    : IRequestHandler<ListAllSurveyAnswersQuery, IReadOnlyCollection<SurveyAnswerDto>>
{
    private readonly ISurveyContext surveyContext = surveyContext
        ?? throw new ArgumentNullException(nameof(surveyContext));

    public async Task<IReadOnlyCollection<SurveyAnswerDto>> Handle(
        ListAllSurveyAnswersQuery request,
        CancellationToken cancellationToken)
    {
        var answers = this
            .surveyContext
            .Answers
            .ToList()
            .Select(answer => answer.ToDto())
            .ToList();

        return answers;
    }
}
