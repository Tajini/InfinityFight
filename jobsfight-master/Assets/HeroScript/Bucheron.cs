using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucheron : MonoBehaviour
{

    public double coeffAtt;
    public double coefDef;
    public double coefSpd;
    public string categorie;
    public string namePlayer = "Bucheron";


    // Use this for initialization
    void Start()
    {
        coeffAtt = 1.3f;
        coefDef = 1f;
        coefSpd = 1.2f;
        categorie = "BigGuys";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
