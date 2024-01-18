using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer spR;
    void Start()
    {
        spR = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Fade()); 
                }
    }

    IEnumerator Fade()
    {
        for (float i = 1; i > 0f; i-= Time.deltaTime)//������� ���� � ������ ������� �������� ������������� � ������ ����� ��� ������� �� ������ ��������
        {
            spR.color = new Color(1, 0, 0, i);
            yield return null;
        }
    }
}
