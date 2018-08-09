using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public float timeDelay = 1;
    private ParticleSystem particle;
    [SerializeField]
    private Collider2D collision;
    private SpriteRenderer spriteRenderer;
	void Start () {
        particle = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void destroy () {
        if (particle != null)
        {
            particle.Play();
            Destroy(collision,0);
            Destroy(spriteRenderer, timeDelay);
        }
        else
        {
            Destroy(gameObject, timeDelay);
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
