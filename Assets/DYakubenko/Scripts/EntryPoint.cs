#nullable enable

using System;
using DYakubenko.Scripts.UI;
using UnityEngine;

namespace DYakubenko.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
         [SerializeField] private Sources sources = null!;
         [SerializeField] private ButtonManager buttonManager = null!;


        private void Awake()
        {
            if (sources == null)
            {
                throw new NullReferenceException();
            }
            
            if (buttonManager == null)
            {
                throw new NullReferenceException();
            }
        }

        private void Start()
        {
            sources.Load();
            var value =sources.GetSource("money", 170);
            print(value);
        }
        
    }
}

