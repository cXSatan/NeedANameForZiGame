using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement; // tirar isto daqui isto é para o gamemanager scenemanager o que quiseres chamar

public class PlayerController : MonoBehaviour {

    public int speed = 10;
    public int jump = 30;
    public int hp = 5;
    public float stamina = 100f;
    public Rigidbody2D playerRb;
    public Animator playerAnim;
    // Use this for initialization
    int rotate;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        rotate = 1;
    }

    private void FixedUpdate() //tudo o que for com fisica e aqui relativamente ao playa
    {
       playerAnim.SetBool("IsRunning", false);
       

        if (Input.GetKey("right")) {

            if (rotate == 0)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                rotate = 1;
            }
           playerAnim.SetBool("IsRunning", true);
            playerRb.AddForce(new Vector2(speed, 0));
        }


        if (Input.GetKey("left")) {
            
            if (rotate == 1) { 
                transform.Rotate(new Vector3 (0,-180,0));
                rotate = 0;
            }
            playerRb.AddForce(new Vector2(-speed, 0));
            playerAnim.SetBool("IsRunning", true);
        }


        if (Input.GetKey(KeyCode.Space)) {
            playerAnim.SetBool("IsRunning", false);
            playerRb.AddForce(new Vector2(0, jump * Time.deltaTime),ForceMode2D.Impulse);



        }

        

    }

}
