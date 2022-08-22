using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioplayer : MonoBehaviour
{
     public AudioClip clip; //make sure you assign an actual clip here in the inspector
    
    // Start is called before the first frame update
    void Awake()
    {
        AudioSource.PlayClipAtPoint(clip, new Vector3(1, 1, 1));
    }

 
 
}



