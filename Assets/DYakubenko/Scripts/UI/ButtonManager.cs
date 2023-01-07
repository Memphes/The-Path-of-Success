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
        
        [Space]
        [SerializeField] private GameObject trainingObj = null!;
        [SerializeField] private GameObject shopObj = null!;
        [SerializeField] private GameObject statisticsObj = null!;
        [SerializeField] private GameObject settingsObj = null!;
        


        private void Awake()
        {
            if (home == null || training == null || shop == null 
                || statistics == null || settings == null)
            {
                throw new NullReferenceException();
            }
            
            if (trainingObj == null || shopObj == null 
                || statisticsObj == null || settingsObj == null)
            {
                throw new NullReferenceException();
            }
        }

        private void Start()
        {
            home.onClick.AddListener(CloseAllObj);
            training.onClick.AddListener(OpenTraning);
            shop.onClick.AddListener(OpenShop);
            statistics.onClick.AddListener(OpenStatistics);
            settings.onClick.AddListener(OpenSetting);
        }

        private void OpenTraning()
        {
            CloseAllObj();
            trainingObj.SetActive(true);
        }
        
        private void OpenShop()
        {
            CloseAllObj();
            shopObj.SetActive(true);
        }
        
        private void OpenStatistics()
        {
            CloseAllObj();
            statisticsObj.SetActive(true);
        }
        
        private void OpenSetting()
        {
            CloseAllObj();
            settingsObj.SetActive(true);
        }

        private void CloseAllObj()
        {
            trainingObj.SetActive(false);
            shopObj.SetActive(false);
            statisticsObj.SetActive(false);
            settingsObj.SetActive(false);
        }
    }
}