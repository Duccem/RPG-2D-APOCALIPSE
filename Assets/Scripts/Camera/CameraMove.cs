using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    
    public GameObject player; //Player reference to follow him
    public GameObject initialMap; // Initial map reference to set bounds to the camera movement

    float limitTopLeftX, limitTopLeftY, limitBottomRightX, limitBottomRightY; //Limits on the axis
    Vector2 velocity;
    void Awake()
    {
        setBounds(initialMap);
    }

    void FixedUpdate()
    {
        //Calculo para el suavizado de la camara
        float posX = Mathf.Round(Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, 0.5f) * 100)  / 100;
        float posY = Mathf.Round(Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, 0.5f) * 100) / 100;

        //Movimiento de la camara limitado en fronteras ya definidas
        transform.position = new Vector3(Mathf.Clamp(posX, limitTopLeftX, limitBottomRightX),
                                         Mathf.Clamp(posY, limitBottomRightY, limitTopLeftY),
                                         transform.position.z);
    }

    public void setBounds(GameObject targetMap)
    {
        float ratio = (float)Screen.width / (float)Screen.height;
        float ajuste = 0f ;
        if (ratio  >= 1.7f)
        {
            ajuste = 1.5f;
        }
        else if (ratio == 1.6f)
        {
            ajuste = 0.5f;
        } 
        MapZone mapa = targetMap.GetComponent<MapZone>();
        Transform pos = targetMap.GetComponent<Transform>();
        limitTopLeftX = pos.position.x + (Camera.main.orthographicSize + (Camera.main.orthographicSize / 2) + ajuste);
        limitTopLeftY = pos.position.y - Camera.main.orthographicSize ;
        limitBottomRightX = pos.position.x + mapa.TilesWidth -  (Camera.main.orthographicSize + (Camera.main.orthographicSize / 2) + ajuste);
        limitBottomRightY = pos.position.y - mapa.TilesHeight + Camera.main.orthographicSize;
    }
}
