using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbBullete : MonoBehaviour
{
    [SerializeField] protected GameObject explosion;
    protected Vector2 direction;
    public Vector2 Direction { get => direction; set => direction = value; }

    public float Damage;
    public float Permeability;

    //protected bool shooted;
    //public bool Shooted { get => shooted; set => shooted = value; }
    [SerializeField] protected float Speed;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.GetComponent<enemy>().Health -= Damage;
            Destroy(gameObject);
            //Debug.Log("Damage"+$"{Damage}");
        }else if (collision.tag is"Tower"||collision.tag is"Ground")
        {
            GameObject b = Instantiate(explosion,transform.position,Quaternion.identity);
            b.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject);
        }
        else if (collision.tag == "Player")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.GetComponent<MyPlayer>().Health -= Damage;
            Destroy(gameObject);
        }
    }
}
