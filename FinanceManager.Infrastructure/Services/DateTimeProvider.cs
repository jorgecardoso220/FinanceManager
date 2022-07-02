using FinanceManager.Application.Common.Interfaces.Services;

namespace FinanceManager.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
	public DateTime UtcNow => DateTime.UtcNow;
}