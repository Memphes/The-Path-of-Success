#nullable enable

using System;
using DYakubenko.Scripts.Source;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DYakubenko.Scripts.Buttons
{
    public class SuperActivityButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText = null!;
        [SerializeField] private TextMeshProUGUI moneyText = null!;
        [SerializeField] private TextMeshProUGUI conditionText = null!;
        [SerializeField] private TextMeshProUGUI blockText = null!;
        
        [Space] 
        [SerializeField] private Possession.ChoicePossession possessionValue;
        
        [Space]
        [SerializeField] private Button thisButton = null!;
        [SerializeField] private Possession possession = null!;

        [Space] 
        [SerializeField] private int getMoneySource;
        [SerializeField] private int getTimeTodoSource;

        [Space]
        [SerializeField] private ButtonsSource takeSource;
        [SerializeField] private int takeSourceCount;
        
        [Space]
        [SerializeField] private Sources source = null!;
        [SerializeField] private GameObject blockObj = null!;
        
        private const int HugerValue = 4;
        private const int MoodValue = 6;
        

        private void Awake()
        {
            if (source == null
                || possession == null
                || timeText == null
                || moneyText == null
                || conditionText == null
                || blockText == null
                )
            {
                throw new NullReferenceException();
            }
            thisButton = GetComponent<Button>();
        }

        private void Start()
        {
            thisButton.onClick.AddListener(Check);
            timeText.text = $"-{getTimeTodoSource.ToString()}";
            moneyText.text = $"-{getMoneySource.ToString()}";
            conditionText.text = $"+{takeSourceCount.ToString()}";
        }

        private void Check()
        {
            var money = source.CheckSource("Money");
            var timeTodo = source.CheckSource("TimeTODO");
            if (getMoneySource <= money && getTimeTodoSource <= timeTodo)
            {
                source.GetSource("Money", getMoneySource);
                source.GetSource("TimeTODO", getTimeTodoSource);
                RefreshAllSource();
            }
            
        }

        private void RefreshAllSource()
        {
            switch (takeSource.ToString())
                {
                    case "Health" :
                        source.GetSource("Mood", MoodValue);
                        source.GetSource("Hunger", HugerValue);
                        break;
                    case "Hunger" :
                        source.GetSource("Mood", MoodValue);
                        break;
                    case "Mood" :
                        source.GetSource("Hunger", HugerValue);
                        break;
                }
                source.AddSource(takeSource.ToString(), takeSourceCount);
        }


        private void CheckByBlock(string namePossession, bool value)
        {
            var poss = possessionValue.ToString();
            switch (poss)
            {
                case "None":
                    UnBlockButton();
                    break;
                default:
                    if (namePossession == poss)
                    {
                        if (value is false)
                        {
                            BlockButton(poss);
                        }
                        else
                        {
                            UnBlockButton();
                        }
                    }
                    break;
            }
        }

        private void BlockButton(string name)
        {
            blockObj.SetActive(true);
            thisButton.interactable = false;
            blockText.text = name switch
            {
                "DrivingLicense" => "Нужно водительское удостоверение",
                "TechnicalEducation" => "Нужно техническое образование",
                "HigherEducation" => "Нужно высшее образование",
                "Car" => "Нужна машина",
                "House" => "Нужен дом",
                "Business" => "Нужен бизнес",
                _ => blockText.text
            };
        }

        private void UnBlockButton()
        {
            blockObj.SetActive(false);
            thisButton.interactable = true;
        }

       private void OnEnable()
       {
           var namePoss = possessionValue.ToString();
           var value = possession.CheckPossession(namePoss);
           CheckByBlock(namePoss, value); 
       }

       
        private enum ButtonsSource
        {
            Health,
            Hunger,
            Mood
        }
    }
}