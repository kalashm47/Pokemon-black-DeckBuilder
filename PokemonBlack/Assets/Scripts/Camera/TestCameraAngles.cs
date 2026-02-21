using UnityEngine;

public class TestCameraAngles : MonoBehaviour
{
    [Range(20, 60)]
    public float angle = 35f;
    
    [Range(4, 12)]
    public float distance = 8f;
    
    [Range(2, 8)]
    public float height = 4f;
    
    void Update()
    {
        // Aplica ângulo em tempo real (só para teste)
        transform.rotation = Quaternion.Euler(angle, 0, 0);
    }
}