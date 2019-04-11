using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
     
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    public void TaskOnClick()
    {
        SceneManager.LoadScene("SampleScene");

    }
}
