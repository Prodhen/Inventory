using System;
using FluentValidation.Results;

namespace API.Helper;

public static class ErrorHelper
{
    public static List<string> FluentErrorMessages(List<ValidationFailure> errors)
        {
            List<string> errorsMessages = new List<string>();
            foreach (var failure in errors)
            {
                errorsMessages.Add(failure.ErrorMessage);
            }
            return errorsMessages;
        }



}
