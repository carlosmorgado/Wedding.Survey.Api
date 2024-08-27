using Wedding.Survey.Core.SurveyAnswers;

namespace Wedding.Survey.UseCases.SurveyAnswers;
public class GuestInformationDto
{
    public required string Name {   get; set;}
    public required bool IsAgeZeroToThree { get; set;}
    public required bool IsAgeFourToNine {  get; set;}
    public required bool IsAdult {  get; set;}
    public required IReadOnlyCollection<DietRestrictions> Restrictions { get; set; }
}
