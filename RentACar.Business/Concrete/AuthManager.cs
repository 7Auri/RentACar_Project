using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Business;
using RentACar.Core.Utilities.Result;
using RentACar.Core.Utilities.Security.Hashing;
using RentACar.Core.Utilities.Security.Jwt;
using RentACar.Entities.DTOs;


namespace RentACar.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenGenerator _tokenGenerator;

        public AuthManager(IUserService userService, ITokenGenerator tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.SuccessRegister);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.ErrorNotUser);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.ErrorPassword);
            }

            return new SuccessDataResult<User>(userToCheck.Data,Messages.SuccessLogin);
        }

        public IResult UserExists(string email)
        {
            IResult result = BusinessRules.Run(CheckIfUserExist(email));
            if (result != null)
            {
                return new ErrorResult(Messages.ErrorHaveUser);
            }
            return new SuccessResult();
        }

        public IDataResult<Token> CreateToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenGenerator.CreateToken(user, claims.Data);
            return new SuccessDataResult<Token>(accessToken, Messages.SuccessToken);
        }
        private IResult CheckIfUserExist(string email)
        {
            var result = _userService.GetByMail(email).Data;
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
