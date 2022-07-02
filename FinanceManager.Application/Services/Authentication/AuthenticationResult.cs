using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.Services.Authentication;

public record AuthenticationResult(
	User user,
	string Token
);