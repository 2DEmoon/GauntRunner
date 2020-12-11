using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject powerupPrefab;
	public GameObject obstaclePrefab;
	public float spawnCycle = .5f;

	GameManager manager;
	float elapsedTime;
	bool spawnPowerup = true;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > spawnCycle)
        {
        	GameObject temp;
        	if (spawnPowerup)
        		temp = Instantiate(powerupPrefab) as GameObject;
        	else
        		temp = Instantiate(obstaclePrefab) as GameObject;

        	Vector3 position = temp.transform.position;
        	position.x = Random.Range(-3f, 3f);
        	temp.transform.position = position;
        	Collidable col = temp.GetComponent<Collidable>();
        	col.manager = manager;

        	elapsedTime = 0;
        	spawnPowerup = !spawnPowerup;
        }
    }
}
