#nullable enable

using System;
using System.Net.Sockets;
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
        [SerializeField] private Possession.ChoicePossession possessionValue;
        private const int HugerValue = 4;
        private const int MoodValue = 6;


        private void Awake()
        {
            if (source == null 
                || timeText == null 
                || moneyText == null)
            {
                throw new NullReferenceException();
            }
        }

        private void Start()
        {
            thisButton = GetComponent<Button>();
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

        private void CheckPossession()
        {
            
        }

    }

}
    