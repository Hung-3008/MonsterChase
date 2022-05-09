using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSprawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monstersReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;
    private int randomIndex;
    private int randomSide; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monstersReference.Length);
            randomSide = Random.Range(0, 2); // left = 0, right = 1, 2

            spawnedMonster = Instantiate(monstersReference[randomIndex]);
            if (randomSide == 0)
            {
                // left side 
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monters>().speed = Random.Range(4, 10);
            }
            else
            {
                // right side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monters>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        
    }
}
