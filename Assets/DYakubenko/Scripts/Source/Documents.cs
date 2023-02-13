#nullable enable

using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace DYakubenko.Scripts.Source
{
    public class Documents : MonoBehaviour
    {
        private Dictionary<string, bool>? _documentsHub = new Dictionary<string, bool>();

        public event Action<string, bool> DocumentsUpdate;
    
        
        public void LoadDocuments()
        {
            var raw = PlayerPrefs.GetString("sourcesKey");
            _documentsHub = string.IsNullOrWhiteSpace(raw)
                ? new Dictionary<string, bool>()
                {
                    {"Водительское удостоверение", false},
                    {"Техническое образование" , false},
                    {"Высшее образование", false},
                    {"Mood", false},
                }
                : JsonConvert.DeserializeObject<Dictionary<string, bool>>(raw);
        }
        
        
        public void SaveDocuments()
        {
            var json = JsonConvert.SerializeObject(_documentsHub);
            PlayerPrefs.SetString("documentsKey", json);
        }
    }
}