using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API.DataAccess.Interfaces;
using API.DTOs.AuthDto;
using API.DTOs.Common;
using API.Helper;
using API.Models;
using API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services.Implements;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private readonly IUnitOfWork _unitOfWork;
    private readonly RegisterDtoValidator _registerDtoValidator;

    public AuthService(IUnitOfWork unitOfWork,RegisterDtoValidator validationRules,IConfiguration config){
        _registerDtoValidator=validationRules;
        
        _unitOfWork = unitOfWork;
         this._config = config;
    }


    public Task<ResponseDto> logout(LoginDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto> Register(RegisterDto registerDto)
    {
         var validationResult = await _registerDtoValidator.ValidateAsync(registerDto);

        if (!validationResult.IsValid)
        {
            return ResponseHelper.ValidationError(ErrorHelper.FluentErrorMessages(validationResult.Errors));
          
        }

        if (await UserExists(registerDto.UserName)) return ResponseHelper.ValidationError("User name is taken already");
        using var hmac = new HMACSHA512();
        var user = new User
        {
            UserName = registerDto.UserName,
            PassWordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PassWordSalt = hmac.Key,
            IsDeleted=false,
            CreatedBy=_unitOfWork.LoggedInUserId(),
            CreatedAt=DateTime.UtcNow,
            Status=registerDto.Status,
            ImagePath = null
        };
        _unitOfWork.Users.Add(user);

        await _unitOfWork.SaveAsync();

        return ResponseHelper.Success("User registered successfully");
    }

    
    public async Task<ResponseDto> login(LoginDto dto)
    {

        var user = await _unitOfWork.Users.GetWhere(x => x.UserName.ToLower().Trim() == dto.UserName.ToLower().Trim());
        if (user == null) return ResponseHelper.ValidationError("Invalid User Name.");


        if (!VerifyPasswordHash(user.PassWordHash, user.PassWordSalt, dto.Password))
        {
            return ResponseHelper.ValidationError("Invalid Password");
        }
        var response = new loginResponseDto
        {
            UserName = user.UserName,
            Token = CreateToken(user),
  
        };
        return ResponseHelper.Success(data:response);

    }

    private async Task<bool> UserExists(string userName)
    {
        return await _unitOfWork.Users.Any(user => user.UserName == userName);
    }

    private string CreateToken(User user)
    {
        var tokenKey = _config["TokenKey"] ?? throw new Exception("Cannot access tokenKey from appSetting ");
        if (tokenKey.Length < 64) throw new Exception("Your token needs to be longer");
        var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        var claims=new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.Id) ),
            new Claim(ClaimTypes.Name,user.UserName)
        };
        var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor=new SecurityTokenDescriptor{
            Subject=new ClaimsIdentity(claims),
            Expires=DateTime.UtcNow.AddDays(1),
            SigningCredentials=creds
        };
        var tokenHandler=new JwtSecurityTokenHandler();
        var token=tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
       private  bool VerifyPasswordHash(byte[] passwordHash, byte[] passwordSalt, string password)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        if (computedHash.Length != passwordHash.Length)
            return false;

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != passwordHash[i])
                return false;
        }

        return true;
    }

}
