using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public GameObject projectile;
    public GameObject parent;
    PlayerControls controls;


	private void Awake()
	{
        controls = new PlayerControls();

        controls.Gameplay.Shoot.performed += ctx => fireGun();
	}

	private void OnEnable()
	{
        controls.Gameplay.Enable();
	}

	private void OnDisable()
	{
        controls.Gameplay.Disable();
	}

	private void fireGun()
    {
        GameObject proj = ObjectPool.SharedInstance.GetPooledObject();
        if (proj != null)
        {
            proj.transform.position = new Vector3(transform.position.x, transform.position.y);
            proj.SetActive(true);
        }
    }

    private void fireLaserCannon()
    {
        GameObject laser = ObjectPool.SharedInstance.GetPooledLaser();
        if (laser != null)
        {
            laser.transform.position = new Vector3(transform.position.x, transform.position.y);
            laser.SetActive(true);
        }
    }
}
