using System.Collections;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Networking;
using static System.IO.Directory;
using static System.IO.Path;

namespace ZupEditorUtils
{
    public static class Setup
    {
        [MenuItem("Tools/Setup/Create Git Ignore")]
        public static async void CreateGitIgnore()
        {
            await Git.CreateGitIgnore("unity", "rider");
        }
        
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            Folders.CreateDefault("_Project",
                "Animation",
                "Art",
                "Prefabs",
                "Materials",
                "ScriptableObjects",
                "Scripts");
        }

        static class Folders
        {
            public static void CreateDefault(string root, params string[] folders)
            {
                var fullPath = Combine(Application.dataPath, root);
                foreach (var var in folders)
                {
                    var path = Combine(fullPath, var);
                    if (!Exists(path))
                    {
                        CreateDirectory(path);
                    }
                }
            }
        }

        static class Git
        {
            private const string API_ADDRESS = "https://www.toptal.com/developers/gitignore/api/";

            public static async Task CreateGitIgnore(params string[] ignoreThese)
            {
                string fullPullAddress = GitPullAddress(ignoreThese);
                Debug.Log($"pulling git ignore content from URL:{fullPullAddress}\n" +
                          $"If any error occurs use URL and check 4th Line");
                string getResponse = await GetGitIgnoreText(fullPullAddress);

                if (getResponse.StartsWith("#"))
                {
                    CreateGitIgnoreFile(getResponse);
                }
            }
            
            private static string GitPullAddress(params string[] keys)
            {
                StringBuilder str = new StringBuilder();
                str.Append(API_ADDRESS);
                for (int i = 0; i < keys.Length; i++)
                {
                    str.Append(keys[i]);
                    if (i + 1 < keys.Length) str.Append(",");
                }

                return str.ToString();
            }

            private static async Task<string> GetGitIgnoreText(string fullPath)
            {
                using (UnityWebRequest webRequest = UnityWebRequest.Get(fullPath))
                {
                    // Send the request and await completion
                    var operation = webRequest.SendWebRequest();
                    while (!operation.isDone)
                        await Task.Yield();

                    // Handle the response
                    if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
                    {
                        Debug.LogError($"GET Error: {webRequest.error}");
                        return $"Error: {webRequest.error}";
                    }
                    
                    return webRequest.downloadHandler.text;
                }
            }

            private static void CreateGitIgnoreFile(string gitIgnoreContent)
            {
                string rootFolder = GetDirectoryName(Application.dataPath);
                if (rootFolder is not null)
                {
                    string gitIgnorePath = Combine(rootFolder, ".gitignore");
                    if (File.Exists(gitIgnorePath))
                    {
                        File.Delete(gitIgnorePath);
                    }
                    
                    File.WriteAllText(gitIgnorePath,gitIgnoreContent);
                }

            }
        }
    }
}
