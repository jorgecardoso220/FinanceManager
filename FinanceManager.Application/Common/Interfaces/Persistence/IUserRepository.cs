using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
	User? GetUserByEmail(string email);
	void add(User user);
}