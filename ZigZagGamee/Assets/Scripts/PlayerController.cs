using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 yon = Vector3.left;

    [SerializeField]
    float speed;


    public SpawnerGround groundSpawner;

    //SpawnerGround groundSpawner;
    //private void Awake()
    //{
    //    groundSpawner = GetComponentInChildren<SpawnerGround>();
    //}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (yon.x ==0 ) //z ekseninde hareket ediyor, obje z ekseninde gidiyorsa x'i sıfırdır
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.back;
            }
        }
    }


    private void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime;
        transform.position += hareket;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            YokEt(collision.gameObject); //zemin oluştuktan sonra yok ettik oyuncu zemini terkedince
            groundSpawner.ZeminOlustur(); //ground spawnera eriştik o scripte sonrasında zemin oluştur metodunu çağırdık zemin oluşturuyor rastgele
        }
    }


    void YokEt(GameObject zemin)
    {
        Destroy(zemin);

    }

}//class
