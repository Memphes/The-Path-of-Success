#nullable enable

using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace DYakubenko.Scripts.Source
{
    public class Possession : MonoBehaviour
    {
        private Dictionary<string, bool>? _possession = new Dictionary<string, bool>();

        public event Action<string, bool> PossessionUpdate = null!;


        public bool GetPossession(string namePossession)
        {
            return _possession![namePossession];
        }





        public void LoadPossession()
        {
            var raw = PlayerPrefs.GetString("PossessionKey");
            _possession = string.IsNullOrWhiteSpace(raw)
                ? new Dictionary<string, bool>()
                {
                    {"DrivingLicense", false},
                    {"TechnicalEducation" , true},
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
        
        public void PossessionRefreshALl()
        {
            foreach (var item in _possession!)
            {
                PossessionRefresh(item.Key);
            }
        }
        
        public void PossessionRefresh(string key)
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