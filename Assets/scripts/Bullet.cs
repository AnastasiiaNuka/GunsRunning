using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed; 




    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(Vector3.right* Time.deltaTime*speed); //перемещение пули
    }
}
