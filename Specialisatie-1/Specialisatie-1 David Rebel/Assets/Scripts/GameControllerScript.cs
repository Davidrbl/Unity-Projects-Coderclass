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

    private GameState gs;

    private PlayerHealth playerHealth;
    private Transform playerTf;
    private Rigidbody playerRb;

    //private MapCreationScript mapCreationScript;


    public GameObject playingCanvas;
    public GameObject pausedCanvas;
    public GameObject gameOverCanvas;


    // Start is called before the first frame update
    void Start()
    {
      playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
      playerTf = GameObject.Find("Player").GetComponent<Transform>();
      playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
      gs = GameState.Playing;
      Debug.Log(playerHealth);
      //playingCanvas = GameObject.Find("PlayingCanvas");
      //pausedCanvas = GameObject.Find("PausedCanvas");
      //gameOverCanvas = GameObject.Find("GameOverCanvas");
    }

    // Update is called once per frame
    void Update()
    {

      switch (gs)
      {
        case GameState.Playing:
            if (playerHealth.health == 0)
            {
              gs = GameState.GameOver;
              gameOverCanvas.SetActive(true);
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

              Time.timeScale = 1;

              gs = GameState.AtTitle;
            }
            break;
        //=======================================================================//
        case GameState.GameOver:
            if (Input.GetKeyDown(KeyCode.R))
            {
              //Weer playen
              //playerTf.position = mapCreationScript.RespawnPos;
              playerRb.constraints = RigidbodyConstraints.None;

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
