using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_InputWindow : MonoBehaviour
{    
    [SerializeField]private Button confirmBtn;
    [SerializeField] private Button cancelBtn;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TMP_InputField textInput;

    private void Start()
    {        
        confirmBtn = transform.Find("ConfirmBtn").GetComponent<Button>();
        cancelBtn = transform.Find("CancelBtn").GetComponent<Button>();
        titleText = transform.Find("Titulo").GetComponent<TextMeshProUGUI>();
        textInput = transform.Find("InputField").GetComponent<TMP_InputField>();

        Hide();
    }

    public void Show(string titleString, string inputString , Action OnCancel, Action<String> OnConfirm)
    {
        gameObject.SetActive(true);

        titleText.text = titleString;
        textInput.text = inputString;

          //cancelBtn.onClick = () => OnConfirm(textInput.text);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
