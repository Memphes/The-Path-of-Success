using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYakubenko
{
    public class EntryPoint : MonoBehaviour
    {
        private DataSource dataSource;


        private void NextDay()
        {
            dataSource.SetDataSource();
        }
    }
}

