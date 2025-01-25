using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject settingsPanel;
    

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        
    }

    public void showOptions()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

   
}
