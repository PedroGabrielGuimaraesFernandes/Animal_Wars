using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using CodeMonkey;

public class UI_InputWindow : MonoBehaviour
{
    private static UI_InputWindow instance;

    [SerializeField]private Button_UI confirmBtn;
    [SerializeField] private Button_UI cancelBtn;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TMP_InputField textInput;

    public static String Letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
    public static String LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
    public static String HigherCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static String Numbers = "0123456789";

    private void Start()
    {
        instance = this;

        confirmBtn = transform.Find("ConfirmBtn").GetComponent<Button_UI>();
        cancelBtn = transform.Find("CancelBtn").GetComponent<Button_UI>();
        titleText = transform.Find("Titulo").GetComponent<TextMeshProUGUI>();
        textInput = transform.Find("InputField").GetComponent<TMP_InputField>();

        Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            confirmBtn.ClickFunc();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cancelBtn.ClickFunc();
        }
    }

    private  void Show(string titleString, string inputString, string validCharacters, int characterLimit, Action OnCancel, Action<String> OnConfirm)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        textInput.text = inputString;
        textInput.Select();
        textInput.characterLimit = characterLimit;

        titleText.text = titleString;

        textInput.onValidateInput = (string text, int charIndex, char addedChar) => { return ValidadeChar(validCharacters, addedChar); };

        confirmBtn.ClickFunc = () => {
            Hide();
            OnConfirm(textInput.text);
        };

        cancelBtn.ClickFunc = () =>
        {
            Hide();
            OnCancel();
        };
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private char ValidadeChar(string validCharacters, char addedChar)
    {
        if (validCharacters.IndexOf(addedChar) != -1)
            return addedChar;// valido
        else
            return '\0';//Invalido  
    }

    public static void Show_Static(string titleString, string inputString, string validCharacters, int characterLimit, Action OnCancel, Action<String> OnConfirm)
    {
        instance.Show(titleString, inputString, validCharacters, characterLimit, OnCancel, OnConfirm);
    }


    public static void Show_Static(string titleString, int defaultInt, Action onCancel, Action<int> onConfirm)
    {
        instance.Show(titleString, defaultInt.ToString(), Numbers, 20, onCancel,
            (string inputText) =>
            {
                //Try to parse the inputText(String => int)
                if (int.TryParse(inputText, out int _i))
                {
                    onConfirm(_i);
                }
                else
                {
                    onConfirm(defaultInt);
                }

            });
    }
}
