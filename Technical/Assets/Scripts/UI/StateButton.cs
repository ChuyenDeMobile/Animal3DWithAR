using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StateButton : MonoSingleton<StateButton> {
    public Button m_btnZoomIn;
    public Button m_btnZoomOut;
    public Button m_btnSpeak;

    public void DisableButton()
    {
        m_btnSpeak.interactable = false;
        m_btnZoomIn.interactable = false;
        m_btnZoomOut.interactable = false;
    }
    public void EnableButton()
    {
        m_btnSpeak.interactable = true;
        m_btnZoomIn.interactable = true;
        m_btnZoomOut.interactable = true;
    }
}
