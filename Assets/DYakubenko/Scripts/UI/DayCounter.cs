#nullable enable

using System;
using UnityEngine;
using UnityEngine.UI;

namespace DYakubenko.Scripts.UI
{
    public class DayCounter : MonoBehaviour
    {
        [SerializeField] private Button nextDayButton;

        public DayCounter(Button nextDayButton)
        {
            this.nextDayButton = nextDayButton;
        }

        public event Action? DayUpdated;

        private void Awake()
        {
            if (nextDayButton == null)
            {
                throw new NullReferenceException();
            }
        }

        private void Start()
        {
            nextDayButton.onClick.AddListener(NextDay);
        }

        private void NextDay()
        {
            print("Next Day");
            DayUpdated ?.Invoke();
        }
    }
}