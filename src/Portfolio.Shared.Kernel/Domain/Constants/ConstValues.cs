using System.Reflection;

namespace Portfolio.Shared.Kernel.Domain.Constants;

public class ExceptionsTranslationsKeys
{
    public static readonly string DefaultErrorTitle = "defaultError.title";
    public static readonly string DefaultErrorMessage = "defaultError.message";
    
    public static readonly string BadRequestTitle = "badRequest.title";
    public static readonly string BadRequestMessage = "badRequest.message";

    public static readonly string ForbiddenTitle = "forbidden.title";
    public static readonly string ForbiddenMessage = "forbidden.message";

    public static readonly string UnauthorizedTitle = "unauthorized.title";
    public static readonly string UnauthorizedMessage = "unauthorized.message";
    
    public static readonly string TokenNotFoundInHeadersTitle = "tokenNotFoundInHeaders.title";
    public static readonly string TokenNotFoundInHeadersMessage = "tokenNotFoundInHeaders.message";

    public static readonly string InvalidStateTitle = "invalidState.title";
    public static readonly string InvalidStateMessage = "invalidState.message";
    
    public static readonly string RefreshTokenExpiredTitle = "refreshTokenExpired.Title";
    public static readonly string RefreshTokenExpiredMessage = "refreshTokenExpired.Message";

    public static readonly string NeedReauthTitle = "needReauth.title";
    public static readonly string NeedReauthMessage = "needReauth.message";

    public static readonly string NotFoundTitle = "notFound.title";
    public static readonly string NotFoundMessage = "notFound.message";

    public static readonly string UserNotFoundTitle = "userNotFound.title";
    public static readonly string UserNotFoundMessage = "userNotFound.message";

    public static readonly string UserNameAlreadyTakenMessage = "userNameAlreadyTaken.message";
    public static readonly string EmailNameAlreadyTakenMessage = "emailNameAlreadyTaken.message";
    public static readonly string EmailOriginLinkWasNotFoundMessage = "emailOriginLinkWasNotFound.message";

    public static readonly string ValidationLanguageNotExist = "validationLanguageNotExist";
    
    public static readonly string ValidationExceptionTitle = "validationException.title";
    public static readonly string ValidationExceptionMessage = "validationException.message";

    public static readonly string UnableToSendEmailTitle = "unableToSendEmail.title";
    public static readonly string UnableToSendEmailMessage = "unableToSendEmail.message";

    public static readonly string ActionTokenAlreadyUsedMessage = "actionTokenAlreadyUsed.message";
    public static readonly string ActionTokenInvalidTypeMessage = "actionTokenInvalidType.message";
}

public class EmailTranslationsKeys
{
    private static readonly string EmailTranslationsStartWith = "emailKeys_";
    public static class LayoutTranslationsKeys
    {
        private static readonly string EmailLayoutTranslationsStartWith = $"{EmailTranslationsStartWith}Layout_";
        
        public static readonly string Header = $"{EmailLayoutTranslationsStartWith}Header";
        public static readonly string Footer = $"{EmailLayoutTranslationsStartWith}Footer";
    }

    public static class EmailConfirmationKeys
    {
        private static readonly string EmailConfirmationTranslationsStartWith = $"{EmailTranslationsStartWith}EmailConfirmation_";

        public static readonly string ConfirmEmail = $"{EmailConfirmationTranslationsStartWith}ConfirmEmail";
        public static readonly string MainBody = $"{EmailConfirmationTranslationsStartWith}MainBody";
        public static readonly string ConfirmEmailButton = $"{EmailConfirmationTranslationsStartWith}ConfirmEmailButton";
    }
}

public class HeadersKeys
{
    public static readonly string MailOriginLink = "MailOriginLink";
    public static readonly string Authorization = "Authorization";
    public static readonly string LanguageId = "LanguageId";
}

public enum ActionTokenTypes
{
    ResetPassword,
    ConfirmEmail
}

public enum MailTemplates
{
    RegistrationConfirmation,
    TwoFactorAuthentication
}

public enum TwoFaStrategyTypes
{
    Email2FaStrategy = 0,
    Sms2FaStrategy = 1,
    Totp2FaStrategy = 2
}

public class ContentType
{
    public static readonly string ApplicationJson = "application/json";
    public static readonly string TextPlain = "text/plain";
    public static readonly string Wildcard = "*/*";
}

public class ClaimsTypes
{
    public static readonly string UserIdClaim = "UserId";
    public static readonly string PermissionListClaim = "Permissions";
    public static readonly string ActionToken = "ActionToken";
    public static readonly string ActionTokenType = "ActionTokenType";
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
