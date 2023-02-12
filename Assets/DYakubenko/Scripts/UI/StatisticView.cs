#nullable enable

using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SubsystemsImplementation;

namespace DYakubenko.Scripts.UI
{
    public class StatisticView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyUI = null!;
        [SerializeField] private Slider healthUI = null!;
        [SerializeField] private Slider hungerUI = null!;
        [SerializeField] private Slider conditionUI = null!;
        [SerializeField] private TextMeshProUGUI statusUI = null!;
        [SerializeField] private TextMeshProUGUI dayUI = null!;
        [SerializeField] private TextMeshProUGUI timeTodoUI = null!;


        private void Awake()
        {
            if (moneyUI == null 
                || healthUI == null 
                || hungerUI == null 
                || conditionUI == null 
                || statusUI == null
                || dayUI == null
                || timeTodoUI == null)
            {
                throw new NullReferenceException();
            }
        }

        private void Start()
        {
            healthUI.maxValue = 100;
            hungerUI.maxValue = 100;
            conditionUI.maxValue = 100;
        }

        public void UpdateSource(string nameSource, int value)
        {
            switch (nameSource)
            {
                case "money" :
                    moneyUI.text = value.ToString();
                    break;
                case "health" :
                    healthUI.value = value;
                    break;
                case "hunger" :
                    hungerUI.value = value;
                    break;
                case "condition" :
                    conditionUI.value = value;
                    break;
                case "status" :
                    switch (value)
                    {
                        case 0 :
                            statusUI.text = "Бомж";
                            break;
                       case 1 :
                           statusUI.text = "Работник";
                           break;
                       case 2 :
                           statusUI.text = "Предприниматель";
                           break;
                       case 3 :
                           statusUI.text = "Глава компании";
                           break;
                       case 4 :
                           statusUI.text = "Бизнесмен";
                           break;
                       case 5 :
                           statusUI.text = "Очень крут";
                           break;
                    }
                    break;
                case "day" :
                    dayUI.text = value.ToString();
                    break;
                case "timeTODO" :
                    timeTodoUI.text = value.ToString();
                    break;
            }
        }
    }
}