using Wedding.Survey.Core.SurveyAnswers;
using Wedding.Survey.UseCases.SurveyAnswers.Create;

namespace Wedding.Survey.UseCases.SurveyAnswers.Extensions;
internal static class SurveyAnswerExtensions
{
    public static SurveyAnswer ToDatabaseObject(this CreateSurveyAnswerCommand command)
    {
        return new SurveyAnswer
        {
            GuestInformation = command.GuestInformation.ToDatabaseObject(),
        };
    }

    public static GuestInformation ToDatabaseObject(this GuestInformationDto info)
    {
        return new GuestInformation
        {
            Name = info.Name,
            IsAdult = info.IsAdult,
            IsAgeFourToNine = info.IsAgeFourToNine,
            IsAgeZeroToThree = info.IsAgeZeroToThree,
            Restrictions = info.Restrictions.ToList(),
        };
    }

    public static ICollection<GuestInformation> ToDatabaseObject(this IReadOnlyCollection<GuestInformationDto> infos)
    {
        return infos.Select(ToDatabaseObject).ToList();
    }
}
