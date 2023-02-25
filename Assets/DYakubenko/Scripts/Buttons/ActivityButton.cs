#nullable enable

using System;
using DYakubenko.Scripts.Source;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DYakubenko.Scripts.Buttons
{
    public class ActivityButton : MonoBehaviour
    {
        [SerializeField] private Button thisButton = null!;

        [Space] 
        [SerializeField] private int timeCount;
        [SerializeField] private int moneyCount;

        [Space]
        [SerializeField] private Sources source = null!;
        [SerializeField] private TextMeshProUGUI timeText = null!;
        [SerializeField] private TextMeshProUGUI moneyText = null!;
        
        [Space]
        [SerializeField] private Possession possession = null!;
        [SerializeField] private GameObject blockObj = null!;
        [SerializeField] private TextMeshProUGUI blockText = null!;

        [Space] 
        [SerializeField] private Possession.ChoicePossession possessionValue;
        private const int HugerValue = 4;
        private const int MoodValue = 6;


        private void Awake()
        {
            if (source == null 
                || timeText == null 
                || moneyText == null
                || possession == null
                || blockObj == null
                || blockText == null
                )
            {
                throw new NullReferenceException();
            }
            thisButton = GetComponent<Button>();
        }

        private void Start()
        {
            thisButton.onClick.AddListener(CheckToDo);

            timeText.text = $"-{timeCount.ToString()}";
            moneyText.text = $"+{moneyCount.ToString()}";

        }

        private void CheckToDo()
        {
            var result = source.GetSource("TimeTODO", timeCount);
            if (result >= 0)
            {
                source.AddSource("Money", moneyCount);
                source.GetSource("Mood", MoodValue);
                source.GetSource("Hunger", HugerValue);
            }
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

        private void BlockButton(string namePoss)
        {
            blockObj.SetActive(true);
            thisButton.interactable = false;
            blockText.text = namePoss switch
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

    }

}
    