using System;
using System.Windows;
using VideoOS.Platform.SDK.UI.LoginDialog;

namespace VideoViewerPlayBack
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Guid integrationId = new Guid("9f0591fd-6227-4e2c-bf67-40db84415857");
            string integrationName = "VideoViewerPlayBack";
            string manufacturerName = "Your company name";
            string version = "1.0";

            VideoOS.Platform.SDK.Environment.Initialize();          // General initialize.  Always required
            VideoOS.Platform.SDK.UI.Environment.Initialize();       // Initialize UI references
            //VideoOS.Platform.SDK.Export.Environment.Initialize();	// Initialize export references
            //VideoOS.Platform.SDK.Media.Environment.Initialize();	// Initialize live streaming references

            bool connected = false;
            DialogLoginForm loginForm = new DialogLoginForm(new DialogLoginForm.SetLoginResultDelegate((b) => connected = b), integrationId, integrationName, version, manufacturerName);
            //loginForm.LoginLogoImage = MyOwnImage;				// Set own header image
            loginForm.ShowDialog();								// Show and complete the form and login to server

            if (!connected)
            {
                Current.Shutdown();
            }
        }
    }
}
