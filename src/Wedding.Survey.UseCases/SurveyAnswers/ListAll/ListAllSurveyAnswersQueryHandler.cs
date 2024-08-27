using MediatR;
using Wedding.Survey.Core;

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
        throw new NotImplementedException();
    }
}
