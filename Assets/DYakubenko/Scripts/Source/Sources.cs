#nullable enable

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace DYakubenko.Scripts.Source
{
    public class Sources : MonoBehaviour
    {

        private Dictionary<string, int>? _sourcesHub = new Dictionary<string, int>();
        public event Action<string, int>? SourceUpdate;
        private int min = 0;
        private int max = 100;
        
        
        private void ActionUpdate(string nameSource)
        {
            SourceUpdate?.Invoke(nameSource, _sourcesHub![nameSource]);
        }

        public int CheckSource(string nameSource)
        {
            return _sourcesHub![nameSource];
        }

        public int GetSource (string nameSource, int count)
        {
            if (nameSource == null) throw new ArgumentNullException(nameof(nameSource));

           var sourceValue = _sourcesHub![nameSource];

            if (sourceValue < count)
            {
                if (nameSource is "Mood" or "Hunger")
                {
                    _sourcesHub![nameSource] -= sourceValue;
                    sourceValue -= count;
                    _sourcesHub["Health"] += sourceValue;
                    ActionUpdate("Health");
                }
                else
                {
                    sourceValue -= count;
                }
            }
            else
            {
                sourceValue -= count;
                _sourcesHub[nameSource] = sourceValue;
            }
            ActionUpdate(nameSource);
            return sourceValue;
        }

        public int AddSource(string nameSource, int count)
        {
            if (nameSource is "Health" or "Hunger" or "Mood")
            {
                _sourcesHub![nameSource] += Mathf.Clamp(count, min, max);
            }
            else
            {
                _sourcesHub![nameSource] += count;
            }
            ActionUpdate(nameSource);
            return _sourcesHub[nameSource];
        }

        
        [ContextMenu(nameof(Save))]
        public void Save()
        {
            var json = JsonConvert.SerializeObject(_sourcesHub);
            PlayerPrefs.SetString("sourcesKey", json);
            SourceUpdateALl();
        }

        
        [ContextMenu(nameof(Load))]
        public void Load()
        {
            var raw = PlayerPrefs.GetString("sourcesKey");
            _sourcesHub = string.IsNullOrWhiteSpace(raw)
                ? new Dictionary<string, int>()
                {
                    {"Money", 100},
                    {"Health" , 70},
                    {"Hunger", 100},
                    {"Mood", 50},
                    {"Status", 1 },
                    {"Month", 1 },
                    {"TimeTODO", 180},
                    {"ConstTimeTODO", 180}
                }
                : JsonConvert.DeserializeObject<Dictionary<string, int>>(raw);
            SourceUpdateALl();
        }
        
        public void TimeUpdate()
        {
            _sourcesHub!["TimeTODO"] = _sourcesHub["ConstTimeTODO"];
        }

        public void SourceUpdateALl()
        {
            foreach (var item in _sourcesHub!)
            {
                ActionUpdate(item.Key);
            }
        }

        [ContextMenu(nameof(ResetAllSources))]
        public void ResetAllSources()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}