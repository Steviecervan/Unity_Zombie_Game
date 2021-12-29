using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{

    public GameObject elevatorCallButton;
    public GameObject player;

    public Transform positionTop;
    public Transform positionBottom;

    public Animator elevatorAnimation;

    // Start is called before the first frame update
    void Start()
    {
        elevatorAnimation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayerToButton = Vector3.Distance(elevatorCallButton.transform.position, player.transform.position);
        if(distanceFromPlayerToButton < 3){
            if(Input.GetKey(KeyCode.E)){ // && elevatorAnimation.GetBool("OnGround") == true){
                /*Debug.Log("Player has pushed button");
                elevatorAnimation.SetBool("OnGround", false);
                
                if(elevatorAnimation.GetBool("OnGround") == false){
                    elevatorAnimation.SetBool("OnGround", true);
                }
            }
            if(Input.GetKey(KeyCode.E) && elevatorAnimation.GetBool("OnGround") == false){
                elevatorAnimation.SetBool("OnGround", true);*/
                if(elevatorAnimation.GetBool("Ground") == true){// && elevatorAnimation.GetBool("ButtonPressed") == false){
                    elevatorAnimation.SetBool("ButtonPressed", true);
                    elevatorAnimation.SetBool("Ground", true);
                }
                else if(elevatorAnimation.GetBool("Ground") == false){// && elevatorAnimation.GetBool("ButtonPressed") == false){
                    elevatorAnimation.SetBool("ButtonPressed", true);
                    elevatorAnimation.SetBool("Ground", false);
                }
            }
        }
    }

    public void reachedTop(){
        elevatorAnimation.SetBool("ButtonPressed", false);
        elevatorAnimation.SetBool("Ground", false);
    }
    public void reachedBottom(){
        elevatorAnimation.SetBool("ButtonPressed", false);
        elevatorAnimation.SetBool("Ground", true);
    }
}
