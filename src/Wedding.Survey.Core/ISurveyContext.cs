using Microsoft.EntityFrameworkCore;
using Wedding.Survey.Core.SurveyAnswers;

namespace Wedding.Survey.Core;
public interface ISurveyContext
{
	DbSet<SurveyAnswer> Answers { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
