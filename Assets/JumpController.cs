using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpController : MonoBehaviour
{
    public Character character;

    public ArrowRotation arrowRotation;

    private float degree;

    public ForceController forceController;

    private float force;

    private bool degreeChosen = false;

    void Start()
    {
        force = 0;

        character.rigidbody.freezeRotation = true;
    }
    
    public void ChooseDegre()
    {
        if (degreeChosen) return;

        degree = arrowRotation.GetCurrentRotation();
        degreeChosen = true;

        arrowRotation.StopAllCoroutinesCall();
    }

    public void Jump(float force)
    {
        character.gameObject.transform.parent = null;
        character.rigidbody.freezeRotation = false;
        if (!degreeChosen) return;

        StartCoroutine(RotateTowards(degree-90));

        var degreeForce = ((180 - degree) / 30) == 0 ? 1 : ((180 - degree) / 30);

        character.rigidbody.AddForce(Vector3.forward * force * degreeForce * 1.5f);
        character.rigidbody.AddForce(Vector3.up * force * 3);

        if(degree < 150 && degree > 80){
            character.rigidbody.AddTorque(transform.right * force / 5);
        }

        //StartCoroutine(RotateTowards(degree - 90));

        degreeChosen = false;
    }

    IEnumerator RotateTowards(float degree)
    {
        while(true)
        {
            //degree - 90, character.gameObject.transform.eulerAngles.y, character.gameObject.transform.eulerAngles.z

            if(!WinController.won && !LoseController.lose){
                character.gameObject.transform.eulerAngles += new Vector3(1f, 0, 0);

                //Debug.Log(character.gameObject.transform.eulerAngles.z);
            }

            if(Mathf.Abs(Mathf.Abs(character.gameObject.transform.eulerAngles.z) - degree) < 2f)
            {
                break;
            }

            yield return new WaitForSeconds(0.001f);
        }
    }

    public bool IsDegreeChosen()
    {
        return this.degreeChosen;
    }
}
