using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int numberOfGameClues = 0;
    public List<GameObject> gameClues;
    
    // Start is called before the first frame update
    void Start()
    {
        gameClues = new List<GameObject>();        
    }

    public void ItemCollected(GameObject gameClue)
    {
        gameClues.Add(gameClue);
        numberOfGameClues++;
    }

  
}
