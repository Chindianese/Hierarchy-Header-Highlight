using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Settings window for heirachy header
/// http://diegogiacomelli.com.br/unitytips-changing-the-style-of-the-hierarchy-window-group-header/
/// </summary>
[CreateAssetMenu(fileName = "Header/HeaderSettings")]
public class HierarchyHeaderSettings : ScriptableObject
{
    [HideInInspector]
    public UnityEvent Changed;

    [SerializeField]
    [Tooltip("Bold")]
    public FontStyle FontStyle = FontStyle.Bold;

    [SerializeField]
    [Tooltip("14")]
    public int FontSize = 14;

    [SerializeField]
    [Tooltip("Middle Center")]
    public TextAnchor Alignment = TextAnchor.MiddleCenter;

    [Space(10)]
    [SerializeField]
    private List<HierachyHeaderData> headerData = new List<HierachyHeaderData>();

    private static HierarchyHeaderSettings _instance;
    public static HierarchyHeaderSettings Instance => _instance ?? (_instance = LoadAsset());

    private void OnValidate()
    {
        Changed?.Invoke();
    }

    public HierachyHeaderData GetHeaderData(int index)
    {
        return headerData[index];
    }

    public int GetHeadereDataCount()
    {
        return headerData.Count;
    }

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