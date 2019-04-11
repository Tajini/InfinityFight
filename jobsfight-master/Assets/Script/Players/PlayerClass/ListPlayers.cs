using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ListPlayers{


    public List<string> AllPlayerName;

    public void GetPlayer(){
        AllPlayerName = new List<string>();

        string myPath = "./Assets/Script/Players/PlayerClass/Players/";
        DirectoryInfo dir = new DirectoryInfo(myPath);
        FileInfo[] info = dir.GetFiles("*.cs");
        int x = 0;
        foreach (FileInfo f in info)
        {
            //Debug.Log("Beng");
            string RealName = Path.GetFileNameWithoutExtension(f.ToString());
            AllPlayerName.Add(RealName);

            x++;
        }

        for (int i = 0; i < AllPlayerName.Count; i++){
            //Debug.Log("BengBeng");
            // Test le tableau
            //Debug.Log(AllPlayerName[i]);
            
        }

    }
}
