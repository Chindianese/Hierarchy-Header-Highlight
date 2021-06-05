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
    [CreateAssetMenu(fileName = "Header/HeaderPreset")]
    [Serializable]
    public class HierarchyHeaderPreset : ScriptableObject
    {
        [HideInInspector]
        public UnityEvent Changed;

        [Space(10)]
        [SerializeField]
        private List<HierachyHeaderData> headerData = new List<HierachyHeaderData>();

        int prevHeaderDataLength = 0;
        private void OnValidate()
        {
            Changed?.Invoke();
            if (prevHeaderDataLength < headerData.Count)
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
    }
}