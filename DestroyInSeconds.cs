using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField] float t;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, t);
    }

}
