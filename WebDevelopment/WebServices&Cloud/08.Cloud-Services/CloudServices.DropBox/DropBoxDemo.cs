/*
 * Task 3
 Write a C# program to publish a photo album with few photos into 
 DropBox and share the photos through the Dropbox sharing functionality.
 */

using System;
using System.IO;
using System.Diagnostics;
using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.IO;

namespace CloudServices.DropBox
{
    class DropBoxDemo
    {
        // Register your own Dropbox app at https://www.dropbox.com/developers/apps
        // with "Full Dropbox" access level and set your app keys and app secret below
        private const string DropboxAppKey = "avebpvpe2pr4o85";
        private const string DropboxAppSecret = "bz5ysp3dsw0xh6l";

        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

        static void Main()
        {
            // Start the project - Ctrl + F5
            // You will be asked to sign in your DropBox account or to register if you do not have an account yet
            // Then the API will create a folder in your dropbox and will upload 2 photos in this folder
            // (The photos are in the VS project folder)
            // Then you may share the photos through the Dropbox sharing functionality

            DropboxServiceProvider dropboxServiceProvider =
                new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            // Authenticate the application (if not authenticated) and load the OAuth token
            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth(dropboxServiceProvider);
            }
            OAuthToken oauthAccessToken = LoadOAuthToken();

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            // Display user name (from his profile)
            DropboxProfile profile = dropbox.GetUserProfileAsync().Result;
            Console.WriteLine("Hi " + profile.DisplayName + "!");

            // Create new folder
            string newFolderName = "PhotoAlbum_" + DateTime.Now.Ticks;
            Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
            Console.WriteLine("Created folder: {0}", createFolderEntry.Path);

            // Upload a file
            Entry uploadFileEntry = dropbox.UploadFileAsync(
                new FileResource("../../Agassi_Federer.jpg"),
                "/" + newFolderName + "/Agassi_Federer.jpg").Result;
            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);

            Entry uploadFileEntry2 = dropbox.UploadFileAsync(
                new FileResource("../../Nadal.jpg"),
                "/" + newFolderName + "/Nadal.jpg").Result;
            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);

            // Share a file
            DropboxLink sharedUrl = dropbox.GetShareableLinkAsync(createFolderEntry.Path).Result;
            Process.Start(sharedUrl.Url);
            Console.WriteLine("Link for sharing the album photos: {0}", sharedUrl.Url);
            Console.WriteLine("Link expires on: {0}", sharedUrl.ExpireDate);
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        {
            // Authorization without callback url
            Console.Write("Getting request token...");
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
            Console.WriteLine("Done.");

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
                oauthToken.Value, parameters);
            Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
            Process.Start(authenticateUrl);
            Console.Write("Press [Enter] when authorization attempt has succeeded.");
            Console.ReadLine();

            Console.Write("Getting access token...");
            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken =
                dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
            Console.WriteLine("Done.");

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }
    }
}
