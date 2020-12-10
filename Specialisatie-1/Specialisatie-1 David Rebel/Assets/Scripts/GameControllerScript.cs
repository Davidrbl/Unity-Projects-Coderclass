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
      AtTitle
    }

    public Image pausedOverlay;
    public Text pausedText;
    private GameState currentGameState;

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

          break;
        case GameState.Paused:

            break;
        case GameState.AtTitle:

              break;
      }
    }
}
