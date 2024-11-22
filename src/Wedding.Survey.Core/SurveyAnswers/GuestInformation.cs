namespace Wedding.Survey.Core.SurveyAnswers;
public class GuestInformation
{
    public required string Name { get; set; }

    public required bool IsAgeZeroToThree { get; set; }

    public required bool IsAgeFourToNine { get; set; }

    public required bool IsAdult { get; set; }

    public ICollection<DietRestrictions> Restrictions { get; set; } = new List<DietRestrictions>();
}
