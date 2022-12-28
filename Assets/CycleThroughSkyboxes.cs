using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleThroughSkyboxes : MonoBehaviour
{
    public Material morning;
    public Material day;
    public Material evening;
    public Material night;
    public Material dawn;

    private Material[] materials = new Material[5];
    private int pos = 2; //starts cycle at evening
    void Start()
    {
        materials[0] = morning;
        materials[1] = day;
        materials[2] = evening;
        materials[3] = night;
        materials[4] = dawn;

    }
    public void CycleSkybox()
    {
        RenderSettings.skybox = materials[pos++];
        pos %= 5;
    }
}
