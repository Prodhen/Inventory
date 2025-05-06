using System;

namespace API.DTOs.AuthDto;

public class loginResponseDto
{
    public required string UserName { get; set; }
    public  string? Token { get; set; }

}
