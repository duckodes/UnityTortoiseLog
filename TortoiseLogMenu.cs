using UnityEditor;
using System.Diagnostics;

public class TortoiseLogMenu
{
    private static string s_exePath = "C:\\Program Files\\TortoiseGit\\bin\\TortoiseGitProc.exe";
    [MenuItem("Assets/Show Tortoise Log", priority = 0)]
    private static void ShowTortoiseLog()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (!string.IsNullOrEmpty(path))
        {
            try
            {
                Process.Start("TortoiseGitProc.exe", $"/command:log /path:\"{path}\"");
            }
            catch
            {
                try
                {
                    Process.Start(s_exePath, $"/command:log /path:\"{path}\"");
                }
                catch
                {
                    s_exePath = EditorUtility.OpenFilePanel(
                        "請選擇 TortoiseGitProc.exe",
                        "C:\\Program Files\\TortoiseGit\\bin",
                        "exe"
                    );
                    if (!string.IsNullOrEmpty(s_exePath))
                    {
                        Process.Start(s_exePath, $"/command:log /path:\"{path}\"");
                    }
                }
            }
        }
        else
        {
            s_exePath = EditorUtility.OpenFilePanel(
                        "請選擇 TortoiseGitProc.exe",
                        "C:\\Program Files\\TortoiseGit\\bin",
                        "exe"
                    );
            if (!string.IsNullOrEmpty(s_exePath))
            {
                Process.Start(s_exePath, $"/command:log /path:\"{path}\"");
            }
        }
    }
}
