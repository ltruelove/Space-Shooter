using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleBoss : MonoBehaviour
{
    private int hitPoints;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 25;
    }

    // Update is called once per frame
    void Update()
    {
        
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
