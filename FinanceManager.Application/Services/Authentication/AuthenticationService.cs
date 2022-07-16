using ErrorOr;
using FinanceManager.Application.Common.Interfaces.Authentication;
using FinanceManager.Application.Common.Interfaces.Persistence;
using FinanceManager.Domain.Common.Errors;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	private readonly IUserRepository _userRepository;

	public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
	{
		_jwtTokenGenerator = jwtTokenGenerator;
		_userRepository = userRepository;
	}

	public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
	{
		// 1. Validate the user doesn't exists
		if (_userRepository.GetUserByEmail(email) is not null)
		{
			return Errors.User.DuplicateEmail;
		}

		// 2. Create user (generate unique ID) & Persist to DB
		var user = new User
		{
			FirstName = firstName,
			LastName = lastName,
			Email = email,
			Password = password
		};

		_userRepository.add(user);

		// 3. Create JWT token
		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(
			user,
			token);
	}

	public ErrorOr<AuthenticationResult> Login(string email, string password)
	{
		// 1. Validate the user exists
		if (_userRepository.GetUserByEmail(email) is not User user)
		{
			return Errors.Authentication.InvalidCredentials;
		}

		// 2. Validate the password is correct
		if (user.Password != password)
		{
			return Errors.Authentication.InvalidCredentials;
		}

		// 3 Create JwT token
		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(
			user,
			token);
	}
}