using Assets.Scripts.Combat.Implements;
using UnityEngine;
using UnityEngine.UI;

public class ReactiveBarView : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private Color _normalColor = Color.white;
    [SerializeField] private Color _perfectColor = Color.yellow;
    [SerializeField] private Color _missColor = Color.red;
    private float _duration;

    public void Show(float duration)
    {
        _duration = duration;
        Debug.Log("Animation showed");
    }

    public void UpdateProgress(float elapsed)
    {
        if (_fillImage == null || _duration <= 0f)
            return;

        float fillAmount = Mathf.Clamp01(elapsed / _duration);
        Debug.Log($"Update progress: {fillAmount}");
    }

    public void ShowResult(TimingResult result)
    {
        if (_fillImage == null)
            return;
        Debug.Log($"Show result: {result}");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
