using System;
using System.IdentityModel.Services;
using log4net;

namespace MvcACSClassic
{
    /// <summary>
    /// Logger for SessionAuthenticationModule events
    /// https://msdn.microsoft.com/en-us/library/system.identitymodel.services.sessionauthenticationmodule%28v=vs.110%29.aspx
    /// </summary>
    sealed class CustomSessionAuthenticationModule : SessionAuthenticationModule
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SessionAuthenticationModule));

        public CustomSessionAuthenticationModule()
        {
            base.SessionSecurityTokenReceived += CustomAuthenticationModule_SessionSecurityTokenReceived;
            base.SessionSecurityTokenCreated += CustomAuthenticationModule_SessionSecurityTokenCreated;
            base.SignedOut += CustomAuthenticationModule_SignedOut;
            base.SigningOut += CustomAuthenticationModule_SigningOut;
            base.SignOutError += CustomAuthenticationModule_SignOutError;
        }

        private void CustomAuthenticationModule_SignOutError(object sender, ErrorEventArgs e)
        {
            var auth = (CustomSessionAuthenticationModule)sender;
            _log.Warn("SignOutError. Message: " + e.Exception.Message);
        }

        private void CustomAuthenticationModule_SigningOut(object sender, SigningOutEventArgs e)
        {
            _log.Info("SigningOut"); 
        }

        private void CustomAuthenticationModule_SignedOut(object sender, EventArgs e)
        {
            _log.Info("SignedOut"); 
        }

        private void CustomAuthenticationModule_SessionSecurityTokenCreated(object sender, SessionSecurityTokenCreatedEventArgs e)
        {
            _log.Info("SessionSecurityTokenCreated. SessionSecurityToken: " + e.SessionToken.Id + " KeyExpirationTime:" + e.SessionToken.KeyExpirationTime); 
        }

        private void CustomAuthenticationModule_SessionSecurityTokenReceived(object sender, SessionSecurityTokenReceivedEventArgs e)
        {
            _log.Info("SessionSecurityTokenReceived. SessionSecurityToken:" + e.SessionToken.Id + " KeyExpirationTime:" + e.SessionToken.KeyExpirationTime); 
        }
    }
}