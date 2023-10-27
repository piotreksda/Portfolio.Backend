namespace Portfolio.Domain.Core.Infrastructure.Contatints;

public class ExceptionsTranslationsKeys
{
    public static readonly string DefaultErrorTitle = "defaultError.title";
    public static readonly string DefaultErrorMessage = "defaultError.message";
    public static readonly string BadRequestTitle = "badRequest.title";
    public static readonly string BadRequestMessage = "badRequest.Message";

    public static readonly string ForbiddenTitle = "forbidden.title";
    public static readonly string ForbiddenMessage = "forbidden.message";

    public static readonly string TokenNotFoundInHeadersTitle = "tokenNotFoundInHeaders.title";
    public static readonly string TokenNotFoundInHeadersMessage = "tokenNotFoundInHeaders.message";
    
    public static readonly string RefreshTokenExpiredTitle = "refreshTokenExpired.Title";
    public static readonly string RefreshTokenExpiredMessage = "refreshTokenExpired.Message";

    public static readonly string NeedReauthTitle = "needReauth.title";
    public static readonly string NeedReauthMessage = "needReauth.message";


    public static readonly string ValidationLanguageNotExist = "validationLanguageNotExist";
}

public class ContentType
{
    public static readonly string ApplicationJson = "application/json";
    public static readonly string TextPlain = "text/plain";
    public static readonly string Wildcard = "*/*";
}

public class DefaultSettings
{
    public static int DefaultLangId = 1;
}

public enum ForceFrontExceptionAction
{
    NoAction = 0,
    Logout = 1,
    RefreshToken = 2,
}
