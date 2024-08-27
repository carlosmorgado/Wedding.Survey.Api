using Wedding.Survey.Core.SurveyAnswers;

namespace Wedding.Survey.Web.SurveyAnswers;

public record GuestInformationRecord(
    string Name,
    bool IsAgeZeroToThree,
    bool IsAgeFourToNine,
    bool IsAdult,
    IReadOnlyCollection<DietRestrictions> Restrictions);
