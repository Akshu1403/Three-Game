using System.Collections;
using UnityEngine;

public class coin_Spawne : MonoBehaviour
{
    public GameObject coinPrefab;
    void Start()
    {
        StartCoroutine(coinSpawner());
    }
    void Update()
    {
    }

    void spawnCoin()
    {
        int rand = Random.Range(-2, 2);
        Instantiate(coinPrefab,new Vector3(rand,transform.position.y,transform.position.z),Quaternion.identity);
    }
    IEnumerator coinSpawner()
    {
        while (true)
        {
            int time = Random.Range(10, 20);
            yield return new WaitForSeconds(time);
            spawnCoin();
        }
    }
}
