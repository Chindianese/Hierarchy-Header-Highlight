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
            _settings.preset.Changed.AddListener(UpdateStyle);

            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
            Debug.Log("Enabled");
            SceneView.duringSceneGui += OnSceneGUI;
        }
        static void OnSceneGUI(SceneView sceneView)
        {
            if (SceneView.lastActiveSceneView != null)
            {
                GameObject target = Selection.activeObject as GameObject;
                if (target == null) return;
                if (!IsHeaderType(target.name)) return;
                var data = GetHeaderData(target.name);
                if (!data.sceneHighlightEnabled) return;
                if (target.transform.childCount <= 0) return;

                Handles.BeginGUI();
                // Draw something here using GUI or GUILayout...
                GUILayout.Label("scene label");
                Handles.EndGUI();
                var color = data.backgroundColor;

                float lineLength = 5.0f;
                float lineThickness = 4.0f;
                foreach(Transform child in target.transform)
                {
                    Handles.color = color;
                    if (IsHeaderType(child.name))
                    {
                        var dataChild = GetHeaderData(child.name);
                        Handles.color = dataChild.backgroundColor;
                    }
                    Handles.DrawLine(child.position, child.position + Vector3.up * lineLength, lineThickness);
                }

                SceneView.lastActiveSceneView.Repaint();
            }
        }
        private static void UpdateStyle()
        {
            EditorApplication.RepaintHierarchyWindow();
        }

        private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null)
                return;

            if (!IsHeaderType(gameObject.name)) return;

            headerData = GetHeaderData(gameObject.name);

            EditorGUI.DrawRect(selectionRect, headerData.backgroundColor);
            _style.normal.textColor = headerData.textColor;
            _style.fontSize = headerData.fontSize;
            _style.fontStyle = headerData.fontStyle;
            _style.alignment = headerData.alignment;
            if (headerData.NameStartsWith != "")
                EditorGUI.LabelField(selectionRect, gameObject.name.Replace(headerData.NameStartsWith, "").ToUpperInvariant(), _style);
        }
        private static bool IsHeaderType(string referenceName)
        {
            for (int i = 0; i < _settings.preset.GetHeadereDataCount(); ++i)
            {
                HierachyHeaderData data = _settings.preset.GetHeaderData(i);
                if ( referenceName.StartsWith(data.NameStartsWith, StringComparison.Ordinal)) // find target header type
                {                   
                    return true;
                }
            }
            return false;
        }
        private static HierachyHeaderData GetHeaderData(string referenceName)
        {
            for (int i = 0; i < _settings.preset.GetHeadereDataCount(); ++i)
            {
                HierachyHeaderData data = _settings.preset.GetHeaderData(i);
                if (referenceName.StartsWith(data.NameStartsWith, StringComparison.Ordinal)) // find target header type
                { 
                    return data;
                }
            }
            return new HierachyHeaderData();
        }
    }
}