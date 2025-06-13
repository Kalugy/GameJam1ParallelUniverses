using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


[RequireComponent(typeof(TMP_Text))]
public class TypeWriter : MonoBehaviour
{
    private TMP_Text textBox;
    
    [Header("Test string")]
    [SerializeField] private string testText;

    private int _currentVisibleCharacterIndex;

    private Coroutine typewriterCoroutine;

    private WaitForSeconds simpleDelay;
    private WaitForSeconds _interpuntuationDelay;

    [Header("Typewriter Settings")] 
    [SerializeField] private float characterPerSecond = 20;
    [SerializeField] private float interpuntuationDelay = 0.5f;


    private void Awake()
    {
        textBox = GetComponent<TMP_Text>();
        simpleDelay = new WaitForSeconds(1 / characterPerSecond);
        _interpuntuationDelay = new WaitForSeconds(interpuntuationDelay);
    }

    private void Start()
    {
        hudControlller.instance.isUiOpen = true;
        SetText(testText);
    }

    public void SetText(string text)
    {
        if(typewriterCoroutine != null)
            StopCoroutine(typewriterCoroutine);
        
        textBox.text = text;
        textBox.maxVisibleCharacters = 0;
        _currentVisibleCharacterIndex = 0;

        typewriterCoroutine = StartCoroutine(Typewiter());

    }

    IEnumerator Typewiter()
    {
        TMP_TextInfo  textInfo = textBox.textInfo;

        while (_currentVisibleCharacterIndex < textInfo.characterCount +1)
        {
            if (_currentVisibleCharacterIndex >= textInfo.characterInfo.Length)
                break;
            
            char character = textInfo.characterInfo[_currentVisibleCharacterIndex].character;

            textBox.maxVisibleCharacters++;
            if (character == '?' || character == '.' || character==',' || character ==':' || character ==';'
                || character == '!' || character == '-')
            {
                yield return _interpuntuationDelay;
            }
            else
            {
                yield return simpleDelay;
            }

            _currentVisibleCharacterIndex++;
        }

        hudControlller.instance.isUiOpen = false;
        hudControlller.instance.CloseBackground();
        gameObject.SetActive(false);


    }
    
}
