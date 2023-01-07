#nullable enable

using System;
using UnityEngine;
using UnityEngine.UI;

namespace DYakubenko.Scripts.UI
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField] private Button home = null!;
        [SerializeField] private Button training = null!;
        [SerializeField] private Button shop = null!;
        [SerializeField] private Button statistics = null!;
        [SerializeField] private Button settings = null!;
        


        private void Awake()
        {
            if (home == null || training == null || shop == null 
                || statistics == null || settings == null)
            {
                throw new NullReferenceException();
            }
        }

        private void Start()
        {
            home.onClick.AddListener(test);
            training.onClick.AddListener(test);
            shop.onClick.AddListener(test);
            statistics.onClick.AddListener(test);
            settings.onClick.AddListener(test);
        }

        void test()
        {
            print("test");
        }
        
    }
}