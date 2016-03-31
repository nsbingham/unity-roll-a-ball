﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public float speed; // Automagically shows in inspector because it's public
    private Rigidbody rb;
    
    private int count;
    
    public Text countText;
    
    public Text winText;
    
    void Start() {
        // Gets reference to the RigidBody component on the object
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    
    void FixedUpdate()
    {   
           float moveHorizontal = Input.GetAxis("Horizontal");
           float moveVertical = Input.GetAxis("Vertical");
           Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
           
           rb.AddForce(movement * speed);
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);
            count ++;
            SetCountText(); 
        }
    }
    
    void SetCountText () {
        countText.text = "Count: " + count.ToString();
        if(count >= 8){
            winText.text = "You Win!";
        }
    }

}