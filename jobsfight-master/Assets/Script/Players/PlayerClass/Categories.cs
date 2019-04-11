using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****    
    Les categories représente un type de personnage
    La catégorie A représente les personnages Fort (attaque), Robuste (defence), Lent (vitesse)
    La catégorie B représente les personnages équilibré entre la force (attaque), robuste (defence), rapide (vitesse)
    La catégorie C représente les personnages force (attaque) et robustesse (defence) varié et une haute rapidité (vitesse)

            ATTENTION A BIEN EQUILIBRE LES STATS DES PERSONNAGES

*****/
public class A{

    public float baseAttack = 70F,
                 baseDefence = 50F,
                 baseSpeed = 30F;

}

public class B{

    public float baseAttack = 45f,
                 baseDefence = 45f,
                 baseSpeed = 50f;
}

public class C{

    public float baseAttack = 30f,
                 baseDefence = 40f,
                 baseSpeed = 70f;
}