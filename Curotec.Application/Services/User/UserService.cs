using Curotec.Application.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using Curotec.Application.Repositories;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Threading;

namespace Curotec.Application.Services.User
{
    /// <summary>
    /// Service for user-related operations.
    /// </summary>
    public class UserService(
        IOptions<AppSettings> appSettings,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
        : IUserService
    {
        private readonly AppSettings _appSettings = appSettings.Value;

        /// <summary>
        /// Authenticates a user with the provided credentials.
        /// </summary>
        /// <param name="model">The authentication request model containing username and password.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the authentication response with user details and JWT token.</returns>
        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            var user = await userRepository.GetAsync(u =>
                u.Username == model.Username && u.Password == model.Password);

            if (user == null) return null;

            var token = await GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        /// <summary>
        /// Gets all active users.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of active users.</returns>
        public async Task<IEnumerable<Domain.Entities.User>> GetAll()
        {
            return await userRepository.GetListAsync(u => u.IsActive);
        }

        /// <summary>
        /// Gets a user by their identifier.
        /// </summary>
        /// <param name="id">The identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the user entity.</returns>
        public async Task<Domain.Entities.User?> GetById(int id)
        {
            return await userRepository.GetAsync(u=>u.Id==id);
        }

        /// <summary>
        /// Adds or updates a user.
        /// </summary>
        /// <param name="userObj">The user entity to add or update.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added or updated user entity.</returns>
        public async Task<Domain.Entities.User?> AddOrUpdateUser(Domain.Entities.User userObj,CancellationToken cancellationToken)
        {
            if (userObj.Id > 0)
            {
                var obj = await userRepository.GetAsync(u => u.Id == userObj.Id);
                if (obj != null)
                {
                    obj.FirstName = userObj.FirstName;
                    obj.LastName = userObj.LastName;
                    userRepository.Update(obj);
                    await unitOfWork.Save(cancellationToken);
                }
            }
            else
            {
                await userRepository.AddAsync(userObj);
                await unitOfWork.Save(cancellationToken);
            }

            return userObj;
        }

        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        /// <param name="user">The authenticated user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the generated JWT token.</returns>
        private async Task<string> GenerateJwtToken(Domain.Entities.User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity([new Claim("id", user.Id.ToString())]),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }
    }
}