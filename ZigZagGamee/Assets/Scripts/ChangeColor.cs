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
        ikinciRenk = colors[IkinciRenkSec()];
        zeminMat.color = colors[birinciRenk];

        Camera.main.backgroundColor = colors[birinciRenk];
    }

    // Update is called once per frame
    void Update()
    {
        Color fark = zeminMat.color - ikinciRenk; //  renklerin rgb değerleri çıkarılabiliyor

        if (Mathf.Abs(fark.r) + Mathf.Abs(fark.g) +Mathf.Abs(fark.b) <0.2f  )
        {
            ikinciRenk = colors[IkinciRenkSec()];
        }
        zeminMat.color = Color.Lerp(zeminMat.color,ikinciRenk,0.0003f); // burda farklı olan renklerden zemin rengni yani birinci rengi ikinci renge dönüştürüyor arada 0.2f lik fark kalmışken yani tam aynı renge gelmekteyken yeni renk oluşturuyorsun if in içinde
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor,ikinciRenk,0.0007f); // 

    }


    int IkinciRenkSec()
    {
        int ikinciRenkIndex;
        ikinciRenkIndex = Random.Range(0, colors.Length);

        while (ikinciRenkIndex == birinciRenk)
        {
            ikinciRenkIndex = Random.Range(0, colors.Length);
        }


        return ikinciRenkIndex;
    }


}
