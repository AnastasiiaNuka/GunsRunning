using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float deathTime;




    void Start()
    {
        Invoke(nameof(Death), deathTime); //����� ������� ����� �����
    }


    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed); //����������� ����
    }

    private void OnTriggerEnter2D(Collider2D collision) //����� ���������� ���������� � ������ ��������
    {
        if (collision.gameObject.tag == "Wall")
        {
            Death();
         }


    }

        void Death()
        {
            Destroy(gameObject);
        }
    }

