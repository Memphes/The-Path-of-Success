﻿using UniRx;

namespace DYakubenko
{
    public interface ISource
    {
        public void MoneyUpdate(int value);
        
        public void HealthUpdate(int value);
        
        public void HungerUpdate(int value);
        
        public void ConditionUpdate(int value);
        
        public void StatusUpdate(int value);
        
        public void DayUpdate(int value);
    }
}