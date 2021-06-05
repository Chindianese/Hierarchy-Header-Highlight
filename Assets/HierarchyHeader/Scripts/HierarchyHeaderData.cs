using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Chindianese.HierarchyHeader
{
    [System.Serializable]
    public class HierachyHeaderData
    {

        [Tooltip("Title")]
        public string HeaderTypeName;

        [Tooltip("---")]
        public string NameStartsWith /*= "---"*/;



        // [Tooltip("Bold")]
        // public string RemoveString /* ="-"*/;
        // public FontStyle FontStyle /*= FontStyle.Bold*/;

        // [Tooltip("14")]
        // public int FontSize /*= 14*/;

        [Tooltip("Gray")]
        public Color backgroundColor = Color.gray;

        [SerializeField]
        [Tooltip("Black")]
        public Color textColor = Color.black;

        [SerializeField]
        [Tooltip("Bold")]
        public FontStyle fontStyle = FontStyle.Bold;

        [SerializeField]
        [Tooltip("14")]
        public int fontSize = 14;

        [SerializeField]
        [Tooltip("Middle Center")]
        public TextAnchor alignment = TextAnchor.MiddleCenter;

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