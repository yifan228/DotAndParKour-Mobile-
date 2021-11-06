using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject.Find("EnemyBirth").GetComponent<CreateEnemy>().CanCreate = false;
            GameObject[] objs;
            Destroy(collision.gameObject);
            objs =GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject obj in objs)
            {
                obj.GetComponent<enemy>().activate = false;
            }
        }
    }
}
