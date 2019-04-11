using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindPlayer : MonoBehaviour {
    public string ButtonName;
    public CommonMoves commonMoves;
    public Joystick Joystick;
	// Use this for initialization
	void Start () {
        Joystick = GameObject.Find("Joystick").GetComponent<Joystick>();
        commonMoves = GameObject.Find("Player1").transform.GetChild(0).GetComponent<CommonMoves>();
        ButtonName = this.name;
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TaskOnClick()
    {
        switch (ButtonName)
        {
            case "ButtonA": commonMoves.ButtonA(); break;
            case "ButtonB": commonMoves.ButtonB(); break;
            case "ButtonX": commonMoves.ButtonX(); break;
            case "ButtonY": commonMoves.ButtonY(); break;

            default:break;
        }
      
    }
}
