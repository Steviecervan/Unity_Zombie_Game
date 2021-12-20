using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float sprintMultiplier = 1.5f;

    [SerializeField] float jumpForce; 
    [SerializeField] Transform groundChecker;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float crouchHeight;
    [SerializeField] float lyingHeight;
    [SerializeField] float normalHeight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveBy = transform.right * x + transform.forward * z;

        float actualSpeed = speed;
        if(Input.GetKey(KeyCode.LeftShift)){
            actualSpeed *= sprintMultiplier;
        }

        rb.MovePosition(transform.position + moveBy.normalized * actualSpeed * Time.deltaTime);
        

        //Jumping 
        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround()){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //Crouching
        Vector3 newScale = new Vector3(transform.localScale.x, normalHeight, transform.localScale.z);

        if(Input.GetKey(KeyCode.C)){
            newScale.y = crouchHeight;
        }
        else if(Input.GetKey(KeyCode.Z)){
            newScale.y = lyingHeight;
        }

        transform.localScale = newScale;

    }

    bool IsOnGround(){
        Collider[] colliders = Physics.OverlapSphere(groundChecker.position,checkRadius,groundLayer);

        if(colliders.Length > 0){
            return true;
        }
        else{
            return false;
        }
    }
}
