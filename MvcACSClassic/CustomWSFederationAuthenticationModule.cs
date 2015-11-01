using System;
using System.IdentityModel.Services;
using log4net;

namespace MvcACSClassic
{
    /// <summary>
    /// Logger for WSFederationAuthenticationModule events
    /// https://msdn.microsoft.com/en-us/library/system.identitymodel.services.wsfederationauthenticationmodule%28v=vs.110%29.aspx
    /// </summary>
    sealed class CustomWSFederationAuthenticationModule : WSFederationAuthenticationModule
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(WSFederationAuthenticationModule));

        public CustomWSFederationAuthenticationModule()
        {
            base.AuthorizationFailed += CustomAuthenticationModule_AuthorizationFailed;
            base.RedirectingToIdentityProvider += CustomAuthenticationModule_RedirectingToIdentityProvider;
            base.SecurityTokenReceived += CustomAuthenticationModule_SecurityTokenReceived;
            base.SecurityTokenValidated += CustomAuthenticationModule_SecurityTokenValidated;
            base.SessionSecurityTokenCreated += CustomAuthenticationModule_SessionSecurityTokenCreated;
            base.SignedIn += CustomAuthenticationModule_SignedIn;
            base.SignedOut += CustomAuthenticationModule_SignedOut;
            base.SignInError += CustomAuthenticationModule_SignInError;
            base.SigningOut += CustomAuthenticationModule_SigningOut;
            base.SignOutError += CustomAuthenticationModule_SignOutError;
        }

        private void CustomAuthenticationModule_SignOutError(object sender, ErrorEventArgs e)
        {
            var auth = (CustomWSFederationAuthenticationModule)sender;
            _log.Warn("SignOutError. Message: " + e.Exception.Message);
        }

        private void CustomAuthenticationModule_SigningOut(object sender, SigningOutEventArgs e)
        {
            var auth = (CustomWSFederationAuthenticationModule)sender;
            _log.Info("SigningOut");
        }

        private void CustomAuthenticationModule_SignInError(object sender, ErrorEventArgs e)
        {
            var auth = (CustomWSFederationAuthenticationModule)sender;
            _log.Warn("SignInError. Message: " + e.Exception.Message);
        }

        private void CustomAuthenticationModule_SignedOut(object sender, EventArgs e)
        {
            var auth = (CustomWSFederationAuthenticationModule)sender;
            _log.Info("SignedOut");
        }

        private void CustomAuthenticationModule_SignedIn(object sender, EventArgs e)
        {
            var auth = (CustomWSFederationAuthenticationModule)sender;
            _log.Info("SignedIn");
        }

        private void CustomAuthenticationModule_SessionSecurityTokenCreated(object sender, SessionSecurityTokenCreatedEventArgs e)
        {
            var auth = (CustomWSFederationAuthenticationModule)sender;
            var token = (System.IdentityModel.Tokens.SessionSecurityToken) e.SessionToken;
            _log.Info("SessionSecurityTokenCreated. TokenId:" + token.Id + " KeyExpirationTime:" + token.KeyExpirationTime);
        }

        private void CustomAuthenticationModule_SecurityTokenValidated(object sender, SecurityTokenValidatedEventArgs e)
        {
            var auth = (CustomWSFederationAuthenticationModule)sender;
            _log.Info("SecurityTokenValidated");
        }

        private void CustomAuthenticationModule_RedirectingToIdentityProvider(object sender, RedirectingToIdentityProviderEventArgs e)
        {
            var auth = (CustomWSFederationAuthenticationModule)sender;
            _log.Info("RedirectingToIdentityProvider. SignInRequestMessage:" + e.SignInRequestMessage);
        }

        private void CustomAuthenticationModule_AuthorizationFailed(object sender, AuthorizationFailedEventArgs e)
        {
            var auth = (CustomWSFederationAuthenticationModule) sender;
            _log.Warn("AuthorizationFailed. RedirectToIdentityProvider:" + e.RedirectToIdentityProvider);
        }

        public void CustomAuthenticationModule_SecurityTokenReceived(object sender, SecurityTokenReceivedEventArgs e)
        {
            var auth = (CustomWSFederationAuthenticationModule)sender;
            _log.Info("SecurityTokenReceived. SecurityToken:" + e.SecurityToken + " SignInContext:" + e.SignInContext);
        }
    }
}