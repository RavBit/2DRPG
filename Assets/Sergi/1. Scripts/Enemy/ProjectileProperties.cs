using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour {

	// Use this for initialization
	public void InitProjectile (float speed = -1) {
	}

    public void Destroy()
    {
        Destroy(this);
    }
}
