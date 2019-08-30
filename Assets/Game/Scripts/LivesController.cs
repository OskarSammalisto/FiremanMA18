using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {
    
    
    public float distance = 0.8f;
    List<GameObject> lives = new List<GameObject>();
    

    public void InitializeLives(int count) {
        
        //leta reda på first life
        GameObject firstLife = transform.GetChild(0).gameObject;
        lives.Add(firstLife);

        if (firstLife == null) {
            Debug.Log("no lives");
            return;
        }
        
        //kopiera first life count gånger
        for (int i = 0; i < count -1; i++) {
           GameObject live = Instantiate(firstLife, transform, true);
           lives.Add(live);
           Vector3 pos = live.transform.position;
           pos.x += distance * (i+1);
           live.transform.position = pos;
        }

    }

    public bool RemoveLive() {

        if (lives.Count < 1) {
            return false;
        }
        
        GameObject lastLife = lives[lives.Count - 1];
        lives.RemoveAt(lives.Count -1);
        
        Destroy(lastLife);
        return true;
        

    }
    
    
}
