using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{
    float speed = 1.0f;
    float containmentBuffer = 40;
    bool isReturning = false;
    private int hitPoints;
    public GameObject player;

	private void Awake()
	{
        player = GameObject.FindGameObjectsWithTag("Player")[0];

    }

	// Start is called before the first frame update
	void Start()
    {
        hitPoints = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement;
        if (isReturning)
        {
            movement = returnToTop();
        }
        else
        {
            movement = attackPlayer();
        }

		transform.Translate(movement, Space.World);
    }

    private Vector2 returnToTop()
    {
		Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

		float yPos;
		float xPos = 0;

		if (screenPos.y > Screen.height - containmentBuffer)
		{
			isReturning = false;
			yPos = -speed;
		}
		else
		{
			yPos = speed * 3;
		}

		Vector2 movement = new Vector2(xPos, yPos) * Time.deltaTime;
        return movement;
    }

    private Vector2 attackPlayer()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 playerPos = Camera.main.WorldToScreenPoint(player.transform.position);

        float xPos;
        float yPos;

        if (screenPos.x < playerPos.x)
        {
            xPos = speed;
        }
        else if (screenPos.x > playerPos.x)
        {
            xPos = -speed;
        }
        else
        {
            xPos = 0;
        }

        if (screenPos.y < containmentBuffer)
        {
            isReturning = true;
            yPos = 0;
        }
        else
        {
            yPos = -speed;
        }

        Vector2 movement = new Vector2(xPos, yPos) * Time.deltaTime;
        return movement;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        hitPoints--;
        if (hitPoints < 1)
        {
            this.gameObject.SetActive(false);
        }
	}
}
