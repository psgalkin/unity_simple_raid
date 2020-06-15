using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUILogic : MonoBehaviour
{
    public Button AttackButton;
    public Button SwitchButton;

    public void SetGameButtonsActive(bool p_isActive)
    {
        AttackButton.interactable = p_isActive;
        SwitchButton.interactable = p_isActive;
    }
}
