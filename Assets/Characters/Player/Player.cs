using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    bool leftPressed;
    bool rightPressed;
    const float deadZone = 0.1f;
    PlayerControls controls;
    Vector2 move;


    public float speed;

	private void Awake()
	{
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
	}

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(move.x, move.y) * Time.deltaTime * 3;
        Vector2 boundPosition = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(boundPosition);

        if (screenPos.x < 25 || screenPos.x > Screen.width - 25){ 
			movement.x = 0;
        }

        if (screenPos.y < 25 || screenPos.y > Screen.height - 100){
            movement.y = 0;
        }

		transform.Translate(movement, Space.World);
    }

    void FixedUpdate()
    {
    }

	private void OnEnable()
	{
        controls.Gameplay.Enable();
	}

	private void OnDisable()
	{
        controls.Gameplay.Disable();
	}
}
