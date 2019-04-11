using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Session {

    public string NickName;
    public int CurrentMoney = 100;
    public Text textNickname;
    Tuto tuto;

    public string currentPlayer = "Bucheron";

	// Use this for initialization
	void Start () {
        tuto = new Tuto();
	}
	
	// Update is called once per frame
	void Update () {
        // set the current money
        GameObject.FindWithTag("Money").GetComponent<Text>().text = CurrentMoney.ToString();
        Debug.Log(GameObject.FindWithTag("Money").gameObject.name);
        NickName = tuto.nickname;
        textNickname = GameObject.FindGameObjectWithTag("Nickname").GetComponent<Text>();
        textNickname.text = NickName;
	}
}
