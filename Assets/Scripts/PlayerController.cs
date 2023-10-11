using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static float speed = 8f;
    private float prev_speed;

    private float screenWidth;
    private float addSpeed;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        //Gépi irányítás
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -1.5f)
            transform.position += Vector3.left * 1f;
            
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 1.5f)
            transform.position += Vector3.right * 1f;
            

        //Mobile controls
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).position.x < screenWidth / 2f && Input.GetTouch(i).phase == TouchPhase.Ended && transform.position.x > -1.5f)
                transform.position -= Vector3.right * 1f;
            if (Input.GetTouch(i).position.x > screenWidth / 2f && Input.GetTouch(i).phase == TouchPhase.Ended && transform.position.x < 1.5f)
                transform.position += Vector3.right * 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Transform>().tag == "Obstacle")
        {
            
            Destroy(other.gameObject);  

            if (GetComponent<Renderer>().material.color != other.GetComponent<Renderer>().material.color)
            {
                if (speed > 8) speed /= 1.5f;

                prev_speed = speed;
            }
            StartCoroutine(gameEnd());
        }
    }
    IEnumerator gameEnd(){
        speed = 0;
        yield return new WaitForSeconds(3);
        speed = prev_speed;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("SampleScene");
    }
}