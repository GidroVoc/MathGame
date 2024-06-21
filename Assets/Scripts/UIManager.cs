using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject magnifier;

    public void WinScreen()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void MagnifierOpen()
    {
        magnifier.SetActive(true);
        Time.timeScale = 0f;
    } 
    
    public void MagnifierClose()
    {
        magnifier.SetActive(false);
        Time.timeScale = 0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
