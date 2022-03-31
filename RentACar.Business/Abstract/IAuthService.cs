using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Result;
using RentACar.Core.Utilities.Security.Jwt;
using RentACar.Entities.Concrete;
using RentACar.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password); 
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<Token> CreateToken(User user);
    }
}
