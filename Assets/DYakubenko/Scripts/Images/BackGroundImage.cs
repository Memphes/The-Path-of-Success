using System;
using UnityEngine;
using UnityEngine.UI;

namespace DYakubenko.Scripts.Images
{
    public class BackGroundImage : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage = null!;
        
        [Space]
        [SerializeField] private Sprite homePrefab = null!;
        [SerializeField] private Sprite workPrefab = null!;
        [SerializeField] private Sprite shopPrefab = null!;
        [SerializeField] private Sprite officePrefab = null!;
        [SerializeField] private Sprite mansionPrefab = null!;
        [SerializeField] private Sprite streetPrefab = null!;
        


        private void Awake()
        {
            if (homePrefab == null 
                || workPrefab == null 
                || shopPrefab == null 
                || officePrefab == null 
                || mansionPrefab == null
                || streetPrefab == null
               )
            {
                throw new NullReferenceException();
            }
            
            backgroundImage = GetComponent<Image>();
        }
        
        public void ChangeBackgroundImage(int value)
        {
            switch (value)
            { 
                case 0 :
                    backgroundImage.sprite = streetPrefab;
                    break;
                case 1 :
                    backgroundImage.sprite = homePrefab;
                    break;
                case 2 :
                    backgroundImage.sprite = workPrefab;
                    break;
                case 3 :
                    backgroundImage.sprite = shopPrefab;
                    break;
                case 4 :
                    backgroundImage.sprite = officePrefab;
                    break;
                case 5 :
                    backgroundImage.sprite = streetPrefab;
                    break;
            }
        }
    }
}