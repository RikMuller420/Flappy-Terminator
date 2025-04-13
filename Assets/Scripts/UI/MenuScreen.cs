using UnityEngine;
using UnityEngine.UI;

public abstract class MenuScreen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup WindowGroup;
    [SerializeField] protected Button Button;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }

    public void Open()
    {
        WindowGroup.alpha = 1f;
        WindowGroup.blocksRaycasts = true;
    }

    public void Close()
    {
        WindowGroup.alpha = 0f;
        WindowGroup.blocksRaycasts = false;
    }

    protected abstract void OnButtonClick();
}

