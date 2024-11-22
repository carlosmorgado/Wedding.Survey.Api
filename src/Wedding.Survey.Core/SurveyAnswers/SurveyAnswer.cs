namespace Wedding.Survey.Core.SurveyAnswers;
public class SurveyAnswer
{
    public Guid Id { get; set; }

    public required ICollection<GuestInformation> GuestInformation { get; set; }

    public DateTimeOffset CreationDate { get; set; }
}
