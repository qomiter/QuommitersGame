using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnDestry : MonoBehaviour
{ 
    public GameObject mineSpawner;
    public GameObject floor;
    private void OnDestroy()
    {
        mineSpawner.gameObject.SetActive(true);
        floor.gameObject.SetActive(true);
    }
}
