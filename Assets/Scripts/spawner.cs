using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public static Rigidbody2D mine;
    public GameObject mineOrigonal;
    

    // Start is called before the first frame update
    void Start()
    {
        
        Maker();
    }
    IEnumerator Maker()
    {
        GameObject mineclone = Instantiate(mineOrigonal, this.transform.position, this.transform.rotation);
        mine = mineclone.GetComponent<Rigidbody2D>();
        mine.AddForce(new Vector2(-1, 0));
        Destroy(mine.gameObject, 10f);
        yield return new WaitForSeconds(1f);
    }
    // Update is called once per frame
    void Update()
    {

    }

}
