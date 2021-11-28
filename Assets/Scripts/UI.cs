using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject _UI;

    void Start()
    {
        _UI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _UI.SetActive(true);
        }   
    }

    public void Quit()
    {
        Application.Quit();
    }
}
