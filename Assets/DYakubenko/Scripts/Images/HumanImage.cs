#nullable enable

using System;
using UnityEngine;
using UnityEngine.UI;

namespace DYakubenko.Scripts.Images
{
    public class HumanImage : MonoBehaviour
    {
        [SerializeField] private Image humanImage = null!;
        
        [Space]
        [SerializeField] private Sprite studentPrefab = null!;
        [SerializeField] private Sprite workerPrefab = null!;
        [SerializeField] private Sprite entrepreneurPrefab = null!;
        [SerializeField] private Sprite businessmanPrefab = null!;
        [SerializeField] private Sprite veryCoolPrefab = null!;
        [SerializeField] private Sprite bumPrefab = null!;
        


        private void Awake()
        {
            if (studentPrefab == null 
                || workerPrefab == null 
                || entrepreneurPrefab == null 
                || businessmanPrefab == null 
                || bumPrefab == null
                || veryCoolPrefab == null
               )
            {
                throw new NullReferenceException();
            }
            
            humanImage = GetComponent<Image>();
        }
        
        public void ChangeHumanImage(int value)
        {
            switch (value)
            { 
                case 0 :
                    humanImage.sprite = bumPrefab;
                    break;
                case 1 :
                    humanImage.sprite = studentPrefab;
                    break;
                case 2 :
                    humanImage.sprite = workerPrefab;
                    break;
                case 3 :
                    humanImage.sprite = entrepreneurPrefab;
                    break;
                case 4 :
                    humanImage.sprite = businessmanPrefab;
                    break;
                case 5 :
                    humanImage.sprite = veryCoolPrefab;
                    break;
            }
        }
    }
}