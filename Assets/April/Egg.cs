using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")   // �浹�� ������Ʈ�� �䳢�� ���
        {
            transform.parent = collision.transform; // �� ������Ʈ�� �θ� �浹�� �䳢 ������Ʈ�� ����
            GetComponent<MeshRenderer>().enabled = false; // �� ������Ʈ�� Mesh Renderer ������Ʈ ��Ȱ��ȭ
            Destroy(GetComponent<SphereCollider>()); // �� ������Ʈ�� SphereCollider �ı�
            Destroy(GetComponent<Rigidbody>()); // �� ������Ʈ�� Rigidbody ������Ʈ �ı�
        }
    }
}