using System;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Hierarchy Window Group Header
/// http://diegogiacomelli.com.br/unitytips-changing-the-style-of-the-hierarchy-window-group-header/
/// </summary>
[InitializeOnLoad]
public static class HierarchyHeader
{
    private static readonly HierarchyHeaderSettings _settings;
    private static readonly GUIStyle _style;
    private static HierachyHeaderData headerData;

    static HierarchyHeader()
    {
        _settings = HierarchyHeaderSettings.Instance;
        _style = new GUIStyle();
        UpdateStyle();
        _settings.Changed.AddListener(UpdateStyle);

        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }

    private static void UpdateStyle()
    {
        _style.fontSize = _settings.FontSize;
        _style.fontStyle = _settings.FontStyle;
        _style.alignment = _settings.Alignment;
        // _style.normal.textColor = _settings.TextColor;
        EditorApplication.RepaintHierarchyWindow();
    }

    private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        for (int i = 0; i < _settings.GetHeadereDataCount(); ++i)
        {
            HierachyHeaderData data = _settings.GetHeaderData(i);
            if (gameObject != null && gameObject.name.StartsWith(data.NameStartsWith, StringComparison.Ordinal))
            {
                headerData = data;
                EditorGUI.DrawRect(selectionRect, headerData.backgroundColor);
                _style.normal.textColor = headerData.textColor;
                EditorGUI.LabelField(selectionRect, gameObject.name.Replace(headerData.NameStartsWith, "").ToUpperInvariant(), _style);
                return;
            }
        }
    }
}