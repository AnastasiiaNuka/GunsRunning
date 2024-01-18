using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    Rigidbody2D rb;
    Vector2 moveVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        PlayerRotation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    { 
    Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput.normalized * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
             
    }


    void PlayerRotation()
    {
        Vector2 dir = Camera.main.ScreenToViewportPoint(Input.mousePosition) - transform.position; //находим позицию курсора относительно игры и находим угол между мышь и поворотом игроа
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + 90; //преобразовывает вектор 2 во флоат и получаем угол
        Quaternion rotatation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotatation, rotationSpeed* Time.deltaTime);
            
    }
}
