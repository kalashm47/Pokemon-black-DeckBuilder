using UnityEngine;

public class SyncSpriteCamera : MonoBehaviour
{
    public Camera spriteCamera;
    
    void LateUpdate()
    {
        if(spriteCamera != null)
        {
            spriteCamera.transform.position = transform.position;
            spriteCamera.transform.rotation = transform.rotation;
            spriteCamera.orthographicSize = GetComponent<Camera>().orthographicSize;
        }
    }

}
