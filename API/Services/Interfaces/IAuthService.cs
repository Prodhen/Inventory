using System;
using API.DTOs.AuthDto;
using API.DTOs.Common;

namespace API.Services.Interfaces;

public interface IAuthService
{
    Task<ResponseDto> Register(RegisterDto registerDto);
    Task<ResponseDto> login(LoginDto dto);
    Task<ResponseDto> logout(LoginDto dto);


}
