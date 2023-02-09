#nullable enable

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DYakubenko
{
    public class Sources : MonoBehaviour
    {
        private Dictionary<string, int> _sourcesHub  = new Dictionary<string, int>()
        {
            {"money", 100},
            {"health" , 100},
            {"hunger", 0},
            {"condition", 50},
            {"status", 1 },
            {"day", 0 },
            {"timeTODO", 0}
            
        };
        
        
        private Dictionary<string, int> _statistics  = new Dictionary<string, int>()
        {
            //TODO
        };

        public int Test (string nameSource, int count)
        {
            if (nameSource == null) throw new ArgumentNullException(nameof(nameSource));

           var sourceValue = _sourcesHub[nameSource];

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
            }
            return sourceValue;
        }

        public int TestAdd(string nameSource, int count)
        {
            _sourcesHub[nameSource] += count;
            return _sourcesHub[nameSource];
        }


    }
}