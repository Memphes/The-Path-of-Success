#nullable enable

using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DYakubenko.Scripts.UI
{
    public class MonthCounter : MonoBehaviour
    {
        [SerializeField] private Button nextMonthButton;

        public MonthCounter(Button nextMonthButton)
        {
            this.nextMonthButton = nextMonthButton;
        }

        public event Action? MonthUpdated;

        private void Awake()
        {
            if (nextMonthButton == null)
            {
                throw new NullReferenceException();
            }
        }

        private void Start()
        {
            nextMonthButton.onClick.AddListener(NextMonth);
        }

        private void NextMonth()
        {
            print("Next Month");
            MonthUpdated ?.Invoke();
        }
    }
}