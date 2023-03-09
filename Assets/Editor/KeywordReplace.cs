using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeywordReplace : UnityEditor.AssetModificationProcessor {
    public static void OnWillCreateAsset ( string path ) {
        path = path.Replace( ".meta", "" );
        int index = path.LastIndexOf( ".", StringComparison.Ordinal);
        if (index < 0)
            return;
 
        string file = path.Substring( index );
        if (file != ".cs" && file != ".js" && file != ".boo")
            return;
 
        index = Application.dataPath.LastIndexOf( "Assets", StringComparison.Ordinal);
        path = Application.dataPath.Substring( 0, index ) + path;
        if (!System.IO.File.Exists( path ))
            return;
 
        string fileContent = System.IO.File.ReadAllText( path );
        string systemName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        if (systemName.Contains("\\")) {
            var strings = systemName.Split('\\');
            systemName = strings.Length > 0? strings[strings.Length - 1] : "";
        }
        
        fileContent = fileContent.Replace("#DATE#", System.DateTime.Now + "" );
        fileContent = fileContent.Replace("#PROJECT#", PlayerSettings.productName + " v" + PlayerSettings.bundleVersion);
        fileContent = fileContent.Replace("#COMPANY#", PlayerSettings.companyName);
        fileContent = fileContent.Replace("#USER#", systemName);
        fileContent = fileContent.Replace("#DATE#", System.DateTime.Now.ToString("dd/MMM/yyyy"));
 
        System.IO.File.WriteAllText( path, fileContent );
        AssetDatabase.Refresh();
    }
}
