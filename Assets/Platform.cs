using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    int dir=1;
    public float speed=1.5f;

    public float rotateDelayCoef = 1;

    public bool changeY = false;

    private void Start() {
        StartCoroutine(ChangeDir());
    }
    
    private void Update() {
        transform.Rotate(speed*dir*Time.timeScale, 0, 0);

        if(changeY){
            transform.Translate(Time.timeScale*Vector3.up*speed*dir/13);
        }
    }

    IEnumerator ChangeDir()
    {
        while(true){
            yield return new WaitForSeconds(Random.Range(0.2f, 0.4f)*rotateDelayCoef);
            dir*=-1;
        }
    }

    private GameObject player;

    private bool alreadyLeft = false;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag.ToLower().Equals("player") && !alreadyLeft){
            player = other.gameObject;
            player.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag.ToLower().Equals("player") && player != null){
            player.gameObject.transform.parent = null;
            alreadyLeft=true;
        }
    }
}
