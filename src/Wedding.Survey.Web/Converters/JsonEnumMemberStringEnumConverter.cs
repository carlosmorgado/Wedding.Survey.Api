using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Wedding.Survey.Core.SurveyAnswers;

namespace Wedding.Survey.Web.Converters;

public class JsonEnumMemberStringEnumConverter : JsonConverter<DietRestrictions>
{
	private static readonly IReadOnlyDictionary<string, string> enumToStringMapper = typeof(DietRestrictions)
		.GetFields(BindingFlags.Public | BindingFlags.Static)
		.ToDictionary(
			fieldInfo => fieldInfo.Name,
			fieldInfo => fieldInfo.GetCustomAttribute<EnumMemberAttribute>()!.Value!);

	private static readonly IReadOnlyDictionary<string, string> stringToEnumMapper = enumToStringMapper
		.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

	public override DietRestrictions Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var stringValue = reader.GetString();

		var enumName = stringToEnumMapper[stringValue];

		var restriction = Enum.Parse<DietRestrictions>(enumName);

		return restriction;
	}

	public override void Write(Utf8JsonWriter writer, DietRestrictions value, JsonSerializerOptions options)
	{
		var restriction = enumToStringMapper[value.ToString()];

		writer.WriteStringValue(restriction);
	}
}
