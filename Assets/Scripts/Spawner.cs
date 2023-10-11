using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    private bool spawning = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnItems(){
        while(true){
            Instantiate(obstacle);

            yield return new WaitForSeconds(10f / PlayerController.speed);
        }
    }
}
