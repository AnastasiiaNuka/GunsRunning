using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] float minX, maxX, minY, maxY;
    [SerializeField] Transform target;

    void Update()
    {
     
        transform.position = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), Mathf.Clamp(target.position.y, minY, maxY), -10);//камера позади всех обьектов и все были в сцене
    }
}
