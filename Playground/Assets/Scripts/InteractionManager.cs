using UnityEngine;
using System.Collections;

public class InteractionManager : MonoBehaviour {

    GameObject player;
    RaycastHit hit;
    float theDistance;
    Vector2 currentDirection;

    // Use this for initialization
    void Start () { 
        player = GameObject.FindGameObjectWithTag("Player");
        currentDirection = new Vector2();
    }//start

    // Update is called once per frame
    void Update()
    {
        performRayCastOnMovement();
        performRayCastOnIdle();
    }//update

    private void performRayCastOnMovement()
    {
        //Change to cases!

        //Right
        //Check for Horizontal Movevemnt right (right is positive and true for > 0)
        if (Input.GetAxis("Horizontal") > 0)
        {
            //Create a vector2 facing right 
            Vector2 right = transform.TransformDirection(Vector2.right) * 100;
            currentDirection = right;                                       //Will require this for Idle Ray Casting
            Debug.DrawRay(transform.position, right, Color.red);            //Debug visual 
            if (Physics.Raycast(transform.position, (right), out hit))      //Check for hit
            {
                theDistance = hit.distance;                                 //Pull distance from class variable hit now thats its set
                print(theDistance + ": " + hit.collider.gameObject.name);   //Print distance and gameObject's name
            }//if
        }//if

        //Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            Vector2 left = transform.TransformDirection(Vector2.left) * 100;
            currentDirection = left;
            Debug.DrawRay(transform.position, left, Color.red);
            if (Physics.Raycast(transform.position, (left), out hit))
            {
                theDistance = hit.distance;
                print(theDistance + ": " + hit.collider.gameObject.name);
            }//if
        }//if

        //Up
        if (Input.GetAxis("Vertical") > 0)
        {
            Vector2 up = transform.TransformDirection(Vector2.up) * 100;
            currentDirection = up;
            Debug.DrawRay(transform.position, up, Color.red);

            if (Physics.Raycast(transform.position, (up), out hit))
            {
                theDistance = hit.distance;
                print(theDistance + ": " + hit.collider.gameObject.name);
            }//if
        }//if

        //Down
        if (Input.GetAxis("Vertical") < 0)
        {
            Vector2 down = transform.TransformDirection(Vector2.down) * 100;
            currentDirection = down;
            Debug.DrawRay(transform.position, down, Color.red);

            if (Physics.Raycast(transform.position, (down), out hit))
            {
                theDistance = hit.distance;
                print(theDistance + ": " + hit.collider.gameObject.name);
            }//if
        }//if
    }//performRayCastOnMovement

    private void performRayCastOnIdle()
    {
        //Check to see if there is  no input = no movement and thus idle
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            //take previous direction (vector currentDirection) from class and raycast its direction
            Debug.DrawRay(transform.position, currentDirection, Color.red);//Debug visual of the raycast
            //if collider is hit, show hit object's name
            if (Physics.Raycast(transform.position, (currentDirection), out hit))
            {
                theDistance = hit.distance;
                print(theDistance + ": " + hit.collider.gameObject.name);
            }//if
        }//if
    }//performRayCastOnIdle
}//InteractionManager
