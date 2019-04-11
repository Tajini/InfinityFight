using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour {

    CategorieBigGuys categorieBG;
    CategorieNormalGuys categorieNG;
    CategorieSkinnyGuys categorieSG;


    Bucheron bucheron;
    Beerus beerus;

    private double BeerusAttack, BeerusDefence, BeerusSpeed, BucheronAttack, BucheronDefence, BucheronSpeed;
    private string BeerusCategorie, BucheronCategorie;
    private double CategorieBGAttack, CategorieBGDefence, CategorieBGSpeed, CategorieNGAttack, CategorieNGDefence, CategorieNGSpeed, CategorieSGAttack, CategorieSGDefence, CategorieSGSpeed;


    public double RealAttackBucheron, RealDefenceBucheron, RealSpeedBucheron;
    public double RealAttackBeerus, RealDefenceBeerus, RealSpeedBeerus;

    // Use this for initialization
    void Start () {
        beerus = new Beerus();
        bucheron = new Bucheron();
        categorieBG = new CategorieBigGuys();
        categorieNG = new CategorieNormalGuys();
        categorieSG = new CategorieSkinnyGuys();

        // Faire une règle pour qu'il calcul que les personnages en jeu
        // enregistrement des variables des players et categoeries

        // Beerus stat
        BeerusAttack = beerus.coeffAtt;
        BeerusDefence = beerus.coefDef;
        BeerusSpeed = beerus.coefSpd;
        BeerusCategorie = beerus.categorie;

        // Bucheron stat
        BucheronAttack = bucheron.coeffAtt;
        BucheronDefence = bucheron.coefDef;
        BucheronSpeed = bucheron.coefSpd;
        BucheronCategorie = bucheron.categorie;

        // Categorie stat
        CategorieBGAttack = categorieBG.baseAttack;
        CategorieBGDefence = categorieBG.baseDefence;
        CategorieBGSpeed = categorieBG.baseSpeed;
        CategorieNGAttack = categorieNG.baseAttack;
        CategorieNGDefence = categorieNG.baseDefence;
        CategorieNGSpeed = categorieNG.baseSpeed;
        CategorieSGAttack = categorieSG.baseAttack;
        CategorieSGDefence = categorieSG.baseDefence;
        CategorieSGSpeed = categorieSG.baseSpeed;

        // Le calcul se fait ici

        // Beerus
        RealAttackBeerus = CategorieNGAttack * BeerusAttack;
        RealDefenceBeerus = CategorieNGDefence * BeerusDefence;
        RealSpeedBeerus = CategorieNGSpeed * BeerusSpeed;

        // Bucheron
        RealAttackBucheron = CategorieBGAttack * BucheronAttack;
        RealDefenceBucheron = CategorieBGDefence * BucheronDefence;
        RealSpeedBucheron = CategorieBGSpeed * BucheronSpeed;



		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
