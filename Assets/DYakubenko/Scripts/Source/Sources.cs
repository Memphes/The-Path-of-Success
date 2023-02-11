#nullable enable

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DYakubenko
{
    public class Sources : MonoBehaviour
    {
        
        private Dictionary<string, int>? sourcesHub = new Dictionary<string, int>();
        
        
        public int GetSource (string nameSource, int count)
        {
            if (nameSource == null) throw new ArgumentNullException(nameof(nameSource));

           var sourceValue = sourcesHub![nameSource];

            if (sourceValue < count)
            {
                sourceValue -= count;
                var deficit = Mathf.Abs(sourceValue);
                print($"Не хватает {deficit} {nameSource}");
            }
            else
            {
                sourceValue -= count;
                sourcesHub[nameSource] = sourceValue;
            }
            return sourceValue;
        }

        public int AddSource(string nameSource, int count)
        {
            sourcesHub![nameSource] += count;
            return sourcesHub[nameSource];
        }

        
        [ContextMenu(nameof(Save))]
        public void Save()
        {
            var json = JsonConvert.SerializeObject(sourcesHub);
            PlayerPrefs.SetString("sourcesKey", json);
        }

        
        [ContextMenu(nameof(Load))]
        public void Load()
        {
            var raw = PlayerPrefs.GetString("sourcesKey");
            sourcesHub = string.IsNullOrWhiteSpace(raw)
                ? new Dictionary<string, int>()
                {
                    {"money", 100},
                    {"health" , 100},
                    {"hunger", 0},
                    {"condition", 50},
                    {"status", 1 },
                    {"day", 0 },
                    {"timeTODO", 0}
            
                }
                : JsonConvert.DeserializeObject<Dictionary<string, int>>(raw);
        }
    
        [ContextMenu(nameof(ResetSources))]
        public void ResetSources()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}