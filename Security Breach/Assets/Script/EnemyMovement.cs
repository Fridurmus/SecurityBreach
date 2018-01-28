using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] listofPlaces;

    public NavMeshAgent myNavmeshAgent;
    private int currentDestination = 0;
    Vector3 lastPosition;
    Quaternion lastRotation;
    Animator myAnimator;
    SightCone mySightCone;

    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();
        mySightCone = GetComponent<SightCone>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mySightCone.visibleTargets.Count < 1)
        {
            PatrolLevel();
            myAnimator.SetBool("isAlerted", false);
            myAnimator.SetBool("isTargetInRange", false);
        }
        else
        {
            transform.position = lastPosition;
            transform.rotation = lastRotation;
            myAnimator.SetBool("isAlerted", true);
            myAnimator.SetBool("isMoving", false);
            myAnimator.SetBool("isTargetInRange", true);
        }
    }
    public void PatrolLevel()
    {
        if (transform.position.x == listofPlaces[currentDestination].transform.position.x
            && transform.position.z == listofPlaces[currentDestination].transform.position.z)
        {
            currentDestination++;
        }
        if (currentDestination >= listofPlaces.Length)
        {
            currentDestination = 0;
        }

        if (currentDestination < 0)
        {
            currentDestination = listofPlaces.Length - 1;
        }

        if (lastPosition != transform.position)
        {
            myAnimator.SetBool("isMoving", true);
        }
        lastPosition = transform.position;
        lastRotation = transform.rotation;
        myNavmeshAgent.destination = listofPlaces[currentDestination].transform.position;

    }
}