using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBlock : MonoBehaviour
{
    [SerializeField]private float speed=1;

    public Vector2 direction;

    
    // Start is called before the first frame update
    void Awake()
    {
        //direction.x = Random.Range(0f, 1f);
        //direction.y = Random.Range(0f, 1f);
        //direction = Vector3.Normalize(direction);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction,Time.deltaTime* speed);
        GetComponent<Rigidbody2D>().velocity = direction*speed;
        //Debug.Log(GetComponent<Rigidbody2D>().velocity);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    switch (collision.tag)
    //    {
    //        case "Tower":
    //            direction = Vector3.Normalize(transform.position - collision.transform.position);
    //            break;

    //    }
    //}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"|| collision.gameObject.tag == "Tower")
        {
            //Vector3 newDir;
            ContactPoint2D contactPoint = collision.contacts[0];
            //Vector3 curDir = transform.TransformDirection(Vector3.forward);
            Vector2 curDir = direction;
            direction = Vector3.Reflect(curDir, contactPoint.normal);
            //Debug.Log(direction);
            //Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, newDir);
            //transform.rotation = rotation;
            
        }
       
    }
}
