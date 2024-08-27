using System.Runtime.Serialization;

namespace Wedding.Survey.Core.SurveyAnswers;
public enum DietRestrictions
{
    [EnumMember(Value = "Ovos")]
    Eggs,
    [EnumMember(Value = "Marisco")]
    Seafood,
    [EnumMember(Value = "Frutos Secos")]
    Nuts,
    [EnumMember(Value = "Lactose")]
    Lactose,
    [EnumMember(Value = "Glúten")]
    Gluten,
    [EnumMember(Value = "Vegetariano")]
    Vegeterian,
    [EnumMember(Value = "Vegan")]
    Vegan,
    [EnumMember(Value = "Grávida")]
    Pregnant
}
