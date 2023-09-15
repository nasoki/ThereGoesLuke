using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public GameObject character;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(MoveCharacter);
    }

    private void MoveCharacter()
    {
        // Trigger character movement when the button is clicked
        character.GetComponent<CharacterMovement>().enabled = true;
    }
}
