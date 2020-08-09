using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// 과제 버섯을 다먹고 오브젝트도착하면 클리어씬으로
//  버섯을 다먹지 않고 오브젝트 도착시 클리어씬 NO

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator ani;

    const float jumpForce = 500f;
    int shrooms = 6;
    bool gameover = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        transform.position = new Vector3(-99f, -6.4f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover) return;

        
        GameObject.Find("Text").GetComponent<Text>().text = "보석 :" + shrooms;

        if (Input.GetKeyDown(KeyCode.Space)&&rb2d.velocity.y==0)
        {
            rb2d.AddForce(transform.up * jumpForce);
            ani.SetTrigger("JumpTrigger");
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.02f, 0, 0);
            ani.SetTrigger("RunTrigger");
            key = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.02f, 0, 0);
            ani.SetTrigger("RunTrigger");
            key = -1;
        }

        if(key !=0)
        {
            transform.localScale = new Vector3(key * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
            ani.speed = 1f;

        if(transform.position.y < -13f)
        {           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);           
        }        
    }

    public void OnTriggerEnter2D(Collider2D Gem)
    {

        if (Gem.gameObject.CompareTag("Gem"))
        {
            Destroy(GameObject.Find(Gem.name));
            shrooms--;
        }
        if (Gem.gameObject.CompareTag("House"))
        {
            if (shrooms == 0)
            {
                GameObject.Find("GAMETEXT").GetComponent<Text>().text = "GAME CLEAR";
                gameover = false;
                SceneManager.LoadScene(0);
            }
            else
            {
                GameObject.Find("GAMETEXT").GetComponent<Text>().text = "젬을 아직 다 안 모으셨습니다.";
                Invoke("GameMessge", 2f);  
            }
        }

    }

    public void GameMessge()
    {
        GameObject.Find("GAMETEXT").GetComponent<Text>().text = " ";
    }
}
