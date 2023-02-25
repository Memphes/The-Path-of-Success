#nullable enable

using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DYakubenko.Scripts.Source
{
    public class Possession : MonoBehaviour
    {
        private Dictionary<string, bool>? _possession = new Dictionary<string, bool>();

        public event Action<string, bool> PossessionUpdate = null!;

        public bool CheckPossession(string namePossession)
        {
            return _possession![namePossession];
        }
        
        public void ChangePossession(string namePossession, bool value)
        {
            _possession![name] = value;
            PossessionRefresh(namePossession);
        }



        public void LoadPossession()
        {
            var raw = PlayerPrefs.GetString("PossessionKey");
            _possession = string.IsNullOrWhiteSpace(raw)
                ? new Dictionary<string, bool>()
                {   
                    {"None" , true},
                    {"DrivingLicense", false},
                    {"TechnicalEducation" , false},
                    {"HigherEducation", false},
                    
                    {"Car", false},
                    {"House", false},
                    {"Business", false},
                }
                : JsonConvert.DeserializeObject<Dictionary<string, bool>>(raw);
        }
        
        
        public void SavePossession()
        {
            var json = JsonConvert.SerializeObject(_possession);
            PlayerPrefs.SetString("PossessionKey", json);
        }
        
        [ContextMenu(nameof(PossessionRefreshALl))]
        public void PossessionRefreshALl()
        {
            foreach (var item in _possession!)
            {
                PossessionRefresh(item.Key);
            }
        }
        
        private void PossessionRefresh(string key)
        {
            PossessionUpdate?.Invoke(key, _possession![key]);
        }
        
        
        public enum ChoicePossession
        {
            None,
            DrivingLicense,
            TechnicalEducation,
            HigherEducation,
            Car,
            House,
            Business
        }
    }
}