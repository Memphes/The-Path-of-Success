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
        [SerializeField] private Slider moodUI = null!;
        [SerializeField] private TextMeshProUGUI statusUI = null!;
        [SerializeField] private TextMeshProUGUI monthUI = null!;
        [SerializeField] private TextMeshProUGUI timeTodoUI = null!;


        private void Awake()
        {
            if (moneyUI == null 
                || healthUI == null 
                || hungerUI == null 
                || moodUI == null 
                || statusUI == null
                || monthUI == null
                || timeTodoUI == null
                )
            {
                throw new NullReferenceException();
            }
        }

        private void Start()
        {
            healthUI.maxValue = 100;
            hungerUI.maxValue = 100;
            moodUI.maxValue = 100;
        }

        public void UpdateSource(string nameSource, int value)
        {
            switch (nameSource)
            {
                case "Money" :
                    moneyUI.text = value.ToString();
                    break;
                case "Health" :
                    healthUI.value = value;
                    break;
                case "Hunger" :
                    hungerUI.value = value;
                    break;
                case "Mood" :
                    moodUI.value = value;
                    break;
                case "Status" :
                    switch (value)
                    { 
                        case 0 :
                            statusUI.text = "Бомж";
                            break;
                       case 1 :
                           statusUI.text = "Студент";
                           break;
                       case 2 :
                           statusUI.text = "Работник";
                           break;
                       case 3 :
                           statusUI.text = "Предприниматель";
                           break;
                       case 4 :
                           statusUI.text = "Бизнесмен";
                           break;
                       case 5 :
                           statusUI.text = "Очень крут";
                           break;
                    }
                    break;
                case "Month" :
                    monthUI.text = value.ToString();
                    break;
                case "TimeTODO" :
                    timeTodoUI.text = value.ToString();
                    break;
            }
        }
    }
}