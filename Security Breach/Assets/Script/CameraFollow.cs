using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject Player;
    public float moveSpeed;
    public float posX;
    public float posZ;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        posX = Mathf.Lerp(transform.position.x, Player.transform.position.x, moveSpeed * Time.deltaTime);
        posZ = Mathf.Lerp(transform.position.z, Player.transform.position.z, moveSpeed * Time.deltaTime);

        transform.position = new Vector3(posX, transform.position.y, posZ);
    }
}
