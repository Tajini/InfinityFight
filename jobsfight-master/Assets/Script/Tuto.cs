using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto : MonoBehaviour {

    public GameObject AddNickname, Slide1, Slide2, Slide3, Slide4;
    public Text NicknameWrited;
    public string nickname;
    //private Image currentGO;
    private Button nextButton;

    // Use this for initialization
    void Start ()
    {
        AddNickname.SetActive(false);
        Slide1.SetActive(false);
        Slide2.SetActive(false);
        Slide3.SetActive(false);
        Slide4.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Skip() {
        GameObject TutoGO;
        TutoGO = this.transform.parent.parent.gameObject;
        TutoGO.SetActive(false);
    }

    public void Next() {
        Debug.Log(2);
        //Debug.Log(firstGO);
        GameObject currentGO = this.transform.parent.gameObject;
        string nextPhase = this.tag;
        GameObject nextGO = GameObject.Find("/Canvas/Tuto/" + nextPhase);
        nextGO.SetActive(true);
        //currentGO.SetActive(false);

        Debug.Log(nextPhase);
        Debug.Log(nextGO);
    }

    public void NewNickname() {
        nickname = NicknameWrited.text;
        if (nickname.Length == 0){
            Debug.Log("Entre ton Pseudo");
        }
        else if(nickname.Length != 0){
            Debug.Log(1);
            Next();
        }
    }
}
