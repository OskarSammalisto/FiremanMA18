﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void OnEnable() {
        ButtonInput.OnLeft += ButtonInput_OnLeft;
        ButtonInput.OnRight += ButtonInput_OnRight;
    }
    
    private void OnDisable() {
        ButtonInput.OnLeft -= ButtonInput_OnLeft;
        ButtonInput.OnRight -= ButtonInput_OnRight;
    }
    

    private void ButtonInput_OnLeft() {
        Debug.Log("BEEP LEFT!");
    }
    
    private void ButtonInput_OnRight() {
        Debug.Log("BEEP RIGHT!");
    }
}