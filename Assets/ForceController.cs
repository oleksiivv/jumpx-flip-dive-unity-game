using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceController : MonoBehaviour
{
    public Slider powerSlider;

    public JumpController jumpController;

    private float force;

    private bool startIncreaseForce = false;

    void Start()
    {
        force = 0;
    }

    void Update()
    {
        if (jumpController.IsDegreeChosen() && startIncreaseForce && !WinController.won && !LoseController.lose)
        {
            force++;
            powerSlider.value = force;
        }
    }

    public void IncreaseForce()
    {
        startIncreaseForce = true;
    }

    public void OnForceChosen()
    {
        startIncreaseForce = false;
        jumpController.Jump(force);

        force = 0;
        powerSlider.value = force;
    }
}
