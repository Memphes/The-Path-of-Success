#nullable enable

using System;
using DYakubenko.Scripts.Images;
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
         [SerializeField] private MonthCounter monthCounter = null!;
         [SerializeField] private StatisticView statisticView = null!;
         
         [Space] 
         [SerializeField] private HumanImage humanImage = null!;
         [SerializeField] private BackGroundImage backGroundImage = null!;

         private void Awake()
        {
            if (sources == null
                || monthCounter == null 
                || statisticView == null
                || possession == null
                || humanImage == null
                || backGroundImage == null
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
            var currentStatus = sources.CheckSource("Status");
            humanImage.ChangeHumanImage(currentStatus);
            backGroundImage.ChangeBackgroundImage(currentStatus);
            
        }

        private void MonthNext()
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

