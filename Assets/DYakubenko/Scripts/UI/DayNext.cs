#nullable enable

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DYakubenko.Scripts.UI
{
    public class DayNext : MonoBehaviour
    {
        [SerializeField] private Button nextDayButton = null!;



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
            print("test");
        }
    }
}