using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{

    void Start()
    {
        Debug.Log("on");

    }

    void Update()
    {
    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("on");
        SceneManager.LoadScene("Battle");
    }
}
