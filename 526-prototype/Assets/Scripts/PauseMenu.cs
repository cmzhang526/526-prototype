using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject player;

    public static bool IsGamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused) Resume();
            else Pause();
            IsGamePaused = !IsGamePaused;
        }
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeBtnPressed()
    {
        Debug.Log("=====resume btn test=====");
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void ResetLevel()
    {
        // TODO: think about if we need this
        Debug.Log("=====respawn btn test=====");
        player.GetComponent<PlayerController>().Respawn();
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void BackToMain()
    {
        Debug.Log("=====back btn test=====");
        IsGamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
