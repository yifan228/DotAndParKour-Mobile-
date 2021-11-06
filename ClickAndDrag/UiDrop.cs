using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<UIDrag>() != null)
        {
            collision.GetComponent<UIDrag>().inUI = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<UIDrag>() != null)
        {
            collision.GetComponent<UIDrag>().inUI = false;
        }
    }
}
