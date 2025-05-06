using System;
using API.DTOs.Common;

namespace API.Helper;

public static class ResponseHelper
{
 public static ResponseDto Success(string message = "Success", object? data = null, int statusCode = StatusCodes.Status200OK)
    {
        return new ResponseDto
        {
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

    public static ResponseDto Created(string message = "CreatedSuccessfully", object? data = null)
    {
        return new ResponseDto
        {
            StatusCode = StatusCodes.Status201Created,
            Message = message,
            Data = data
        };
    }

    public static ResponseDto Updated(string message = "UpdatedSuccessfully", object? data = null)
    {
        return Success(message, data, StatusCodes.Status200OK);
    }

    public static ResponseDto Deleted(string message = "DeletedSuccessfully")
    {
        return Success(message, null, StatusCodes.Status200OK);
    }

    public static ResponseDto NoContent(string message = "NoContent")
    {
        return new ResponseDto
        {
            StatusCode = StatusCodes.Status204NoContent,
            Message = message,
            Data = null
        };
    }

    public static ResponseDto ValidationError(string message = "ValidationError")
    {
        return new ResponseDto
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Message = message,
            Data = null
        };
    }

    public static ResponseDto ValidationError(List<string> messageList)
    {
        return new ResponseDto
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Message = "ValidationError",
            Data = messageList
        };
    }

    public static ResponseDto Unauthorized(string message = "Unauthorized")
    {
        return new ResponseDto
        {
            StatusCode = StatusCodes.Status401Unauthorized,
            Message = message,
            Data = null
        };
    }

    public static ResponseDto Forbidden(string message = "Forbidden")
    {
        return new ResponseDto
        {
            StatusCode = StatusCodes.Status403Forbidden,
            Message = message,
            Data = null
        };
    }
    public static ResponseDto Failure(string message = "An error occurred")
{
    return new ResponseDto
    {
        StatusCode = StatusCodes.Status500InternalServerError,
        Message = message,
        Data = null
    };
}
}
