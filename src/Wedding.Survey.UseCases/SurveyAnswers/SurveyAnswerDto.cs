namespace Wedding.Survey.UseCases.SurveyAnswers;
public class SurveyAnswerDto
{
    public required IReadOnlyCollection<GuestInformationDto> GuestInformation { get; set; }

    public required DateTimeOffset CreationDate { get; set; }
}
