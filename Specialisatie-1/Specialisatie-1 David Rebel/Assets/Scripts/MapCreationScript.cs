using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreationScript : MonoBehaviour
{
    public Vector3 RespawnPos;

    public GameObject[] allLevelParts;
    public float[] allLevelLengths;
    [SerializeField] private List<GameObject> allLevelPartsInstantiated;
    [SerializeField] private List<GameObject> allInBetweenPieces;
    private int playerIndex = 0;
    private float currentZcoord = 0f;
    private float lengthInBetween = 5f;
    public GameObject inBetweenPiece;

    public bool isFinished = false;
    // Start is called before the first frame update
    void Start()
    {
      allLevelPartsInstantiated.Add(Instantiate(allLevelParts[playerIndex], new Vector3(0,0,currentZcoord), Quaternion.identity));
      currentZcoord += allLevelLengths[playerIndex] + lengthInBetween;
      playerIndex++;
    }

    // Update is called once per frame
    void Update()
    {
      if (EnemyCheck() && !isFinished)
      {
        Debug.Log("alle enemies verslagen: " + (EnemyCheck()) + " nu op: " + playerIndex);
        if (allLevelParts.Length > playerIndex + 1)
        {
          makeNextLevel();
        }
        else
        {
          isFinished = true;
        }
      }

      Transform playerTransform = GameObject.Find("Player").GetComponent<Transform>();
      for (int i = 0; i < allLevelPartsInstantiated.Count; i++)
      {
        GameObject level = allLevelPartsInstantiated[i];
        if (level == null){}
        else if (playerTransform.position.z > allLevelPartsInstantiated[i].GetComponent<Transform>().position.z + allLevelLengths[i]/2 + lengthInBetween)
        {
          Destroy(allLevelPartsInstantiated[i]);
          Destroy(allInBetweenPieces[i]);
          allLevelPartsInstantiated[i] = null;
          allInBetweenPieces[i] = null;
        }
      }
    }

    public void makeNextLevel()
    {
      allLevelPartsInstantiated.Add(Instantiate(allLevelParts[playerIndex], new Vector3(0,0,currentZcoord), Quaternion.identity));
      allInBetweenPieces.Add(Instantiate(inBetweenPiece, new Vector3(0,0,currentZcoord - (float)2.5 - allLevelLengths[playerIndex + 1]/2), Quaternion.identity));
      currentZcoord += allLevelLengths[playerIndex] + lengthInBetween;
      allLevelPartsInstantiated[playerIndex - 1].GetComponent<LevelPartDoorScript>().prepareExit(false);
      playerIndex++;
    }

    public void destroyPrevLevel()
    {
      Destroy(allLevelPartsInstantiated[playerIndex - 1]);
      Destroy(allInBetweenPieces[playerIndex - 1]);
    }

    bool EnemyCheck()
    {
      return (GameObject.FindGameObjectsWithTag("Enemy").Length == 0);
    }
}
