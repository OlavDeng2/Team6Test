using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    private Panel[] menuPanels;

	// Use this for initialization
	void Awake () {
        menuPanels = GetComponentsInChildren<Panel>(true);
	}

    public void StartGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
	
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenPanel(Panel panelToOpen)
    {
        foreach(Panel panel in menuPanels)
        {
            panel.gameObject.SetActive(false);
        }

        panelToOpen.gameObject.SetActive(true);
    }
}
