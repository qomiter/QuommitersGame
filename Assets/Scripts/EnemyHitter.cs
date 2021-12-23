using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitter : MonoBehaviour
{
    [SerializeField] GameObject enemyExplostion;
    
    
    private void OnCollisionEnter2D(Collision2D other) {
        GameObject holder = Instantiate(enemyExplostion, transform.position, transform.rotation);
        holder.GetComponent<ParticleSystem>().Play();
        Destroy(holder.gameObject, 2f);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
