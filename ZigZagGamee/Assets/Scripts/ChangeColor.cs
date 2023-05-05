using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color[] colors;

    Color ilkRenk, ikinciRenk;
    int birinciRenk;

    public Material zeminMat;

    // Start is called before the first frame update
    void Start()
    {
        birinciRenk = Random.Range(0,colors.Length);
        zeminMat.color = colors[birinciRenk];

        Camera.main.backgroundColor = colors[birinciRenk];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
