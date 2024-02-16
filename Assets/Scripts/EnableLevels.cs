using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableLevels : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        int j = 1;
        for (int i = 1; i < buttons.Length; i++) 
        {
            if (!PlayerPrefs.HasKey("LevelAndStarStatus"+i))
            {
                buttons[i].interactable = false;
            }
            else
            {
                buttons[i].interactable = true;
            }
        }
    }
}
