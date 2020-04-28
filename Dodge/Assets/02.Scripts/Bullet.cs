using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;//탄알속력
    private Rigidbody bulletRigidbody;//이동에 사용할 리지드 바디 컴포넌트 

    // Start is called before the first frame update
    void Start()
    {
        //게임오브젝트에서 rigidbody 컴포넌트를 찾아 bulletrigidbody에 할당 
        bulletRigidbody = GetComponent<Rigidbody>();
        //리직드바디의 속도 = 앞쪽방향*이동속력 
        bulletRigidbody.velocity = transform.forward * speed;

        //3초뒤에 자신의 게임오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    //트리거 충돌시 자동으로 실행되는 메서드
    void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임오브젝트가 player태그를 가진경우
        if (other.tag == "Player")
        {
            //상대방 게임오브젝트에서 playercontroller 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            //상대방으로부터 playercontroller 컴포넌트를 가져오는데 성공했다면
            if (playerController != null)
            {
                //상대방 플레이어 컨트롤러 컴포넌트의 Die메서드 실행
                playerController.Die();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
