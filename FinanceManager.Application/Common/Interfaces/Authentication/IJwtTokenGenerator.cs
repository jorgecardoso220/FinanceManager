using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
	string GenerateToken(User user);
}