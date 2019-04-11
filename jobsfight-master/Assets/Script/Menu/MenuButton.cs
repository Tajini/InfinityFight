using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class MenuButton : MonoBehaviour {

    // public variables
    public GameObject MenuPanel;
    public GameObject LevelSelectPanel;
    public GameObject Avatars;

    public Button buttonSound;
    public Sprite ImageUnmute, ImageMute;



    // private variables

    private bool StatusSound = true; // 0 = play | 1 = mute


    // Use this for initialization
    void Start () {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
        Avatars.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowLevelPanel() {
        MenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
        Avatars.SetActive(false);
    }

    public void ShowMenuPanel() {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
        Avatars.SetActive(false);
    }

    public void ShowAvatars(){
        MenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(false);
        Avatars.SetActive(true);
    }


    //   Menu Setting

    public void Audio()
    {
        if (StatusSound){
            Debug.Log('1');
            GameObject.FindGameObjectWithTag("Sound").GetComponent<Image>().sprite = ImageMute;
            StatusSound = false;
            Mute();
        }
        else if(StatusSound == false)
        {
            Debug.Log('2');
            GameObject.FindGameObjectWithTag("Sound").GetComponent<Image>().sprite = ImageUnmute;
            StatusSound = true;
            UnMute();
        }
    }

    public void Mute()
    {
        Debug.Log("Pas beng");
        gameObject.GetComponent<AudioSource>().Stop();
    }

    public void UnMute()
    {
        Debug.Log("Beng");
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
