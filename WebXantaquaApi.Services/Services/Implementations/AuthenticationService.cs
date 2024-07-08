using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebXantaquaApi.Services.Mapping.Dtos;
using WebXantaquaApi.Services.Services.Interfaces;
using Microsoft.Extensions.Logging; // Certifique-se de importar o namespace para logging
using System;

namespace WebXantaquaApi.Services.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Client> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthenticationService> _logger; // Adicione o logger como uma dependência

        public AuthenticationService(
            UserManager<Client> userManager,
            IConfiguration configuration,
            ITokenService tokenService,
            ILogger<AuthenticationService> logger) // Injete o ILogger
        {
            _userManager = userManager;
            _configuration = configuration;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<AuthenticationResultDto> RegisterAsync(RegisterDto userForRegistration)
        {
            try
            {
                _logger.LogInformation("Attempting to register new user: {Email}", userForRegistration.Email);

                var existingUser = await _userManager.FindByEmailAsync(userForRegistration.Email);
                if (existingUser != null)
                {
                    _logger.LogWarning("Registration failed: Email already exists: {Email}", userForRegistration.Email);
                    return new AuthenticationResultDto { IsSuccess = false, Errors = new[] { "Email already exists." } };
                }

                var newUser = new Client { Email = userForRegistration.Email, UserName = userForRegistration.Email, Name = userForRegistration.Name }; // Use Client ao criar novo usuário
                var createUserResult = await _userManager.CreateAsync(newUser, userForRegistration.Password);

                if (!createUserResult.Succeeded)
                {
                    _logger.LogWarning("Registration failed: {Errors}", createUserResult.Errors.Select(e => e.Description));
                    return new AuthenticationResultDto { IsSuccess = false, Errors = createUserResult.Errors.Select(e => e.Description) };
                }

                _logger.LogInformation("User registered successfully: {Email}", userForRegistration.Email);
                var token = await _tokenService.CreateTokenAsync(newUser);
                return new AuthenticationResultDto { IsSuccess = true, Token = token };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering a new user.");
                throw;
            }
        }

        public async Task<AuthenticationResultDto> LoginAsync(LoginDto userForLogin)
        {
            Client user = await _userManager.FindByEmailAsync(userForLogin.Email);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, userForLogin.Password)))
            {
                return new AuthenticationResultDto
                {
                    IsSuccess = false,
                    Errors = new[] { "Email or password is incorrect." }
                };
            }

            // Gera o token JWT para o login bem-sucedido
            string token = await _tokenService.CreateTokenAsync(user);

            return new AuthenticationResultDto
            {
                IsSuccess = true,
                Token = token
            };
        }
    }
}