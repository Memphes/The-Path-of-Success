using System;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace DYakubenko
{
    public class DataSource : MonoBehaviour, ISourceUpdate

    {
        [SerializeField] private int money = 0;
        
        [SerializeField] [Range(0, 100)] private int health = 100;
        [SerializeField] [Range(0, 100)] private int hunger = 0;
        [SerializeField] [Range(0, 100)] private int condition = 50;
        [SerializeField] [Range(0, 100)] private int status = 0;
        [SerializeField] [Range(0, 24)] private int timeTODO = 10;
        
        [SerializeField] private int day = 0;
        
        
        private const string KeyMoney = "moneyValue";
        private const string KeyHealth = "healthValue";
        private const string KeyHunger = "hungerValue";
        private const string KeyCondition = "conditionValue";
        private const string KeyStatus = "statusValue";
        private const string KeyDay = "dayValue";
        private const string KeyTimeTODO = "timeTODOValue";

        private void Awake()
        {
            money = PlayerPrefs.GetInt(KeyMoney, 0);
            health = PlayerPrefs.GetInt(KeyHealth, 100);
            hunger = PlayerPrefs.GetInt(KeyHunger, 0);
            condition = PlayerPrefs.GetInt(KeyCondition, 50);
            status = PlayerPrefs.GetInt(KeyStatus, 0);
            day = PlayerPrefs.GetInt(KeyDay, 0);
            timeTODO = PlayerPrefs.GetInt(KeyTimeTODO, 10);
        }


        public void SetDataSource()
        {
            PlayerPrefs.SetInt(KeyMoney, money);
            PlayerPrefs.SetInt(KeyHealth, health);
            PlayerPrefs.SetInt(KeyHunger, hunger);
            PlayerPrefs.SetInt(KeyCondition, condition);
            PlayerPrefs.SetInt(KeyStatus, status);
            PlayerPrefs.SetInt(KeyDay, day);
            PlayerPrefs.SetInt(KeyTimeTODO, timeTODO);
        }

        public void MoneyUpdate(int value)
        {
            money = value;
        }

        public void HealthUpdate(int value)
        {
            health = value;
        }

        public void HungerUpdate(int value)
        {
            hunger = value;
        }

        public void ConditionUpdate(int value)
        {
            condition = value;
        }

        public void StatusUpdate(int value)
        {
            status = value;
        }

        public void DayUpdate(int value)
        {
            day = value;
        }
        
        public void TimeTODOUpdate(int value)
        {
            timeTODO = value;
        }
    }
}