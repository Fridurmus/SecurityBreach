﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackBullet : MonoBehaviour {
    // Destroy self on collision
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
