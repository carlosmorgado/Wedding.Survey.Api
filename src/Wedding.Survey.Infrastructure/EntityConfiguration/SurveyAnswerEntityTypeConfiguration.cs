using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using Wedding.Survey.Core.SurveyAnswers;

namespace Wedding.Survey.Infrastructure.EntityConfiguration;
public class SurveyAnswerEntityTypeConfiguration : IEntityTypeConfiguration<SurveyAnswer>
{
    public void Configure(EntityTypeBuilder<SurveyAnswer> builder)
    {
        builder.HasKey(answer => answer.Id);

		builder
			.Property(answer => answer.Id)
			.ValueGeneratedOnAdd();

		builder.ToCollection("survey-answers");
	}
}
