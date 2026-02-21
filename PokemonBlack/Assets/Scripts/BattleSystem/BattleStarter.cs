using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStarter : MonoBehaviour
{
    public bool inBattle = false;
    private WipeController _wipeController;
    
    void Start()
    {
        _wipeController = FindFirstObjectByType<WipeController>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !inBattle)
        {
            inBattle = true;
            
            if (_wipeController != null)
            {
                // Corrigido: animateIn -> AnimateIn (maiúsculo)
                _wipeController.AnimateIn();
                // Carrega a cena depois de 1 segundo
                Invoke(nameof(LoadBattleScene), 1f);
            }
            else
            {
                LoadBattleScene();
            }
        }
    }
    
    void LoadBattleScene()
    {
        SceneManager.LoadScene("scene_battle");
    }
}