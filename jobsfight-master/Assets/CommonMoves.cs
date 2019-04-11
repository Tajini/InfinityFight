
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonMoves : MonoBehaviour {

    #region Variables 
    public Animator anim;
    public int Ianim; //0 = Idle ; 1 = Courrir ; 2 = Saut; 3 = Attaque A ; 4 = Attaque B; 5 = X;
	public int pourcentage, angle, force;
    public int Attaque, Defense, Vitesse;
    public GameObject Player2;
    public int Type; //1 = Rapide, 2 = Moyen, 3 = 
    public int vie;
	public float speed = 0.4f;
    public float timer;
    public bool attack, Xbool, Invincibility;
    public Joystick Joystick;
    public Transform checkSol;
    public bool toucheLeSol = false;
    float rayonSol = 0.3f;
    public LayerMask Sol;
  
    #endregion
    //Script de tous les mouvements de base que tous les personnages utiliseront, dont la direction, le bouton X (esquive/garde/saut),  ainsi que les animations grâce à un script générique pour les activer 

    //Deuxième temps : Intégrer les statistiques de base ici et les modifications dans le script enfant 
    void Start () {
        vie = 3;
		anim = GetComponent<Animator>();
        Joystick = GameObject.Find("Joystick").GetComponent<Joystick>();
        checkSol = this.transform.GetChild(0).transform;
        Player2 = GameObject.Find("Player2").transform.GetChild(0).gameObject;
        // = anim.GetComponent<int>
        // Script IA : Utiliser INAVIGATOR - Si phase attaque offensive : True jusqu'à position.x - distance: Enclenche une attaque B ou A + direction du player : si touche A A A // Si phase Defensive : True jusqu'à  position-x - distance+élevé :  1 chance sur 3 d'esquiver 
    } 
    void FixedUpdate() //Utiliser pour rigidbody
    {
        toucheLeSol = Physics2D.OverlapCircle(checkSol.position, rayonSol, Sol);



    }
    // Update is called once per frame
    void Update () {
       
        Ianim = anim.GetInteger("AnimInt");
        GameObject.Find("LifePlayer1").GetComponent<Text>().text = pourcentage.ToString() + " %";

        #region Deplacements 
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // anim.SetFloat("Speed", Mathf.Abs(x));
        if (attack == false)
        {
            if (Joystick.Direction == 0)
            {
                Animation(0);
            }
            if (Joystick.Direction == 1) //Vers la droite
            {
                x = x + 1;
                Animation(1);

                if (Xbool == true) { GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, y)); Animation(5); Xbool = false; transform.eulerAngles = new Vector2(0, 180); Invincibility = true; Xbool = false; }
                //Xbool = esquive 
            }
            if (Joystick.Direction == 2) //Vers la gauche
            {

                x = x - 1;
                Animation(1);
                if (Xbool == true) { GetComponent<Rigidbody2D>().AddForce(new Vector2(200, y)); Animation(5); Xbool = false; transform.eulerAngles = new Vector2(0, 180); Invincibility = true; Xbool = false;
                }
            }

                
            
        }
           
          

        //   else { anim.SetInteger("AnimInt", 0); }

        if (x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
                transform.Translate(-x * speed, 0, 0);
            }

            if (x < 0)
            {
                transform.Translate(x * speed, 0, 0);
                transform.eulerAngles = new Vector2(0, 180);


            }
        #endregion


        if (Invincibility == true)
        {
            timer += Time.deltaTime;
         //   this.GetComponent<CapsuleCollider2D>().enabled = false;
           
            if (timer >= 2f)
            {
                Invincibility = false;
                timer = 0;
         //       this.GetComponent<CapsuleCollider2D>().enabled = true;

            }
        }
    }


    public void ButtonA()
    {
        this.attack = true;
      
            if (GameObject.Find("Joystick").GetComponent<Joystick>().Direction == 3)
            {
                Animation(6);
            }
        

        else
        {
            Animation(3);
        }
            
        Invoke("StopAttack", 0.5f);
       
    }
   public void ButtonB()
    {
        Animation(4);
        attack = true;
        Invoke("StopAttack", 0.5f);
    }
   public void ButtonX()
    {
        Xbool = true;
        
    }
   public void ButtonY()
    {
        if (toucheLeSol)
        {
            Animation(2);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1200));

        }
    }


    public void Animation(int CurrentStance)
    {
        switch (CurrentStance)
        {
            case 0: anim.SetInteger("AnimInt", 0);  break;
            case 1: anim.SetInteger("AnimInt", 1);  break;
            case 2: anim.SetInteger("AnimInt", 2);  break;
            case 3: anim.SetInteger("AnimInt", 3);  break;
            case 4: anim.SetInteger("AnimInt", 4); break;
            case 5: anim.SetInteger("AnimInt", 5); break;
            case 6: anim.SetInteger("AnimInt", 6); break;
            default: break;
        }

    }




    public void StopAttack()
    {
        attack = false;
    }


    //Repérage de la cible
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == Player2.name)
        {

            if (attack == true)
            {

                if (transform.eulerAngles.y == 180) { angle = 2; }
                if (transform.eulerAngles.y == 0) { angle = 1; }
                if (Ianim == 3) force = 20;
                if (Ianim == 4) force = 40;
                collision.GetComponent<IAScript>().Damaged(angle, force);
                attack = false;
           
            }
        }
    }
    public void Damaged(int angle, int force)
    {
        if (!Invincibility)
        {
            pourcentage += force; 
            if (angle == 1)
            {
                //Rajouter un stop si "combo" ou autre + Ejection qui s'accmule pour le nombre de coups qui sont passés 
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-10 * pourcentage, 0));
            }
            if (angle == 2)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(10 * pourcentage, 0));
            }
            Invincibility = true;
        }

    }

}
