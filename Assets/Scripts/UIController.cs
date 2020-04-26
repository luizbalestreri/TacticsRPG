using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button attack, cancel, wait;

    public void ShowMenu(bool attackBtn, bool cancelBtn, bool waitBtn){
        attack.enabled = attackBtn;
        cancel.enabled = cancelBtn;
        wait.enabled = waitBtn;
    }
}
