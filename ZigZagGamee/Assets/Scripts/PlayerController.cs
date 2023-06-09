using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Out Component")]
    [SerializeField] float speed;
    [SerializeField] Text scoreText, bestScoreText;
    [SerializeField] GameObject restartPanel,playGamePanel;

    [Header("Public Variable")]
    public SpawnerGround groundSpawner;
    public static bool isDead = true;
    public float hizlanmaZorlugu;

    
    
    Vector3 yon = Vector3.left;
    int bestScore = 0;
    float score = 0f;
    float artisMiktari=1f;


    

    //SpawnerGround groundSpawner;
    //private void Awake()
    //{
    //    groundSpawner = GetComponentInChildren<SpawnerGround>();
    //}

    private void Start()
    {
        if (RestartGame.isRestart)
        {
            isDead = false;
            playGamePanel.SetActive(false);
        }

        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best: " + bestScore;
    }

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
            if (bestScore <score)
            {
                bestScore = (int)score;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
            Debug.Log("öldüm");
            restartPanel.SetActive(true);
            Destroy(this.gameObject, 3f);
        }
    }


    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        Vector3 hareket = yon * speed * Time.deltaTime;
        speed += Time.deltaTime*hizlanmaZorlugu;
        transform.position += hareket;

        score += artisMiktari * speed * Time.deltaTime;   
        scoreText.text = "Score : "+ ((int)score).ToString();

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


    public void PlayGame()
    {
        isDead = false;
        playGamePanel.SetActive(false);
    }



}//class
