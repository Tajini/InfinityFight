using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWalls : MonoBehaviour {
    public int waitrevive;
    public bool deathcoming;
    public float timerdeath, timerrevive;
    public Transform Player, IA, respawn;
	// Use this for initialization
	void Start () {
        respawn = GameObject.Find("Respawn").transform;
        Player = GameObject.Find("Player1").transform.GetChild(0);
        IA = GameObject.Find("EvilTwin").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(waitrevive == 1)
        {
         timerrevive += Time.deltaTime;
            Player.position = new Vector2(respawn.position.x, respawn.position.y);

            if(timerrevive >= 3f)
            {
             
                timerdeath = 0;
                timerrevive = 0;
                waitrevive = 0;
            }

        }

        if (waitrevive == 2)
        {
            timerrevive += Time.deltaTime;
            IA.position = new Vector2(respawn.position.x, respawn.position.y);

            if (timerrevive >= 3f)
            {

                timerdeath = 0;
                timerrevive = 0;
                waitrevive = 0;
            }

        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Bucheron" || collision.gameObject.name == "Beerus")
        {
            timerdeath += Time.deltaTime;
            if (timerdeath >= 2f) {

                collision.GetComponent<CommonMoves>().vie -= 1;
                Debug.Log(collision.GetComponent<CommonMoves>().vie);
                if (collision.GetComponent<CommonMoves>().vie == 0) { SceneManager.LoadScene("SampleScene"); }
                collision.GetComponent<CommonMoves>().Animation(0);
                collision.GetComponent<CommonMoves>().pourcentage = 0;

 
                waitrevive = 1;
                deathcoming = false;
            }
        }
        if(collision.gameObject.name == "EvilTwin")
        {
            timerdeath += Time.deltaTime;
          
                if (timerdeath >= 2f)
                {
                collision.GetComponent<IAScript>().vie -= 1;
                collision.GetComponent<IAScript>().pourcentage = 0;
                waitrevive = 2;
                deathcoming = false;
                }
            
        }

        }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bucheron")
        {
            timerdeath = 0;
       
        }
        if (collision.gameObject.name == "EvilTwin")
        {
            timerdeath = 0;

          

        }
    }
}

