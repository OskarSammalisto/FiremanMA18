using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour {
    
    
    public delegate void Jumper();

    public static event Jumper OnJumperCrash;
    public static event Jumper OnJumperSave;
    
    [SerializeField]
    private List<Transform> jumperPositions = new List<Transform>();
    public int currentPosition = 0;
    private float moveDelay = 1.0f;
    private float deathDelay = 0.5f;

//    [HideInInspector]
//    public GameManager gameManager;

    private bool dead = false;

    public LayerMask layerMask;
    
    private void Start() {
        UpdatePosition();
        
        StartCoroutine(Move());
    }

    IEnumerator Move() {

        while (!dead) {
            yield return new WaitForSeconds(moveDelay);
            MoveToNextPosition();
        }
        
    }
    
    private void MoveToNextPosition() {
        currentPosition++;
        
        if (currentPosition >= jumperPositions.Count) {
            DestroyJumper();
        }
        else {
           UpdatePosition();
        }
        
    }
    
    void UpdatePosition() {
        
        transform.position = jumperPositions[currentPosition].position;

        if (jumperPositions[currentPosition].gameObject.CompareTag("DangerousPosition")) {
           
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layerMask);

            if (hit.collider == null) {
                
                StartCoroutine(Crash());
                OnJumperCrash?.Invoke();
              //  gameManager.jumperCrashed();
            }
            else {
                OnJumperSave?.Invoke();
              //  gameManager.JumperSaved();
            }
        }
        
    }

    IEnumerator Crash() {

        dead = true;
        
        
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        
        yield return new WaitForSeconds(deathDelay);
        DestroyJumper();
    }

    void DestroyJumper() {
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    }
}
