using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject deathFX;
    // Start is called before the first frame update
    void Start()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger= false;
    }

    void OnParticleCollision(GameObject other){
    	Instantiate(deathFX, transform.position, Quaternion.identity);
    	Destroy(gameObject);
    }
}
