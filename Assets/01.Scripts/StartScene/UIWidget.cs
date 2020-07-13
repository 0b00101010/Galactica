using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWidget : MonoBehaviour
{
    public virtual void OpenWidget() { }
    public virtual void OpenWidget(Action action) { }
    public virtual void CloseWidget() { }
    public virtual void CloseWidget(Action action) { }
}
