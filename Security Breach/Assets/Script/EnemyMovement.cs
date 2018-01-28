using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	public Transform [] listofPlaces;

	public NavMeshAgent myNavmeshAgent;
	private int currentDestination = 0;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
        PatrolLevel();
	}
	public void PatrolLevel()
	{
		if(transform.position.x == listofPlaces[currentDestination].transform.position.x
			&& transform.position.z == listofPlaces[currentDestination].transform.position.z)
		{
			currentDestination++;
		}
		if(currentDestination >= listofPlaces.Length)
		{
			currentDestination = 0;
		}

		if(currentDestination < 0) 
		{
			currentDestination = listofPlaces.Length - 1;
		}

		myNavmeshAgent.destination = listofPlaces [currentDestination].transform.position;

	}
}