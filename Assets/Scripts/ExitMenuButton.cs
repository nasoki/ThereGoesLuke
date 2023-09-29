using UnityEngine;
using UnityEngine.UI;

public class ExitMenuButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Transform parent = transform.parent;
        if (parent != null)
        {
            parent.gameObject.SetActive(false);
        }
    }
}
