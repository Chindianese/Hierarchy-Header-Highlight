using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Chindianese.HierarchyHeader
{
    /// <summary>
    /// Settings window for heirachy header
    /// http://diegogiacomelli.com.br/unitytips-changing-the-style-of-the-hierarchy-window-group-header/
    /// </summary>
    [CreateAssetMenu(menuName = "Hierarchy Header/Header Settings", fileName = "HierarchyHeaderSettings")]
    public class HierarchyHeaderSettings : ScriptableObject
    {
        [HideInInspector]
        public UnityEvent Changed;

        [SerializeField]
        public HierarchyHeaderPreset preset;


        private static HierarchyHeaderSettings _instance;
        public static HierarchyHeaderSettings Instance => _instance ?? (_instance = LoadAsset());
        private static HierarchyHeaderSettings LoadAsset()
        {
            var path = GetAssetPath();
            var asset = AssetDatabase.LoadAssetAtPath<HierarchyHeaderSettings>(path);

            //if (asset == null)
            //{
            //    asset = CreateInstance<HierarchyWindowGroupHeaderSettings>();
            //    AssetDatabase.CreateAsset(asset, path);
            //    AssetDatabase.SaveAssets();
            //}

            return asset;
        }

        private static string GetAssetPath([CallerFilePath] string callerFilePath = null)
        {
            var folder = Path.GetDirectoryName(callerFilePath);

#if UNITY_EDITOR_WIN
            folder = folder.Substring(folder.LastIndexOf(@"\Assets\", StringComparison.Ordinal) + 1);
#else
        folder = folder.Substring(folder.LastIndexOf("/Assets/", StringComparison.Ordinal) + 1);
#endif

            return Path.Combine(folder, "HierarchyHeaderSettings.asset");
        }
    }
}