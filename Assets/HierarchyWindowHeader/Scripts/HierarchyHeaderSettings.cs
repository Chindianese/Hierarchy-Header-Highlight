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

    [Space(10)]
    [SerializeField]
    private List<HierachyHeaderData> headerData = new List<HierachyHeaderData>();

    private static HierarchyHeaderSettings _instance;
    public static HierarchyHeaderSettings Instance => _instance ?? (_instance = LoadAsset());

    int prevHeaderDataLength = 0;
    private void OnValidate()
    {
        Changed?.Invoke();
        if(prevHeaderDataLength < headerData.Count)
        {
            headerData[headerData.Count - 1].Reset();
        }
         prevHeaderDataLength = headerData.Count;
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