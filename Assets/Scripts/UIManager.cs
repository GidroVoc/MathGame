using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject deadScreen;
    [SerializeField] private GameObject magnifier;
    [SerializeField] private GameObject magnifierButOpen;
    [SerializeField] private GameObject magnifierButClose;

    public void WinScreen()
    {
        winScreen.SetActive(true);
        //Time.timeScale = 0f;
    }
    
    public void DeadScreen()
    {
        winScreen.SetActive(false);
        deadScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MagnifierOpen()
    {
        magnifier.SetActive(true);
        magnifierButOpen.SetActive(false);
        magnifierButClose.SetActive(true);
    } 
    
    public void MagnifierClose()
    {
        magnifier.SetActive(false);
        magnifierButOpen.SetActive(true);
        magnifierButClose.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
