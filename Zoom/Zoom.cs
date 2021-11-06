using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Zoom : MonoBehaviour
{
    [SerializeField]private Camera cmera;
    protected float before;
    [SerializeField]protected int scale;
    protected void zoom(float next)
    {

        if (cmera.orthographicSize >= 1.5)
        {
            cmera.orthographicSize = Mathf.Lerp(cmera.orthographicSize, cmera.orthographicSize + (next - before) * scale, Time.deltaTime);
        }else if (cmera.orthographicSize < 1.5)
        {
            cmera.orthographicSize = 1.5f;
        }


    }

    protected abstract float GetNext();

    private void Update()
    {
        zoom(GetNext());
    }
}
