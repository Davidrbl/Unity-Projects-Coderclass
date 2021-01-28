using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public bool playerDead = true;
    public GameObject player;
    public Image titleScreen;
    public int score = 0;
    public Text scoreText;
    public SpawnScript sc;
    public Text titleText;
    public Text respawnText;
    // Start is called before the first frame update
    void Start()
    {
      scoreText.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
      if (playerDead && Input.GetKeyDown(KeyCode.R))
      {
        Restart();
      }
    }

    public void playerDied()
    {
      playerDead = true;
      titleScreen.enabled = true;
      score = -1;
      GetPoint();
      scoreText.enabled = false;
      sc.playerAlive = false;
      titleText.enabled = true;
      respawnText.enabled = true;
      GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
      foreach (GameObject obj in allEnemies)
      {
        Destroy(obj);
      }
    }

    void Restart()
    {
      Instantiate(player, new Vector2(0,-2), Quaternion.identity);
      titleScreen.enabled = false;
      scoreText.enabled = true;
      sc.playerAlive = true;
      titleText.enabled = false;
      respawnText.enabled = false;
      playerDead = false;
    }

    public void GetPoint()
    {
      score += 1;
      scoreText.text = "Score: " + score;
    }
}
