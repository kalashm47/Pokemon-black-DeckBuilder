using UnityEngine;
using System.Collections;

public class BattleTransition : MonoBehaviour {
    public CanvasGroup fadeGroup;
    public float duration = 1.0f;

    public IEnumerator FadeOut() {
        float elapsed = 0;
        while (elapsed < duration) {
            elapsed += Time.deltaTime;
            fadeGroup.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }
    }

    public IEnumerator FadeIn() {
        float elapsed = 0;
        while (elapsed < duration) {
            elapsed += Time.deltaTime;
            fadeGroup.alpha = Mathf.Clamp01(1 - (elapsed / duration));
            yield return null;
        }
    }
}