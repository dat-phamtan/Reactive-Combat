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

    }

    public void UpdateProgress(float elapsed)
    {

    }

    public void ShowResult(TimingResult result)
    {

    }

    public void Hide()
    {

    }
}
