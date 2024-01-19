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

    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPos;

    [SerializeField] float timeBtwShoot;
    float shootTimer = 0.5F ; //можем стрелять каждын 0ю5 секунд

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootTimer = timeBtwShoot;
    }

    
    void Update()
    {
        shootTimer += Time.deltaTime;

        PlayerRotation();
        if (Input.GetMouseButtonDown(0) && shootTimer>= timeBtwShoot) { //нажал ли клавишу для выстрела 
            Shoot();
            shootTimer = 0;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    #region BaseFunction
    void Move()
    { 
    Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput.normalized * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
             
    }


    void PlayerRotation()
    {
        Vector2 dir = Camera.main.ScreenToViewportPoint(Input.mousePosition) - transform.position; //находим позицию курсора относительно игры и находим угол между мышь и поворотом игроа
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90; //преобразовывает вектор 2 во флоат и получаем угол
        Quaternion rotatation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotatation, rotationSpeed* Time.deltaTime);
            
    }

    #endregion

    void Shoot()
    {
        Instantiate(bullet, shootPos.position, shootPos.rotation);//пуля принимает вращение игрока во внимание
    }
}
