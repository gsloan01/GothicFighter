using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    public SceneMaster sceneMaster;
    bool paused = true;
    public void OnPause()
    {
        paused = !paused;
        if(paused)
        {
            OnResume();
        }
        else
        {
            Time.timeScale = 0.001f;
            panel.SetActive(true);
        }
        

    }
    public void OnResume()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
    public void OnMainMenu()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        sceneMaster.LoadScene("MainMenu");
    }

}
