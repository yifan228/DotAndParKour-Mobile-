using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField]bool startshake = false;
    [SerializeField]AnimationCurve curve;
    [SerializeField] float duration;

    private void Update()
    {
        if(startshake)
            StartCoroutine(Shaking());
    }

    public void Shake()
    {
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking()
    {
        startshake = false;
        Vector3 StartPos = transform.position;
        float t0 = 0;
        while (t0 < duration)
        {
            t0 += Time.deltaTime;
            float strength = curve.Evaluate(t0 / duration);
            transform.position = StartPos + Random.insideUnitSphere;
            yield return null;
        }
        transform.position = StartPos;
    }
}
