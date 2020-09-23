using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float rateOfFire;
    public float speed;
    public GameObject pumpkin;
        
    private float inputHorizontal;
    private float nextFire;

    private Animator anim;
    private SpriteRenderer pumpkinSprite;

    [SerializeField]
    private GameObject gameController;
    
	// Use this for initialization
	void Start ()
    {
        //Get the animator component
        anim = GetComponent<Animator>();

        //Get the sprite renderer component from the pumpkin source component
        pumpkinSprite = transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();

        //Initialize the next fire
        nextFire = 0f;


	}

    // Fixed Update is called a fixed number of times per second
    void Update()
    {
        //Set the animation state to idle
        anim.SetInteger("state", 0);

        //If the current time is greater than the next fire time
        if (Time.time > nextFire)
        {
            //Show the pumpkin
            pumpkinSprite.enabled = true;
        }

        //Get the input values
        inputHorizontal = Input.GetAxis("Horizontal");

            //If there is horizontal movement
            if (inputHorizontal != 0f)
            {
                //Move the player
                transform.Translate(new Vector3(inputHorizontal * speed * Time.deltaTime, 0f, 0f));

                //Set the animation state to moving
                anim.SetInteger("state", 1);

                //If the player tries to go beyond the negative bound
                if (transform.position.x < -9f)
                {
                    //Stop the player from moving
                    transform.SetPositionAndRotation(new Vector3(-9f, 2f), new Quaternion(0, 0, 0, 0));

                    //Set the animation state to idle
                    anim.SetInteger("state", 0);
                }

                //If the player tries to go beyond the positive bound
                else if (transform.position.x > 9f)
                {
                    //Stop the player from moving
                    transform.SetPositionAndRotation(new Vector3(9f, 2f), new Quaternion(0, 0, 0, 0));

                    //Set the animation state to idle
                    anim.SetInteger("state", 0);
                }
            }

        //If the player hits the fire button and the current time is greater than the next fire time
        if (Input.GetButtonDown("Fire") && Time.time > nextFire)
        {
            //Set the next fire time
            nextFire = Time.time + 1/rateOfFire;

            //Drop a pumpkin from the pumpkin source
            Instantiate(pumpkin);

            //Hide the pumpkin sprite
            pumpkinSprite.enabled = false;
        }
    }
}

