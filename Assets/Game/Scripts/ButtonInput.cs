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

    
    #if (UNITY_ANDROID ||UNITY_IOS )
    private void Update() {
        
            
                foreach (Touch touch in Input.touches) {
                    
                    if(touch.phase == TouchPhase.Began){
                      

                       Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);


                       RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                       
                       if (OnLeft != null && hit.collider != null && hit.collider.tag == "Left") {
                           OnLeft();
                       }
                       else if (OnRight != null && hit.collider != null && hit.collider.tag == "Right") {
                           OnRight();
                       }
                       
                    }

                }

    }
    
    #elif UNITY_EDITOR
    
    void Update(){
            if(Input.GetMouseButtonDown(0)){
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


                       RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                       
                       if (OnLeft != null && hit.collider != null && hit.collider.tag == "Left") {
                           OnLeft();
                       }
                       else if (OnRight != null && hit.collider != null && hit.collider.tag == "Right") {
                           OnRight();
                       }

                

            }

    }
//    private void OnMouseDown() {
//
//        if (OnLeft != null && button == Button.left) {
//            OnLeft();
//            //fireman.OnLeftPressed();
//        }
//        else if(OnRight != null && button == Button.right) {
//            OnRight();
//            //fireman.OnRightPressed();
//        }
//        
//        
//    } 
    #endif
    
}
