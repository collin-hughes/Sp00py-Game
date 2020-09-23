using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;

    private bool movingLeft;

    private AudioSource soundFXPlayer;
    public GameObject playerSprite;

    // Use this for initialization
    void Start () {
        movingLeft = false;
        transform.SetPositionAndRotation(new Vector3(Random.Range(-8, 8), -4f), new Quaternion (0f, 0f, 0f, 0f));

        playerSprite = GameObject.Find("playerSprite");
        soundFXPlayer = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
            if (transform.position.x > -9 && !movingLeft)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0f));

                if (transform.position.x > 9)
                {
                    movingLeft = true;
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 1.5f));
                }
            }

            else if (transform.position.x < 9 && movingLeft)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0f));

                if (transform.position.x < -9)
                {
                    movingLeft = false;
                    transform.Translate(new Vector3(speed * Time.deltaTime, 1.5f));
                }
            }

        if (transform.position.y >= 2)
        {
            GameController.gameOver = true;
            Destroy(gameObject);
        }        

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Pumpkin")
        {
            soundFXPlayer.Play();

            Destroy(coll.gameObject);

            GameController.counter--;

            Destroy(gameObject, .1f);

        }
    }
}
