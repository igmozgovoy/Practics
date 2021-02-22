using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Второй способ привязать камеру к игроку
// Оба скрипта делают однр и тоже.
public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;  

    void LateUpdate()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
    }
}
