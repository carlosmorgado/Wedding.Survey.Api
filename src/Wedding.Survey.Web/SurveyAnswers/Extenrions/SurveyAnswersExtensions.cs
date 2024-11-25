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

    public static SurveyAnswersRecord ToResponse(this SurveyAnswerDto dto)
    {
        return new SurveyAnswersRecord(
            dto.GuestInformation.ToResponse(),
            dto.CreationDate);
    }

    public static GuestInformationRecord ToResponse(this GuestInformationDto dto)
    {
        return new GuestInformationRecord(
            dto.Name,
            dto.IsAgeZeroToThree,
            dto.IsAgeFourToNine,
            dto.IsAdult,
            dto.Restrictions);
    }

    public static IReadOnlyCollection<GuestInformationDto> ToDto(
        this IReadOnlyCollection<GuestInformationRecord> records)
    {
        return records.Select(ToDto).ToList();
    }

    public static ListSurveyAnswersResponse ToResponse(
        this IReadOnlyCollection<SurveyAnswerDto> dtos)
    {
        return new ListSurveyAnswersResponse
        {
            Answers = dtos.Select(ToResponse).ToList(),
        };
    }

    public static IReadOnlyCollection<GuestInformationRecord> ToResponse(
        this IReadOnlyCollection<GuestInformationDto> dtos)
    {
        return dtos.Select(ToResponse).ToList();
    }
}
