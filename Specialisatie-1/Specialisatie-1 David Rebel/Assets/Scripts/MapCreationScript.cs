using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreationScript : MonoBehaviour
{
    public Vector3 RespawnPos;

    public GameObject[] allLevelParts;
    public float[] allLevelLengths;
    private int playerIndex = 0;
    private float currentZcoord = 0f;
    private float lengthInBetween = 5f;
    public GameObject inBetweenPiece;

    public bool easyMode = false;
    // Start is called before the first frame update
    void Start()
    {
      Debug.Log(EnemyCheck());
      Instantiate(allLevelParts[playerIndex], new Vector3(0,0,currentZcoord + lengthInBetween * playerIndex), Quaternion.identity);
      currentZcoord = allLevelLengths[playerIndex];
      playerIndex++;
    }

    // Update is called once per frame
    void Update()
    {
      if (EnemyCheck())
      {
        Debug.Log("alle enemies verslagen: " + (EnemyCheck()) + " nu op: " + playerIndex);
        makeNextLevel();
      }
    }

    public void makeNextLevel()
    {
      Instantiate(allLevelParts[playerIndex], new Vector3(0,0,currentZcoord + lengthInBetween * playerIndex), Quaternion.identity);
      Instantiate(inBetweenPiece, new Vector3(0,0,currentZcoord + lengthInBetween/2 -25), Quaternion.identity);
      currentZcoord += allLevelLengths[playerIndex];
      playerIndex++;
    }

    public void destroyPrevLevel()
    {

    }

    bool EnemyCheck()
    {
      return (GameObject.FindGameObjectsWithTag("Enemy").Length == 0);
    }
}
