using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class DiscordRP
{

    private static string applicationId = "509465267630374935";
    private static DiscordRpc.EventHandlers handlers;

    [MenuItem("DiscordRP/Enable Rich Presence")]
    private static void Enable()
    {
        if (!EditorPrefs.GetBool("enabled"))
        {
            EditorPrefs.SetBool("enabled", true);
            Debug.Log("Unity Editor Rich Presence : Enabled");
            Init();
        }
        else
        {
            Debug.Log("Unity Editor Rich Presence is already enabled");
        }
    }

    [MenuItem("DiscordRP/Disable Rich Presence")]
    private static void Disable()
    {
        if (EditorPrefs.GetBool("enabled"))
        {
            EditorPrefs.SetBool("enabled", false);
            DiscordRpc.Shutdown();
            Debug.Log("Unity Editor Rich Presence has been disabled");
        }
    }
    
    static DiscordRP() {
        if (!EditorPrefs.GetBool("enabled", true)) return;
        Init();
        EditorApplication.update += Update;
        EditorPrefs.SetBool("enabled", true);
    }

    private static void Update()
    {
        DiscordRpc.RunCallbacks();
    }


    private static void Init()
    {
        EditorSceneManager.sceneOpened += SceneOpened;
        
        handlers = new DiscordRpc.EventHandlers();
        handlers.disconnectedCallback += DisconnectedCallback;
        handlers.errorCallback += ErrorCallback;
        handlers.requestCallback += RequestCallback;
        DiscordRpc.Initialize(applicationId, ref handlers, true, "1234");

        UpdatePresence();
    }

    private static void SceneOpened(UnityEngine.SceneManagement.Scene scene, OpenSceneMode mode)
    {
        UpdatePresence();
    }

    //This updates the presence
    private static void UpdatePresence() {
        var timeSpan = TimeSpan.FromMilliseconds(EditorAnalyticsSessionInfo.elapsedTime);
        DiscordRpc.RichPresence discordPresence = new DiscordRpc.RichPresence {
            state = "Scene: " + (SceneManager.GetActiveScene().name.Length == 0 ? "DefaultGameScene" : SceneManager.GetActiveScene().name),
            details = "Project: " + PlayerSettings.productName, //GetProjectName(),
            largeImageKey = "logo",
            largeImageText = "Unity " + Application.unityVersion,
            startTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
        };
        DiscordRpc.UpdatePresence(discordPresence);
    }


    static string GetProjectName()
    {
        string path = Application.dataPath;
        string[] folders = path.Split("/"[0]);
        return folders[folders.Length - 2];
    }

    private static void RequestCallback(ref DiscordRpc.DiscordUser request)
    {
        throw new NotImplementedException();
    }

    private static void ErrorCallback(int errorCode, string message)
    {
        Debug.LogError(errorCode + " | " + message);
    }

    private static void DisconnectedCallback(int errorCode, string message)
    {
        Debug.Log("Unity Editor Rich Presence has been disconnected \n " + errorCode + " | " + message);
    }
}
