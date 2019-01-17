using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace EnemyBehaviour
{
    public class DetachObject : MonoBehaviour
    {
        public GameObject Detach;
        public GameObject Base;
        public CommandText TextCommands;

        public void UpdateDamage()
        {
            Detach.transform.DOMoveY(Detach.transform.position.y + 0.1f, 1, false);
        }
        
    }
}