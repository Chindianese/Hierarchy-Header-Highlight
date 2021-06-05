using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Chindianese.HierarchyHeader
{
    /// <author>Tay Hao Cheng</author>
    /// <summary>
    /// Hold data for each header type
    /// </summary>
    [System.Serializable]
    public struct HierachyHeaderData
    {

        [Tooltip("Title")]
        public string HeaderTypeName;

        [Tooltip("---")]
        public string NameStartsWith;

        [Tooltip("Gray")]
        public Color backgroundColor;

        [SerializeField]
        [Tooltip("Black")]
        public Color textColor;

        [SerializeField]
        [Tooltip("Bold")]
        public FontStyle fontStyle;

        [SerializeField]
        [Tooltip("14")]
        public int fontSize;

        [SerializeField]
        [Tooltip("Middle Center")]
        public TextAnchor alignment;

        public void Reset()
        {
            backgroundColor = Color.gray;
            textColor = Color.black;
            NameStartsWith = "---";
            HeaderTypeName = "name";
            fontSize = 14;
            fontStyle = FontStyle.Bold;
            alignment = TextAnchor.MiddleCenter;
        }
    }
}