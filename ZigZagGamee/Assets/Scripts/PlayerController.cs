using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 yon = Vector3.left;

    [SerializeField]
    float speed;


    public SpawnerGround groundSpawner;

    public static bool isDead = false;

    public float hizlanmaZorlugu;


   

    //SpawnerGround groundSpawner;
    //private void Awake()
    //{
    //    groundSpawner = GetComponentInChildren<SpawnerGround>();
    //}

    private void Update()
    {
        if (isDead == true )
        {
            return;
        }

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

        if (transform.position.y < 0.4f)
        {
            isDead = true; 
            Debug.Log("öldüm");
            Destroy(this.gameObject, 0.8f);
        }

       
    }


    private void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime;
        speed += Time.deltaTime*hizlanmaZorlugu;
        transform.position += hareket;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            // YokEt(collision.gameObject); //zemin oluştuktan sonra yok ettik oyuncu zemini terkedince
            StartCoroutine(YokEt(collision.gameObject));
            groundSpawner.ZeminOlustur(); //ground spawnera eriştik o scripte sonrasında zemin oluştur metodunu çağırdık zemin oluşturuyor rastgele
        }
    }


    IEnumerator YokEt(GameObject zemin)
    {
        // Destroy(zemin);
        yield return new WaitForSeconds(0.2f);
        zemin.AddComponent<Rigidbody>();

        yield return new WaitForSeconds(0.4f);
        Destroy(zemin);
    }

}//class
