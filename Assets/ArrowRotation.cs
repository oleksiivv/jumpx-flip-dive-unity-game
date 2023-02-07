using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    public GameObject arrow;

    public float startRotation, endRotation;

    private int dir = 1;

    private float currentRotationZ;

    public float eps = 0.0001f;

    public float speed = 1f;

    void Start()
    {
        currentRotationZ = arrow.transform.eulerAngles.z;

        StartCoroutine(StartRotation());
    }

    IEnumerator StartRotation()
    {
        while (true)
        {
            currentRotationZ += 0.5f * dir * speed;

            //Debug.Log(Mathf.Abs(currentRotationZ - startRotation) < eps || Mathf.Abs(currentRotationZ - endRotation) < eps);

//Debug.Log(Mathf.Abs(currentRotationZ - endRotation));
            if (Mathf.Abs(currentRotationZ - startRotation) < eps || Mathf.Abs(currentRotationZ - endRotation) < eps)
            {
                dir *= -1;
            }

            arrow.transform.eulerAngles = new Vector3(arrow.transform.eulerAngles.x, arrow.transform.eulerAngles.y, currentRotationZ);

            yield return new WaitForSeconds(0.001f);
        }
    }

    public void StopAllCoroutinesCall()
    {
        StopAllCoroutines();
    }

    public float GetCurrentRotation()
    {
        return this.currentRotationZ;
    }
}
