using Wedding.Survey.UseCases.SurveyAnswers;
using Wedding.Survey.UseCases.SurveyAnswers.Create;

namespace Wedding.Survey.Web.SurveyAnswers.Extenrions;

internal static class SurveyAnswersExtensions
{
    public static CreateSurveyAnswerCommand ToCommand(this CreateSurveyAnswerRequest request)
    {
        return new CreateSurveyAnswerCommand
        {
            GuestInformation = request.GuestInformation.ToDto(),
        };
    }

    public static GuestInformationDto ToDto(this GuestInformationRecord record)
    {
        return new GuestInformationDto
        {
            IsAdult = record.IsAdult,
            IsAgeFourToNine = record.IsAgeFourToNine,
            IsAgeZeroToThree = record.IsAgeZeroToThree,
            Name = record.Name,
            Restrictions = record.Restrictions,
        };
    }

    public static IReadOnlyCollection<GuestInformationDto> ToDto(
        this IReadOnlyCollection<GuestInformationRecord> records)
    {
        return records.Select(ToDto).ToList();
    }
}
