using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    enum GameState
    {
      Playing,
      Paused,
      GameOver,
      AtTitle
    }

    public Image pausedOverlay;
    public Text pausedText;

    private PlayerHealth playerHealth;
    private Transform playerTf;
    private Rigidbody playerRb;

    //private MapCreationScript mapCreationScript;


    private GameObject playingCanvas;
    private GameObject pausedCanvas;
    private GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      GameState gs = GameState.AtTitle;
      switch (gs)
      {
        case GameState.Playing:
            if (playerHealth.health <= 0)
            {
              gs = GameState.GameOver;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
              gs = GameState.Paused;
              pausedCanvas.SetActive(true);
            }
            break;
        //=======================================================================//
        case GameState.Paused:
            //Pauseer game/zet tijd stil
            Time.timeScale = 0;

            //Zet speler stil
            playerRb.constraints = RigidbodyConstraints.FreezeAll;

            if (Input.GetKeyDown(KeyCode.R))
            {
              pausedCanvas.SetActive(false);
              Time.timeScale = 1;
              playerRb.constraints = RigidbodyConstraints.None;

              gs = GameState.Playing;
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
              //Naar title screen
              playerRb.constraints = RigidbodyConstraints.None;

              gs = GameState.AtTitle;
            }
            break;
        //=======================================================================//
        case GameState.GameOver:
            if (Input.GetKeyDown(KeyCode.R))
            {
              //Weer playen
              //playerTf.position = mapCreationScript.RespawnPos;


              gs = GameState.Playing;
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {

              gs = GameState.AtTitle;
            }
            break;
        //=======================================================================//
        case GameState.AtTitle:

              break;
      }
    }
}
