using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_GridStats : MonoBehaviour
{
    private static UI_GridStats instance;
    public TextMeshProUGUI widthText;
    public TextMeshProUGUI heightText;

    /*public event EventHandler<OnGridStatsValueChangedEventArgs> OnGridStatsValueChanged;
    public class OnGridStatsValueChangedEventArgs : EventArgs
    {
        public TextMeshProUGUI textMesh;
        public string text;
    }*/

    private void Awake()
    {
        instance = this;
        /*OnGridStatsValueChanged += (object sender, OnGridStatsValueChangedEventArgs eventArgs) =>
        {
            UIHelper.ChangeTextMeshText(eventArgs.textMesh, eventArgs.text);
        };*/
    }
    public static void ChangeWidthText(string newText)
    {
        UIHelper.ChangeTextMeshText(instance.widthText, newText);
    }

    public static void ChangeHeightText(string newText)
    {
        UIHelper.ChangeTextMeshText(instance.heightText, newText);
    }

   /* private void ValueChange()
    {
        OnGridStatsValueChanged?.Invoke(this, new OnGridStatsValueChangedEventArgs { textMesh = widthText, text =  })
    }*/
}
