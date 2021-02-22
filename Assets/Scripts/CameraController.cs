using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Первый способ привязкать камеру к игроку
public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;  // Объект player
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Все настройки камеры должны использоваться здесь
    // Late вызывается после update
    void LateUpdate()
    {
        //transform.position = playerController.transform.position;       //  Позиция камеры = позиция игрока // копирует вместе с осью z
        transform.position = new Vector3(playerController.transform.position.x, playerController.transform.position.y, transform.position.z);


    }
}
