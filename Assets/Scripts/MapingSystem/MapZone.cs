using UnityEngine;

public class MapZone : MonoBehaviour
{
    public int TilesHeight;
    public int TilesWidth;


    void OnDrawGizmosSelected()
    {
        Vector3 pos = GetComponent<Transform>().position;
        Vector3 center = new Vector3(pos.x + (TilesWidth / 2), pos.y - (TilesHeight / 2), pos.z);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center,new Vector3(TilesWidth,TilesHeight,0));
    }

}
