﻿#nullable enable

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DYakubenko
{
    public class Sources : MonoBehaviour
    {
        
        private Dictionary<string, int>? _sourcesHub = new Dictionary<string, int>();
        
        public event Action<string, int>? SourceUpdate;

        private void ActionUpdate(string nameSource)
        {
            SourceUpdate?.Invoke(nameSource, _sourcesHub![nameSource]);
        }

        public int GetSource (string nameSource, int count)
        {
            if (nameSource == null) throw new ArgumentNullException(nameof(nameSource));

           var sourceValue = _sourcesHub![nameSource];

            if (sourceValue < count)
            {
                sourceValue -= count;
                var deficit = Mathf.Abs(sourceValue);
                print($"Не хватает {deficit} {nameSource}");
            }
            else
            {
                sourceValue -= count;
                _sourcesHub[nameSource] = sourceValue;
                ActionUpdate(nameSource);
            }
            return sourceValue;
        }

        public int AddSource(string nameSource, int count)
        {
            _sourcesHub![nameSource] += count;
            ActionUpdate(nameSource);
            return _sourcesHub[nameSource];
        }

        
        [ContextMenu(nameof(Save))]
        public void Save()
        {
            var json = JsonConvert.SerializeObject(_sourcesHub);
            PlayerPrefs.SetString("sourcesKey", json);
        }

        
        [ContextMenu(nameof(Load))]
        public void Load()
        {
            var raw = PlayerPrefs.GetString("sourcesKey");
            _sourcesHub = string.IsNullOrWhiteSpace(raw)
                ? new Dictionary<string, int>()
                {
                    {"money", 100},
                    {"health" , 70},
                    {"hunger", 100},
                    {"condition", 50},
                    {"status", 1 },
                    {"day", 1 },
                    {"timeTODO", 11}
            
                }
                : JsonConvert.DeserializeObject<Dictionary<string, int>>(raw);
            
            
        }

        public void SourceUpdateALl()
        {
            foreach (var item in _sourcesHub!)
            {
                ActionUpdate(item.Key);
            }
        }

        [ContextMenu(nameof(ResetSources))]
        public void ResetSources()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}