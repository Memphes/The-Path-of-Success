#nullable enable

using System;
using DYakubenko.Scripts.Buttons;
using DYakubenko.Scripts.Conditions;
using DYakubenko.Scripts.Source;
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
         
         [Space]
         [SerializeField] private HealthCondition healthCondition = null!;
         [SerializeField] private HungerCondition hungerCondition = null!;
         [SerializeField] private MoodCondition moodCondition = null!;

         private void Awake()
        {
            if (sources == null 
                || buttonManager == null 
                || dayCounter == null 
                || statisticView == null
                || healthCondition == null
                || hungerCondition == null
                || moodCondition == null)
            {
                throw new NullReferenceException();
            }
            
        }

        private void Start()
        {
            sources.Load();
        }

        public void DayNext()
        {
            sources.TimeUpdate();
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
            sources.SourceUpdate -= statisticView.UpdateSource;
        }
    }
}

