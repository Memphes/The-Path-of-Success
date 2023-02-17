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
        [SerializeField] private Button thisButton = null!;
        [SerializeField] private Possession possession = null!;

        [Space] 
        [SerializeField] private int getMoneySource;
        [SerializeField] private int getTimeTodoSource;

        [Space]
        [SerializeField] private ButtonsSource[] takeSource = null!;
        [SerializeField] private int[] takeSourceCount = null!;
        
        [Space]
        [SerializeField] private Sources source = null!;
        [SerializeField] private GameObject blockObj = null!;
        
        [Space] 
        [SerializeField] private Possession.ChoicePossession possessionValue;


        private const int HugerValue = 5;
        private const int MoodValue = 7;


        private void Awake()
        {
            if (source == null
                || possession == null
                )
            {
                throw new NullReferenceException();
            }
        }

        private void Start()
        {
            thisButton = GetComponent<Button>();
            thisButton.onClick.AddListener(Check);
        }

        private void Check()
        {
            var money = source.CheckSource("Money");
            var timeTodo = source.CheckSource("TimeTODO");
            if (getMoneySource < money && getTimeTodoSource < timeTodo)
            {
                source.GetSource("Money", getMoneySource);
                source.GetSource("TimeTODO", getTimeTodoSource);
                RefreshAllSource();
            }
            
        }

        private void RefreshAllSource()
        {
            for (int i = 0; i < takeSource.Length; i++)
            {
                switch (takeSource[i].ToString())
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
                source.AddSource(takeSource[i].ToString(), takeSourceCount[i]);
            }
        }


        private void CheckByBlock(string namePossession, bool value)
        {
            var poss = possessionValue.ToString();
            switch (poss)
            {
                case "None":
                    print("None possession");
                    UnBlockButton();
                    break;
                default:
                    if (namePossession == poss)
                    {
                        if (value is false)
                        {
                            BlockButton();
                        }
                        else
                        {
                            UnBlockButton();
                        }
                    }
                    break;
            }
        }

        private void BlockButton()
        {
            blockObj.SetActive(true);
            thisButton.interactable = false;
        }

        private void UnBlockButton()
        {
            blockObj.SetActive(false);
            thisButton.interactable = true;
        }

        private void OnEnable()
        {
            possession.PossessionUpdate += CheckByBlock;
        }

        private void OnDisable()
        {
            possession.PossessionUpdate -= CheckByBlock;
        }

        private enum ButtonsSource
        {
            Health,
            Hunger,
            Mood
        }
    }
}