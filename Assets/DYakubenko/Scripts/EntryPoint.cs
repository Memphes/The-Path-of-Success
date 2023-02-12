#nullable enable

using System;
using DYakubenko.Scripts.Buttons;
using DYakubenko.Scripts.UI;
using UnityEngine;

namespace DYakubenko.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
         [SerializeField] private Sources sources = null!;
         [SerializeField] private ButtonManager buttonManager = null!;
         [SerializeField] private DayCounter dayCounter = null!;
         [SerializeField] private StatisticView statisticView = null!;

         private void Awake()
        {
            if (sources == null 
                || buttonManager == null 
                || dayCounter == null 
                || statisticView == null)
            {
                throw new NullReferenceException();
            }
            
        }

        private void Start()
        {
            sources.Load();
            sources.SourceUpdateALl();
            
        }

        public void DayNext()
        {
            sources.AddSource("day", 1);
            
            
            
            sources.Save();
        }

        private void OnEnable()
        {
            dayCounter.DayUpdated += DayNext;
            sources.SourceUpdate += statisticView.UpdateSource;
        }

        private void OnDestroy()
        {
            dayCounter.DayUpdated -= DayNext;
        }
    }
}

