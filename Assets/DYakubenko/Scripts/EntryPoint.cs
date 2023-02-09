#nullable enable

using System;
using DYakubenko.Scripts.UI;
using UnityEngine;

namespace DYakubenko
{
    public class EntryPoint : MonoBehaviour
    {
         [SerializeField] private Sources _sources = null!;
         [SerializeField] private ButtonManager _buttonManager = null!;


        private void Awake()
        {
            if (_sources == null)
            {
                throw new NullReferenceException();
            }
        }

        private void Start()
        {
            var value =_sources.Test("money", 170);
            print(value);
        }
        
    }
}

