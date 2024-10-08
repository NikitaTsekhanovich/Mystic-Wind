using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StoreSkinsContrllers
{
    public class SkinsDataContainer
    {
        public static List<StoreSkinData> SkinsData { get; private set; }

        public static void LoadSkinsData()
        {
            SkinsData = Resources.LoadAll<StoreSkinData>("ScriptableObjectSkinsData")
                .OrderBy(x => x.Index)
                .ToList();
        }
    }
}

