using MediatR;
using Wedding.Survey.Core;
using Wedding.Survey.UseCases.SurveyAnswers.Extensions;

namespace Wedding.Survey.UseCases.SurveyAnswers.Create;
public class CreateSurveyAnswerCommandHandler(ISurveyContext surveyContext)
    : IRequestHandler<CreateSurveyAnswerCommand>
{
    private readonly ISurveyContext surveyContext = surveyContext
        ?? throw new ArgumentNullException(nameof(surveyContext));

    public async Task Handle(
        CreateSurveyAnswerCommand request,
        CancellationToken cancellationToken)
    {
        var surveyAnswer = request.ToDatabaseObject();

        await this.surveyContext.Answers.AddAsync(surveyAnswer, cancellationToken);

        await this.surveyContext.SaveChangesAsync(cancellationToken);
    }
}
