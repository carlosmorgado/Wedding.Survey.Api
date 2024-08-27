namespace Wedding.Survey.Web.SurveyAnswers;

public class CreateSurveyAnswerRequest
{
    public required IReadOnlyCollection<GuestInformationRecord> GuestInformation { get; set; }
}
