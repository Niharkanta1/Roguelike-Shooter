using UnityEditor;

namespace Editor
{
    public static class CreateClasses
    {
        private const string PathToCSharpScripts = "Assets/Editor/Templates/CSharpScripts/";
        private const string PathToUnityScripts = "Assets/Editor/Templates/UnityScripts/";
        private const string InterfaceTemplate = "Interface.cs.txt";
        private const string EmptyClassTemplate = "EmptyClass.cs.txt";
        private const string EnumTemplate = "Enum.cs.txt";
        private const string StructTemplate = "Struct.cs.txt";
        private const string EmptyScriptTemplate = "EmptyScript.cs.txt";
        private const string EmptySingletonScriptTemplate = "EmptySingletonScript.cs.txt";
        
        [MenuItem(itemName: "Assets/Create/Script/C# Class", isValidateFunction: false, priority: 61)]
        public static void CreateClassFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(PathToCSharpScripts + EmptyClassTemplate, "EmptyClass.cs");
        }

        [MenuItem(itemName: "Assets/Create/Script/C# Enum", isValidateFunction: false, priority: 61)]
        public static void CreateEnumFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(PathToCSharpScripts + EnumTemplate, "Enum.cs");
        }

        [MenuItem(itemName: "Assets/Create/Script/C# Interface", isValidateFunction: false, priority: 61)]
        public static void CreateInterfaceFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(PathToCSharpScripts + InterfaceTemplate, "Interface.cs");
        }

        [MenuItem(itemName: "Assets/Create/Script/C# Struct", isValidateFunction: false, priority: 61)]
        public static void CreateStructFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(PathToCSharpScripts + StructTemplate, "Struct.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Unity Script", isValidateFunction: false, priority: 70)]
        public static void CreateScriptFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(PathToUnityScripts + EmptyScriptTemplate, "EmptyScript.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Unity Singleton Script", isValidateFunction: false, priority: 70)]
        public static void CreateSingletonScriptFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(PathToUnityScripts + EmptySingletonScriptTemplate, "EmptySingletonScript.cs");
        }

    }
}