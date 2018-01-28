using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 6.0f;
    public bool sneaking = false;
    public bool sprinting = false;
    float originalY;

    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    public SpriteRenderer playerRenderer;
    private Quaternion rightDirection = Quaternion.Euler(0, 0, 90);
    private Quaternion leftDirection = Quaternion.Euler(0, 0, 270);
    private Quaternion upDirection = Quaternion.Euler(0, 0, 0);
    private Quaternion downDirection = Quaternion.Euler(0, 0, 180);

    public bool isInteracting = false;
    public GameObject hackBulletPrefab;
    public Transform hackBulletSpawn;

    

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        originalY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        //check for sprinting
        if (Input.GetButton("sprint"))
        {
            sprinting = true;
        }

        else
        {
            sprinting = false;
        }

        //check for sneaking
        if (Input.GetButton("sneak"))
        {
            sneaking = true;
        }
        else
        {
            sneaking = false;
        }

        //set the direction
		if (sprinting && !sneaking)
        {
            speed = 12.0f;
        }
        else if (sneaking)
        {
            speed = 3.0f;
        }
        else
        {
            speed = 6.0f;
        }
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //do the movement
        controller.Move(moveDirection * speed * Time.deltaTime);


        //do rotation checks.
        if (Input.GetAxisRaw("Horizontal") > 0 && transform.rotation.eulerAngles.z != 90)
        {
            transform.rotation = rightDirection;
        }
        if (Input.GetAxisRaw("Horizontal") < 0 && transform.rotation.eulerAngles.z != 270)
        {
            transform.rotation = leftDirection;
        }
        if (Input.GetAxisRaw("Vertical") > 0 && transform.rotation.eulerAngles.z != 0)
        {
            transform.rotation = upDirection;
        }
        if (Input.GetAxisRaw("Vertical") < 0 && transform.rotation.eulerAngles.z != 180)
        {
            transform.rotation = downDirection;
        }

        //begin setting up non-movement input
        if (Input.GetButton("use"))
        {
            isInteracting = true;
        }
        else
        {
            isInteracting = false;
        }

        //use timescale for pause
        if (Input.GetButtonDown("pause"))
        {
            Time.timeScale = 0;
        }
        if (Time.timeScale == 0 && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 1;
        }

        if (transform.position.y != originalY)
        {
            transform.position = new Vector3(transform.position.x, originalY, transform.position.z);
        }
        if (Input.GetButtonDown("shoot"))
        {
            var hackBullet = (GameObject)Instantiate(
            hackBulletPrefab,
            hackBulletSpawn.position,
            hackBulletSpawn.rotation
        );
            hackBullet.GetComponent<Rigidbody>().velocity = hackBulletSpawn.transform.up * 6;
            
        }
    }
}
