using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]private bool isPlayer1Goal;
    private void OnTriggerEnter2D(Collider2D collosion)
    {
        if (collosion.gameObject.CompareTag("Ball"))
        {
            if(!isPlayer1Goal)
            {
                Debug.Log("P2 Scored...");
                GameObject.Find("GameManager").GetComponent<Gamemanager>().Player1Scored();
            }
            else
            {
                Debug.Log("P2 Scored...");
                GameObject.Find("GameManager").GetComponent<Gamemanager>().Player2Scored();
            }
        }   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
