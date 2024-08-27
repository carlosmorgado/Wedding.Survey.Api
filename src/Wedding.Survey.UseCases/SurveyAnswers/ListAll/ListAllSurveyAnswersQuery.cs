using MediatR;

namespace Wedding.Survey.UseCases.SurveyAnswers.ListAll;
public class ListAllSurveyAnswersQuery : IRequest<IReadOnlyCollection<SurveyAnswerDto>>
{
}
