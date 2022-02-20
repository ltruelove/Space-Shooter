using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    public List<GameObject> pooledLasers;
    public GameObject laserObject;
    public int amountToPoolForLaser;

    public List<GameObject> pooledElectrics;
    public GameObject electricObject;
    public int amountToPoolForElectrics;

    public GameObject player;

	private void Awake()
	{
        SharedInstance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        pooledLasers = new List<GameObject>();
        for (int i = 0; i < amountToPoolForLaser; i++)
        {
            tmp = Instantiate(laserObject);
            tmp.SetActive(false);
            pooledLasers.Add(tmp);
        }

        pooledElectrics = new List<GameObject>();
        for (int i = 0; i < amountToPoolForElectrics; i++)
        {
            tmp = Instantiate(electricObject);
            tmp.SetActive(false);
            pooledElectrics.Add(tmp);
        }

        GameObject electric = GetPooledElectric();
        if (electric != null) {
			electric.transform.position = new Vector2(player.transform.position.x, 0.5f);
            electric.SetActive(true);
        }
    }

	public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }

	public GameObject GetPooledLaser()
    {
        for (int i = 0; i < amountToPoolForLaser; i++)
        {
            if (!pooledLasers[i].activeInHierarchy)
            {
                return pooledLasers[i];
            }
        }

        return null;
    }

	public GameObject GetPooledElectric()
    {
        for (int i = 0; i < amountToPoolForElectrics; i++)
        {
            if (!pooledElectrics[i].activeInHierarchy)
            {
                return pooledElectrics[i];
            }
        }

        return null;
    }
}
