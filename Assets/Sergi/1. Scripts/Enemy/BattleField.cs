using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EnemyBehaviour
{
    [System.Serializable]
    public class BattleField : MonoBehaviour
    {

    }

    [System.Serializable]
    public class PlayerController
    {
        [SerializeField]
        private Controller controller;
        [Range(1, 10)]
        public int MoveSpeed = 1;
        public GameObject VisualContainer;
        public GameObject container;

        public void Init()
        {
            container = MonoBehaviour.Instantiate(VisualContainer, null) as GameObject;
        }
        public void MoveKeyboard()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            container.transform.position += move * MoveSpeed * Time.deltaTime;
        }


        enum Controller
        {
            MOUSE,
            KEYBOARD,
            CONTROLLER
        }
    }
}
