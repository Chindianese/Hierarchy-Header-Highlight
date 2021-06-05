using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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
}

