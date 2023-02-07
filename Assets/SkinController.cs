using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public MeshRenderer[] lifesavers;

    public Material[] skins;

    void Start(){
        foreach(var obj in lifesavers){
            obj.material = skins[PlayerPrefs.GetInt("current")];
        }
    }
}
