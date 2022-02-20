using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y + speed);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        this.gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
	}

	private void OnBecameInvisible()
	{
        this.gameObject.SetActive(false);
	}
}
