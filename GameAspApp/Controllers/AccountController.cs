using System;
using System.Security.Claims;
using System.Threading.Tasks;
using GameAspApp.JwtAuth.Models.Request;
using GameAspApp.JwtAuth.Models.Response;
using GameAspApp.JwtAuth.Interfaces;
using GameAspApp.JwtAuth.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using GameAspApp.JwtAuth;
using GameAspApp.Common.Swagger;

namespace GameAspApp.Controllers
{
    /// <summary>
    /// Контроллер для работы c аккаунтом.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Account)]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// DI логгера.
        /// </summary>
        private readonly ILogger<AccountController> _logger;
        /// <summary>
        /// DI сервиса для пользователей.
        /// </summary>
        private readonly IUserService _userService;
        /// <summary>
        /// DI менеджера токенов.
        /// </summary>
        private readonly IJwtAuthManager _jwtAuthManager;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AccountController"/>.
        /// </summary>
        /// <param name="logger">Логгер.</param>
        /// <param name="userService">Сервис.</param>
        /// <param name="jwtAuthManager">Менеджера токенов.</param>
        public AccountController(ILogger<AccountController> logger, IUserService userService, IJwtAuthManager jwtAuthManager)
        {
            _logger = logger;
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
        }

        /// <summary>
        /// Метод Login.
        /// </summary>
        /// <param name="request">Запрос логина <see cref="LoginRequest"/></param>
        /// <returns><see cref="ActionResult"/></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!_userService.IsValidUserCredentials(request.UserName, request.Password))
            {
                return Unauthorized();
            }
            var role = _userService.GetUserRole(request.UserName);
            // добавление утверждений токену
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim(ClaimTypes.Role, role)
            };
            // создание jwt токена
            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{request.UserName}] logged in the system.");
            return Ok(new LoginResult
            {
                UserName = request.UserName,
                Role = role,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        /// <summary>
        /// Метод получения текущего пользователя.
        /// </summary>
        /// <returns><see cref="LoginResult"/></returns>
        [HttpGet("user")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult GetCurrentUser()
        {
            return Ok(new LoginResult
            {
                UserName = User.Identity.Name,
                Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                OriginalUserName = User.FindFirst("OriginalUserName")?.Value
            });
        }

        /// <summary>
        /// Метод Logout.
        /// </summary>
        /// <returns><see cref="ActionResult"/></returns>
        [HttpPost("logout")]
        [Authorize]
        public ActionResult Logout()
        {
            var userName = User.Identity.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserName(userName);
            _logger.LogInformation($"User [{userName}] logged out the system.");
            return Ok();
        }

        /// <summary>
        /// Метод обновления токена.
        /// </summary>
        /// <param name="request">Запрос обновления токена<see cref="RefreshTokenRequest"/></param>
        /// <returns><see cref="LoginResult"/></returns>
        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var userName = User.Identity.Name;
                _logger.LogInformation($"User [{userName}] is trying to refresh JWT token.");

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
                _logger.LogInformation($"User [{userName}] has refreshed JWT token.");
                return Ok(new LoginResult
                {
                    UserName = userName,
                    Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message); // 401
            }
        }

        // next 2 endpoints immitates Impersonation attack.
        // admin can impersonate a user with a different role
        // you don't need it in you homework, just for example!!!
        // see https://www.sciencedirect.com/topics/computer-science/authentication-attack

        //[HttpPost("impersonation")]
        //[Authorize(Roles = UserRoles.Admin)]
        //public ActionResult Impersonate([FromBody] ImpersonationRequest request)
        //{
        //    var userName = User.Identity.Name;
        //    _logger.LogInformation($"User [{userName}] is trying to impersonate [{request.UserName}].");

        //    var impersonatedRole = _userService.GetUserRole(request.UserName);
        //    if (string.IsNullOrWhiteSpace(impersonatedRole))
        //    {
        //        _logger.LogInformation($"User [{userName}] failed to impersonate [{request.UserName}] due to the target user not found.");
        //        return BadRequest($"The target user [{request.UserName}] is not found.");
        //    }
        //    if (impersonatedRole == UserRoles.Admin)
        //    {
        //        _logger.LogInformation($"User [{userName}] is not allowed to impersonate another Admin.");
        //        return BadRequest("This action is not supported.");
        //    }

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.Name,request.UserName),
        //        new Claim(ClaimTypes.Role, impersonatedRole),
        //        new Claim("OriginalUserName", userName)
        //    };

        //    var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
        //    _logger.LogInformation($"User [{request.UserName}] is impersonating [{request.UserName}] in the system.");
        //    return Ok(new LoginResult
        //    {
        //        UserName = request.UserName,
        //        Role = impersonatedRole,
        //        OriginalUserName = userName,
        //        AccessToken = jwtResult.AccessToken,
        //        RefreshToken = jwtResult.RefreshToken.TokenString
        //    });
        //}

        //[HttpPost("stop-impersonation")]
        //public ActionResult StopImpersonation()
        //{
        //    var userName = User.Identity.Name;
        //    var originalUserName = User.FindFirst("OriginalUserName")?.Value;
        //    if (string.IsNullOrWhiteSpace(originalUserName))
        //    {
        //        return BadRequest("You are not impersonating anyone.");
        //    }
        //    _logger.LogInformation($"User [{originalUserName}] is trying to stop impersonate [{userName}].");

        //    var role = _userService.GetUserRole(originalUserName);
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.Name,originalUserName),
        //        new Claim(ClaimTypes.Role, role)
        //    };

        //    var jwtResult = _jwtAuthManager.GenerateTokens(originalUserName, claims, DateTime.Now);
        //    _logger.LogInformation($"User [{originalUserName}] has stopped impersonation.");
        //    return Ok(new LoginResult
        //    {
        //        UserName = originalUserName,
        //        Role = role,
        //        OriginalUserName = null,
        //        AccessToken = jwtResult.AccessToken,
        //        RefreshToken = jwtResult.RefreshToken.TokenString
        //    });
        //}
    }
}
