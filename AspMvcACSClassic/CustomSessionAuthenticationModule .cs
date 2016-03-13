using System;
using System.Diagnostics;
using System.IdentityModel.Services;

namespace AspMvcACSClassic
{
    /// <summary>
    /// Capture SessionAuthenticationModule events
    /// https://msdn.microsoft.com/en-us/library/system.identitymodel.services.sessionauthenticationmodule
    /// </summary>
    sealed class CustomSessionAuthenticationModule : SessionAuthenticationModule
    {
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
            Debug.WriteLine("SignOutError. Message: " + e.Exception.Message);
        }

        private void CustomAuthenticationModule_SigningOut(object sender, SigningOutEventArgs e)
        {
            Debug.WriteLine("SigningOut"); 
        }

        private void CustomAuthenticationModule_SignedOut(object sender, EventArgs e)
        {
            Debug.WriteLine("SignedOut"); 
        }

        private void CustomAuthenticationModule_SessionSecurityTokenCreated(object sender, SessionSecurityTokenCreatedEventArgs e)
        {
            Debug.WriteLine("SessionSecurityTokenCreated. SessionSecurityToken: " + e.SessionToken.Id + " KeyExpirationTime:" + e.SessionToken.KeyExpirationTime); 
        }

        private void CustomAuthenticationModule_SessionSecurityTokenReceived(object sender, SessionSecurityTokenReceivedEventArgs e)
        {
            Debug.WriteLine("SessionSecurityTokenReceived. SessionSecurityToken:" + e.SessionToken.Id + " KeyExpirationTime:" + e.SessionToken.KeyExpirationTime); 
        }
    }
}