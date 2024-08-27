namespace Wedding.Survey.Web.SurveyAnswers;

public record SurveyAnswersRecord(
    IReadOnlyCollection<GuestInformationRecord> GuestInformation,
    DateTimeOffset CreationDate);
