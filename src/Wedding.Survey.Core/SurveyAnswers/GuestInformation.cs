namespace Wedding.Survey.Core.SurveyAnswers;
public class GuestInformation
{
    public required string Name { get; set; }

    public required bool IsAgeZeroToThree { get; set; }

    public required bool IsAgeFourToNine { get; set; }

    public required bool IsAdult { get; set; }

    public IEnumerable<DietRestrictions> Restrictions { get; set; } = Enumerable.Empty<DietRestrictions>();
}
