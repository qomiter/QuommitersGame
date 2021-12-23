using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poop : MonoBehaviour
{
    public GameObject poopy;
    public GameObject gameObjectToMove;
    private IEnumerator coroutinex;
    public bool stopper = false;
    public float intervalx = 1f;
    public float timeer;
    public float delyer; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", timeer, delyer);
        
    }

    
    public void SpawnObject(){
        gameObjectToMove.transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 7.3f, 0f);
        Instantiate(poopy, transform.position, transform.rotation);
        if(stopper){
            CancelInvoke("SpawnObject");
            //do stuff
        }

    }
    void Update()
    {
        coroutinex = MyCoroutine();
        StartCoroutine(coroutinex);
    }
    
    IEnumerator MyCoroutine()
    {
    yield return new WaitForSeconds(intervalx);
    //code here will execute after 5 seconds
    
    }
}
