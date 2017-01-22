using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    bool paused = false;
    public Text MessageText;
    public GameObject PauseMenu;


    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void MainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void Pause()
    {
        if (paused)
        {
            if(PauseMenu.activeInHierarchy == true)
            {
                PauseMenu.SetActive(false);
            }
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
            MessageText.text = "En Pausa";
            PauseMenu.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().name.Equals("Main"))
        {
            Pause();
        }
    }

    public void Restart()
    {
        GameObject.Find("MessageText").GetComponent<Text>().text = "HAS MUERTO, LOS CAPITALISTAS TE LA SECARON";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
