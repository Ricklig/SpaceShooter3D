using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public GameObject bullet;
    public Transform ygun;
    public Transform x1gun;
    public Transform x2gun;
    public Transform fgun;
    public Sprite ywing;
    public Sprite xwing;
    public Sprite falcon;
    public int level = 1;
    public float velocity = 100.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (level == 0)
        {
            endGame();
        }

        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }





        }



    void Move() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = -Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0f);
        Vector3 finalDir = new Vector3(horizontal, vertical, 3.0f);
    
        transform.position += direction* moveSpeed*Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDir), Mathf.Deg2Rad* 30.0f);
    }

    void Fire()
    {
            GameObject newBullet = Instantiate(bullet, ygun.position, ygun.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * velocity, ForceMode.VelocityChange);
    }

    public void TakeDamage()
    {
        level--;
        //gotDamage.Play();
        if (level > 0)
        {
            if (level == 2)
            {
                //GetComponent<SpriteRenderer>().sprite = xwing;
            }
            else if (level == 1)
            {
                //GetComponent<SpriteRenderer>().sprite = ywing;
            }
        }
        else if (level == 0)
        {
            GameObject.FindWithTag("GameController").GetComponent<GameManager>().endGame();
            Destroy(gameObject);
            //var boom = (GameObject)Instantiate(explode, transform.position, transform.rotation);
            //var boooom = (GameObject)Instantiate(kaboom, transform.position, transform.rotation);
        }
    }


    public void LevelUp()
    {
        //powerUp.Play();
        if (level < 3)
        {
            level++;
            if (level == 2)
            {
                //GetComponent<SpriteRenderer>().sprite = xwing;
            }
            else if (level == 3)
            {
                //GetComponent<SpriteRenderer>().sprite = falcon;
            }
        }
    }

    void endGame()
    {
        Debug.Log("game over");
    }

}
