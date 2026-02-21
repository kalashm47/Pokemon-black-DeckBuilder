using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class CameraFlow : MonoBehaviour
{
    [Header("Target")]
    public Transform target; // Arraste o Player aqui
    
    [Header("Camera Settings")]
    public float distance = 6f;      // Distância do alvo
    public float height = 2.5f;      // Altura da câmera
    public float angle = 30f;        // Ângulo de inclinação
    
    [Header("Smooth")]
    public float smoothSpeed = 5f;
    
    [Header("Target Offset")]
    public Vector3 targetOffset = new Vector3(0, 1f, 0); // Olha para o meio do personagem
    
    private Vector3 velocity = Vector3.zero;
    private Vector3 lastTargetPosition;
    private bool hasLastPosition = false;
    
    void Start()
    {
        if (target != null)
        {
            lastTargetPosition = target.position;
            hasLastPosition = true;
            
            // Posiciona a câmera imediatamente na posição correta no começo
            Vector3 targetPos = target.position + targetOffset;
            Vector3 desiredPosition = targetPos;
            desiredPosition += -transform.forward * distance;
            desiredPosition += Vector3.up * height;
            
            transform.position = desiredPosition;
            transform.rotation = Quaternion.Euler(angle, 0, 0);
        }
    }
    
    void LateUpdate()
    {
        if (target == null) return;
        
        // VERIFICA SE O PLAYER ESTÁ REALMENTE SE MOVENDO
        float moveDelta = 0f;
        if (hasLastPosition)
        {
            moveDelta = Vector3.Distance(target.position, lastTargetPosition);
        }
        
        // SÓ move a câmera se o player se moveu mais que 0.01 unidades
        if (moveDelta > 0.01f || !hasLastPosition)
        {
            // Pega a posição do player e adiciona offset para mirar no centro
            Vector3 targetPosition = target.position + targetOffset;
            
            // Calcula a posição desejada da câmera
            Vector3 desiredPosition = targetPosition;
            desiredPosition += -transform.forward * distance;
            desiredPosition += Vector3.up * height;
            
            // MANTÉM A ROTAÇÃO FIXA
            transform.rotation = Quaternion.Euler(angle, 0, 0);
            
            // APLICA A POSIÇÃO DIRETAMENTE (sem smooth para teste)
            transform.position = desiredPosition;
            
            // Se quiser smooth, use isto em vez da linha acima:
            // transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
            
            // Atualiza última posição
            lastTargetPosition = target.position;
            hasLastPosition = true;
        }
    }
    
    // Visualização no editor
    void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = Color.red;
            Vector3 targetPoint = target.position + targetOffset;
            Gizmos.DrawSphere(targetPoint, 0.2f);
            Gizmos.DrawLine(targetPoint, transform.position);
        }
    }
}
