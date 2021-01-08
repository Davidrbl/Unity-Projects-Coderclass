using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private WeaponSelectionScript weaponSelectionScript;

    //private MapCreationScript mapCreationScript;


    public GameObject playingCanvas;
    public GameObject pausedCanvas;
    public GameObject gameOverCanvas;
    public GameObject titleScreenCanvas;


    // Start is called before the first frame update
    void Start()
    {
      playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
      playerTf = GameObject.Find("Player").GetComponent<Transform>();
      playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
      weaponSelectionScript = GameObject.Find("Player").GetComponent<WeaponSelectionScript>();
      gs = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {
      switch (gs)
      {
        case GameState.Playing:
            if (playerHealth.health == 0)
            {
              //Player is dood
              gameOverCanvas.SetActive(true);
              disableGun();

              gs = GameState.GameOver;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
              //pauseer
              pausedCanvas.SetActive(true);
              disableGun();

              gs = GameState.Paused;

            }
            break;
        //=======================================================================//
        case GameState.Paused:
            //Pauseer game/zet tijd stil
            Time.timeScale = 0;
            //Lock cursor, omdat het is geunlocked door de esc knop
            Cursor.lockState = CursorLockMode.Locked;

            //Zet speler stil
            playerRb.constraints = RigidbodyConstraints.FreezeAll;

            if (Input.GetKeyDown(KeyCode.R))
            {
              //Weer unpausen
              pausedCanvas.SetActive(false);
              Time.timeScale = 1;
              playerRb.constraints = RigidbodyConstraints.None;
              enableGun();

              gs = GameState.Playing;
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
              //Naar title screen

              Time.timeScale = 1;
              playerRb.constraints = RigidbodyConstraints.None;
              pausedCanvas.SetActive(false);

              gs = GameState.AtTitle;
              titleScreenCanvas.SetActive(true);
            }
            break;
        //=======================================================================//
        case GameState.GameOver:
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
            if (Input.GetKeyDown(KeyCode.R))
            {
              //Opnieuw beginnen
              SceneManager.LoadScene("huh");
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
              //Naar title screen
              playerRb.constraints = RigidbodyConstraints.None;
              titleScreenCanvas.SetActive(true);

              gs = GameState.AtTitle;
            }
            break;
        //=======================================================================//
        case GameState.AtTitle:
              if (Input.GetKeyDown(KeyCode.S))
              {
                //beginnen met het spel
                gs = GameState.Playing;
                SceneManager.LoadScene("huh");
                titleScreenCanvas.SetActive(false);
              }
              break;
      }
    }
    void disableGun()
    {
      weaponSelectionScript.currentGun.SetActive(false);
      weaponSelectionScript.enabled = false;
    }
    void enableGun()
    {
      weaponSelectionScript.enabled = true;
      weaponSelectionScript.currentGun.SetActive(true);
    }
}
