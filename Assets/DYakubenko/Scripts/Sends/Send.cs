#nullable enable

using System;
using UnityEngine;
using TMPro;

namespace DYakubenko.Scripts.Sends
{
    public class Send : MonoBehaviour, IViewSend
    {
        [SerializeField] private TextMeshProUGUI text = null!;


        private void Awake()
        {
            if (text == null)
            {
                throw new NullReferenceException();
            }
        }

        public void ViewSend(string sendText)
        {
            throw new System.NotImplementedException();
        }
    }
}