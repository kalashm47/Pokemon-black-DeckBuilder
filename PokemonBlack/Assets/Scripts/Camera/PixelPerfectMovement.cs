using UnityEngine;

public class PixelPerfectMovement : MonoBehaviour
{
    public float speed = 3f; // Velocidade em unidades por segundo
    private float pixelUnit = 1f / 16f; // 0.0625 (PPU 16)

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        if (moveX != 0 || moveY != 0)
        {
            // Move em múltiplos de pixelUnit
            Vector3 movement = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
            
            // Arredonda para o pixel mais próximo
            movement.x = Mathf.Round(movement.x / pixelUnit) * pixelUnit;
            movement.y = Mathf.Round(movement.y / pixelUnit) * pixelUnit;
            
            transform.position += movement;
        }
    }

     void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Round(pos.x / pixelUnit) * pixelUnit;
        pos.y = Mathf.Round(pos.y / pixelUnit) * pixelUnit;
        transform.position = pos;
    }
}
