using MediatR;

namespace Wedding.Survey.UseCases.SurveyAnswers.Create;
public class CreateSurveyAnswerCommand : IRequest
{
    public required IReadOnlyCollection<GuestInformationDto> GuestInformation { get; set; }
}
