using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atis : MonoBehaviour
{
    public Rigidbody2D rb;
    public float shot = 0.12f;
    public bool ispressed = false;
    public GameObject hook;
    public Rigidbody2D hookk;
    public float maxDragDistance = 5f;

    public GameObject rock;
    public int RockHealth = 20;
    public GameObject Wood;



    [Header("Instantiate Ball")]
    public GameObject Ball;
    void Update()
    {
        if (ispressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hookk.position) > maxDragDistance)
            {
                rb.position = hookk.position + (mousePos - hookk.position).normalized * maxDragDistance;
            }
            else
            {
                rb.position = mousePos;
            }
        }
    }

    private void OnMouseDown()
    {
        ispressed = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        ispressed = false;
        rb.isKinematic = false;
        StartCoroutine(releaseTime());
        GetComponent<Atis>().enabled = false;
    }

    IEnumerator releaseTime()
    {
        yield return new WaitForSeconds(shot);
        GetComponent<SpringJoint2D>().enabled = false;
        Invoke("CreateBall", 1);
    }
    void CreateBall()
    {
        GameObject ball = Instantiate(Ball, hook.transform.position, Quaternion.identity);
        ball.GetComponent<SpringJoint2D>().enabled = true;
        ball.GetComponent<SpringJoint2D>().connectedBody = hookk;
        ball.GetComponent<Atis>().enabled = true;


    }

}
