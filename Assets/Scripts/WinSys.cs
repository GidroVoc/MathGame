using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSys : MonoBehaviour
{
    public GameObject lastMonster;
    private UIManager uiManager;
    private HealthSystem healthSystem;

    // Update is called once per frame
    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        healthSystem = FindObjectOfType<HealthSystem>();
    }

    void Update()
    {
        if (lastMonster == null && healthSystem.alive)
            uiManager.WinScreen();
    }
}