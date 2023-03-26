using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitControl : MonoBehaviour
{
    private Rigidbody rb;  //이동에 사용할 리지드바디 컴포넌트
    public float Playerspeed = 15;   //캐릭터 기본이동속도 (여우랑 이동속도 비슷하게 아니면 조금 빠르거나 느리게??)
    public float eggspeed = 2;   //달걀을 획득했을때 감소할 이동속도
    public float runspeed = 1.2f;   //달리기 버튼을 눌렀을 떄 증가할 이동속도
    public int eggcount = 0;   //현재 먹은 달걀의 갯수

    //private bool hasegg = false;   //달걀 획득 여부 판단
    private bool Running = false;   //달리기 여부 판단
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Update();


        //rigidbody 객체 생성 후 토끼 오브젝트의 Rigidbody컴포넌트
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal"); // 좌우 이동을 위한 입력값
        float moveVertical = Input.GetAxis("Vertical"); // 앞뒤 이동을 위한 입력값


        //달리기 버튼이 눌려졌는지 유무 확인
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Running = false;
        }
        //E키를 누르면 eggcount가 늘어나고 3개이상은 늘어나지 못하게 하면서 플레이어의 이동속도를 eggspeed의 숫자만큼 감소시킨다
       

        //실제 이동 속도를 입력값과 이동 속력을 사용해서 결정
        float xSpeed = moveHorizontal * Playerspeed;
        float zSpeed = moveVertical * Playerspeed;
        //달리기를 하고있을때 이동속도 증가
        if (Running)
        {
            xSpeed *= runspeed;
            zSpeed *= runspeed;
        }



        //Vector3 속도를 (xSpeed, 0f, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        //리지드 바디의 속도에 newVelocity 할당
        rb.velocity = newVelocity;

    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Egg")
        {
            // 충돌한 오브젝트가 알인 경우
            //collision.gameObject.transform.parent = transform; // 알 오브젝트의 부모를 토끼 오브젝트로 변경
            //Destroy(collision.gameObject.GetComponent<SphereCollider>()); // 알 오브젝트의 SphereCollider 컴포넌트 파괴
            //Destroy(collision.gameObject.GetComponent<Rigidbody>()); // 알 오브젝트의 Rigidbody 컴포넌트 파괴
            eggcount++;
            Playerspeed -= eggspeed;

            if (collision.gameObject.CompareTag("Egg") && eggcount >= 3)
            { 
                gameObject.GetComponent<Collider>().enabled = false;
            }

            
        }
    }
}




