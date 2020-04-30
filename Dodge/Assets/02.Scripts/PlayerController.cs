using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ///////////////////////////////////////////////////////
        //if (Input.GetKey(KeyCode.UpArrow) == true)
        //{
        //    //위쪽 방향키 입력이 감지된 경우 Z방향힘 주기
        //    playerRigidbody.AddForce(0f, 0f, speed);
        //}

        //if (Input.GetKey(KeyCode.DownArrow) == true)
        //{
        //    //위쪽 방향키 입력이 감지된 경우 Z방향힘 주기
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}

        //if (Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    //위쪽 방향키 입력이 감지된 경우 Z방향힘 주기
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    //위쪽 방향키 입력이 감지된 경우 Z방향힘 주기
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}
        ////////////////////////////////////////////////////////

        //수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동속도를 입력값과 이동속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //벡터 속도를 xSpeed 0 zSpeed로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        //리지드바디의 속도에 newVellocity 할당
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);

        //씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        //가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();
    }
}
