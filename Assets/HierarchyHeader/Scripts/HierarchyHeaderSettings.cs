using System;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Chindianese.HierarchyHeader
{
    /// <author>diegogiacomelli - Tay Hao Cheng</author>
    /// <summary>
    /// Settings window for heirachy header. Holds refernce to current preset.
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
        /// <summary>
        /// Create string path of settings assets, assumed to be in the same folder as this script
        /// </summary>
        /// <param name="callerFilePath"></param>
        /// <returns></returns>
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