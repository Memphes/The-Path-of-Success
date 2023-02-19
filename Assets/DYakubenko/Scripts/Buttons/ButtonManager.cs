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
        [SerializeField] private Button activity = null!;
        [SerializeField] private Button settings = null!;

        [Space]
        [SerializeField] private GameObject trainingObj = null!;
        [SerializeField] private GameObject shopObj = null!;
        [SerializeField] private GameObject activityObj = null!;
        [SerializeField] private GameObject settingsObj = null!;

        [Space]
        [SerializeField] private Button healthShopButtons = null!;
        [SerializeField] private Button hungerShopButtons = null!;
        [SerializeField] private Button moodShopButtons = null!;
        [SerializeField] private Button realtyShopButtons = null!;
        [SerializeField] private Button carShopButtons = null!;
        [SerializeField] private Button moreShopButtons = null!;
        
        
        [Space]
        [SerializeField] private GameObject healthShopObj = null!;
        [SerializeField] private GameObject hungerShopObj = null!;
        [SerializeField] private GameObject moodShopObj = null!;
        [SerializeField] private GameObject realtyShopObj = null!;
        [SerializeField] private GameObject carShopObj = null!;
        [SerializeField] private GameObject moreShopObj = null!;
        

        private void Awake()
        {
            if (home == null 
                || training == null 
                || shop == null 
                || activity == null 
                || settings == null
                || healthShopButtons == null
                || hungerShopButtons == null
                || moodShopButtons == null
                || realtyShopButtons == null
                || carShopButtons == null
                || moreShopButtons == null
                )
            {
                throw new NullReferenceException();
            }
            
            if (trainingObj == null 
                || shopObj == null 
                || activityObj == null 
                || settingsObj == null
                || healthShopObj == null
                || hungerShopObj == null
                || moodShopObj == null
                || realtyShopObj == null
                || carShopObj == null
                || moreShopObj == null
                )
            {
                throw new NullReferenceException();
            }
            
        }

        private void Start()
        {
            home.onClick.AddListener(CloseAllObj);
            training.onClick.AddListener(OpenTraning);
            shop.onClick.AddListener(OpenShop);
            activity.onClick.AddListener(OpenActivitys);
            settings.onClick.AddListener(OpenSetting);
            
            healthShopButtons.onClick.AddListener(OpenHealthShop);
            hungerShopButtons.onClick.AddListener(OpenHungerShop);
            moodShopButtons.onClick.AddListener(OpenMoodShop);
            realtyShopButtons.onClick.AddListener(OpenRealtyShop);
            carShopButtons.onClick.AddListener(OpenCarShop);
            moreShopButtons.onClick.AddListener(OpenMoreShop);
        }

        private void OpenHealthShop()
        {
            shopObj.SetActive(false);
            healthShopObj.SetActive(true);
        }
        
        private void OpenHungerShop()
        {
            shopObj.SetActive(false);
            hungerShopObj.SetActive(true);
        }
        
        private void OpenMoodShop()
        {
            shopObj.SetActive(false);
            moodShopObj.SetActive(true);
        }
        
        private void OpenRealtyShop()
        {
            shopObj.SetActive(false);
            realtyShopObj.SetActive(true);
        }
        
        private void OpenCarShop()
        {
            shopObj.SetActive(false);
            carShopObj.SetActive(true);
        }
        
        private void OpenMoreShop()
        {
            shopObj.SetActive(false);
            moreShopObj.SetActive(true);
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
        
        private void OpenActivitys()
        {
            CloseAllObj();
            activityObj.SetActive(true);
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
            activityObj.SetActive(false);
            settingsObj.SetActive(false);
            
            healthShopObj.SetActive(false);
            hungerShopObj.SetActive(false);
            moodShopObj.SetActive(false);
            realtyShopObj.SetActive(false);
            carShopObj.SetActive(false);
            moreShopObj.SetActive(false);
        }
    }
}