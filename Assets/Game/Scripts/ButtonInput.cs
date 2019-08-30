using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour {
    
    public enum Button {
        left,
        right
    }

    public Button button;

   // public FiremanController fireman;
    //public bool left;

    public delegate void ButtonPressed();

    public static event ButtonPressed OnLeft;
    public static event ButtonPressed OnRight;
    
    private void OnMouseDown() {

        if (OnLeft != null && button == Button.left) {
            OnLeft();
            //fireman.OnLeftPressed();
        }
        else if(OnRight != null && button == Button.right) {
            OnRight();
            //fireman.OnRightPressed();
        }
        
        
    }
}
