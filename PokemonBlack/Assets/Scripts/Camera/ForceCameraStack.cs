using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ForceCameraStack : MonoBehaviour
{
    public Camera spriteCamera; // Arraste a SpriteCamera aqui
    
    void Start()
    {
        // Pega a câmera principal
        Camera mainCam = GetComponent<Camera>();
        Camera overlayCam = spriteCamera;
        
        if (mainCam != null && overlayCam != null)
        {
            // Tenta adicionar ao stack via código
            var mainCamData = mainCam.GetComponent<UniversalAdditionalCameraData>();
            var overlayCamData = overlayCam.GetComponent<UniversalAdditionalCameraData>();
            
            if (mainCamData != null && overlayCamData != null)
            {
                // Configura overlay
                overlayCamData.renderType = CameraRenderType.Overlay;
                
                // Adiciona ao stack da main
                mainCamData.cameraStack.Add(overlayCam);
            }
            else
            {
                Debug.LogError("❌ Componente UniversalAdditionalCameraData não encontrado!");
            }
        }
    }
}