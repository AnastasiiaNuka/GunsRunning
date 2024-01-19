using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] float minX, maxX, minY, maxY;
    [SerializeField] Transform target;//за ним следует камера

    [SerializeField] float followSpeed;

    void FixedUpdate()
    {
        if (!target) return;// если таргета нет то не выполняем
       
        transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(target.position.x, minX, maxX), Mathf.Clamp(target.position.y, minY, maxY), -10), followSpeed * Time.fixedDeltaTime);
        //transform.position = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), Mathf.Clamp(target.position.y, minY, maxY), -10);//камера позади всех обьектов и все были в сцене
        //линейная интерпалаяция плавное значение от позиции камера и игрока в заданных промежутках и скорость чтоб на разных устройствах одна скорость

    }
}
