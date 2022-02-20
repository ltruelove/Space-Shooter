using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed);
        transform.rotation = new Quaternion(0, 0, 0, 0);
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
