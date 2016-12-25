using UnityEngine;
using System.Collections;

public class CancleExitApp : BaseClickButton {
    public override void OnClicked()
    {
        ScreenManager.Instance.HideCurrentPopup();
        base.OnClicked();
    }
}
