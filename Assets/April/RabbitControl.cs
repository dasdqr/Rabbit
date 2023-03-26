using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitControl : MonoBehaviour
{
    private Rigidbody rb;  //�̵��� ����� ������ٵ� ������Ʈ
    public float Playerspeed = 15;   //ĳ���� �⺻�̵��ӵ� (����� �̵��ӵ� ����ϰ� �ƴϸ� ���� �����ų� ������??)
    public float eggspeed = 2;   //�ް��� ȹ�������� ������ �̵��ӵ�
    public float runspeed = 1.2f;   //�޸��� ��ư�� ������ �� ������ �̵��ӵ�
    public int eggcount = 0;   //���� ���� �ް��� ����

    //private bool hasegg = false;   //�ް� ȹ�� ���� �Ǵ�
    private bool Running = false;   //�޸��� ���� �Ǵ�
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Update();


        //rigidbody ��ü ���� �� �䳢 ������Ʈ�� Rigidbody������Ʈ
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal"); // �¿� �̵��� ���� �Է°�
        float moveVertical = Input.GetAxis("Vertical"); // �յ� �̵��� ���� �Է°�


        //�޸��� ��ư�� ���������� ���� Ȯ��
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Running = false;
        }
        //EŰ�� ������ eggcount�� �þ�� 3���̻��� �þ�� ���ϰ� �ϸ鼭 �÷��̾��� �̵��ӵ��� eggspeed�� ���ڸ�ŭ ���ҽ�Ų��
       

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����ؼ� ����
        float xSpeed = moveHorizontal * Playerspeed;
        float zSpeed = moveVertical * Playerspeed;
        //�޸��⸦ �ϰ������� �̵��ӵ� ����
        if (Running)
        {
            xSpeed *= runspeed;
            zSpeed *= runspeed;
        }



        //Vector3 �ӵ��� (xSpeed, 0f, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        //������ �ٵ��� �ӵ��� newVelocity �Ҵ�
        rb.velocity = newVelocity;

    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Egg")
        {
            // �浹�� ������Ʈ�� ���� ���
            //collision.gameObject.transform.parent = transform; // �� ������Ʈ�� �θ� �䳢 ������Ʈ�� ����
            //Destroy(collision.gameObject.GetComponent<SphereCollider>()); // �� ������Ʈ�� SphereCollider ������Ʈ �ı�
            //Destroy(collision.gameObject.GetComponent<Rigidbody>()); // �� ������Ʈ�� Rigidbody ������Ʈ �ı�
            eggcount++;
            Playerspeed -= eggspeed;

            if (collision.gameObject.CompareTag("Egg") && eggcount >= 3)
            { 
                gameObject.GetComponent<Collider>().enabled = false;
            }

            
        }
    }
}




