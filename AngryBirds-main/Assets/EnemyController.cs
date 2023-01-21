using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Health = 20;
    private void Update()
    {
        if (Health <=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.relativeVelocity.magnitude > 30)
            {
                Health -= 10;
                return;
            }
            if (collision.relativeVelocity.magnitude > 20)
            {
                Health -= 5;
            }
        }
        

        
    }
}
