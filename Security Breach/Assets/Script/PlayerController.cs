using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 6.0f;
    public bool sneaking = false;
    public bool sprinting = false;
    public bool isPaused = false;
    public GameObject pauseScreen;
    public GameObject exitTrig;
    float originalY;

    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    private Quaternion rightDirection = Quaternion.Euler(90, 90, 0);
    private Quaternion leftDirection = Quaternion.Euler(90, 270, 0);
    private Quaternion upDirection = Quaternion.Euler(90, 0, 0);
    private Quaternion downDirection = Quaternion.Euler(90, 180, 0);
    public Animator spriteAnimator;



    public bool isInteracting = false;
    public GameObject hackBulletPrefab;
    public Transform hackBulletSpawn;

    

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        originalY = transform.position.y;
        spriteAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //check for sprinting
        if (Input.GetButton("sprint") && Input.GetAxis("Horizontal") != 0 || Input.GetButton("sprint") && Input.GetAxis("Vertical") != 0)
        {
            sprinting = true;
            spriteAnimator.SetBool("isSprinting", true);
        }

        else
        {
            sprinting = false;
            spriteAnimator.SetBool("isSprinting", false);
        }

        //check for sneaking
        if (Input.GetButton("sneak"))
        {
            sneaking = true;
            spriteAnimator.SetBool("isCrouching", true);
        }
        else
        {
            sneaking = false;
            spriteAnimator.SetBool("isCrouching", false);
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

        if ((Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Horizontal") < -0.1f) || (Input.GetAxis("Vertical") > 0.1f || Input.GetAxis("Vertical") < -0.1f))
        {
            spriteAnimator.SetBool("isMoving", true);
        }
        else
        {
            spriteAnimator.SetBool("isMoving", false);
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
        if (Input.GetAxisRaw("Vertical") > 0 && transform.rotation.eulerAngles.z != 360)
        {
            transform.rotation = upDirection;
        }
        if (Input.GetAxisRaw("Vertical") < 0 && transform.rotation.eulerAngles.z != 180)
        {
            transform.rotation = downDirection;
        }

        //begin setting up non-movement input
        if (Input.GetButtonDown("use"))
        {
            isInteracting = true;
            spriteAnimator.SetTrigger("didInteract");
        }
        else
        {
            isInteracting = false;
        }

        //use timescale for pause
        if (Input.GetButtonDown("pause"))
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseScreen.SetActive(true);
        }
        if (isPaused == true && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 1;
        }

        if (transform.position.y != originalY)
        {
            transform.position = new Vector3(transform.position.x, originalY, transform.position.z);
        }
        //if (Input.GetButtonDown("shoot"))
        //{
        //    var hackBullet = (GameObject)Instantiate(
        //    hackBulletPrefab,
        //    hackBulletSpawn.position,
        //    hackBulletSpawn.rotation
        //);
        //    hackBullet.GetComponent<Rigidbody>().velocity = hackBulletSpawn.transform.up * 6;
            
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "upload" && Input.GetButtonDown("use"))
        {
            exitTrig.SetActive(true);
        }
    }
}
