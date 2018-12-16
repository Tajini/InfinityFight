using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class IAScript : MonoBehaviour {
    public Animator anim;
    public int angle, force, pourcentage;
    public int vie = 3;
    public float speed = 1f;
    public bool attack, Xbool, Invincibility;
    public float timer, timermort, timerattack;
    public string life;
    public Transform Player;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        life = GameObject.Find("LifePlayer2").GetComponent<Text>().text;
       


   

    }

    // Update is called once per frame
    void Update () {
        Player = GameObject.Find("Bucheron").transform;

        GameObject.Find("LifePlayer2").GetComponent<Text>().text = pourcentage.ToString() + " %";

        #region Deplacements IA 
        if (Player.position.x >= this.transform.position.x){
            transform.eulerAngles = new Vector2(0, 180);
            transform.Translate( -speed / 10, 0, 0);
            anim.SetInteger("AnimInt", 1);

            Xbool = true;
        }

        if (Player.position.x <= this.transform.position.x)
        {
            Xbool = false;
            transform.eulerAngles = new Vector2(0, 0);
            transform.Translate(-speed / 10, 0, 0);
            anim.SetInteger("AnimInt", 1);


        }
        #endregion

        #region Attaques IA
        if (Vector2.Distance(Player.position, this.transform.position) < 2)
        {
            anim.SetInteger("AnimInt", 3);
            attack = true;
            Invoke("StopAttack", 1f);
        }
        #endregion

        if(Invincibility == true)
        {
            timer += Time.deltaTime;

            if(timer >= 2f)
            {
                Invincibility = false;
            }
        }
    }

    public void Damaged(int angle, int force) //Dégats reçus par l'ennemi
    {
        if (!Invincibility)
        {
            pourcentage += force;
        
            if (angle == 1)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-10 * pourcentage, 0));
            }
            if (angle == 2)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(10 * pourcentage, 0));
            }
            Invincibility = true;
        }

    }

    public void StopAttack()
    {
        attack = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Bucheron")
        {
            timerattack += Time.deltaTime;

            if (attack == true && timerattack >= 1f)
            {
                if (transform.eulerAngles.y == 180) { angle = 2; }
                if (transform.eulerAngles.y == 0) { angle = 1; }
                force = 20;
                collision.GetComponent<CommonMoves>().Damaged(angle, force);
                attack = false;
                timerattack = 0;

            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Bucheron")
        {
            timerattack = 0;

        }
    }
}
