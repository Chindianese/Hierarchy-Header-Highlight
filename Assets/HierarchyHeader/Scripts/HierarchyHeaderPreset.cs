using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Chindianese.HierarchyHeader
{
    /// <author>Tay Hao Cheng</author>
    /// <summary>
    /// Style preset for header types
    /// </summary>
    [CreateAssetMenu(menuName = "Hierarchy Header/Header Preset")]
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
            UpdateHeaderDateDefault();
        }
        /// <summary>
        /// Reset header data to default if array expands. This is done because Unity Serialsed objects do not have default data,
        /// and default to 0
        /// </summary>
        public void UpdateHeaderDateDefault()
        {
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