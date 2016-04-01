using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rbody;
    Animator anim;
	public float speed;
	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
	}//start

    // Update is called once per frame
    void Update() {
        //Set movementVector to Input Manager's Horizontal and Vertical values (zqsd)
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (movementVector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movementVector.x);
            anim.SetFloat("input_y", movementVector.y);
        }
        else
        {
            anim.SetBool("iswalking", false);
        }//if

        rbody.MovePosition(rbody.position + movementVector * Time.deltaTime * speed);
	}//Update
}//PlayerMovement
