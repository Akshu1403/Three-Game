using System.Collections;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject[] cars;
    void Start()
    {
        StartCoroutine(spawn());
    }

    void Update()
    {
    }

    //generate cars
    void car()
    {
        int rand =Random.Range(0, cars.Length);
        int randXpos = Random.Range(-2, 2);
        Instantiate(cars[rand],new Vector3(randXpos,transform.position.y,transform.position.z),Quaternion.identity);
    }
    
    //to do the spawn car
    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            car();
        }
        
    }
}
