#nullable enable

using System;
using DYakubenko.Scripts.Conditions;
using DYakubenko.Scripts.Source;
using DYakubenko.Scripts.UI;
using UnityEngine;

namespace DYakubenko.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
         [SerializeField] private Sources sources = null!;
         [SerializeField] private Possession possession = null!;
         
         [Space]
         [SerializeField] private ButtonManager buttonManager = null!;
         [SerializeField] private MonthCounter monthCounter = null!;
         [SerializeField] private StatisticView statisticView = null!;
         
         [Space]
         [SerializeField] private HealthCondition healthCondition = null!;
         [SerializeField] private HungerCondition hungerCondition = null!;
         [SerializeField] private MoodCondition moodCondition = null!;

         private void Awake()
        {
            if (sources == null 
                || buttonManager == null 
                || monthCounter == null 
                || statisticView == null
                || healthCondition == null
                || hungerCondition == null
                || possession == null
                )
            {
                throw new NullReferenceException();
            }
            
        }

        private void Start()
        {
            sources.Load();
            possession.LoadPossession();
            possession.PossessionRefreshALl();
        }

        public void MonthNext()
        {
            sources.TimeUpdate();
            sources.AddSource("Month", 1);

            
            sources.Save();
            possession.SavePossession();
        }

        private void OnEnable()
        {
            monthCounter.MonthUpdated += MonthNext;
            sources.SourceUpdate += statisticView.UpdateSource;
        }

        private void OnDestroy()
        {
            monthCounter.MonthUpdated -= MonthNext;
            sources.SourceUpdate -= statisticView.UpdateSource;
        }
    }
}

