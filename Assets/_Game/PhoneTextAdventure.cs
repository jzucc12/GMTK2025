using System;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PhoneTextAdventure : MonoBehaviour 
{
	[Header("Ink stuff")]
    [SerializeField] private TextAsset inkJSONAsset = null;

	[Header("Prefabs")]
	[SerializeField] private Transform textContainer = null;
    [SerializeField] private GameObject AITextPrefab = null;
    [SerializeField] private GameObject playerTextPrefab = null;

    [Header("Other Stuff")]
    [SerializeField] private GameObject callContainer;
    [SerializeField] private float textPopDelay;
    [SerializeField] private Color[] bubbleColors;
    private Queue<TextData> texts = new();
    
	[Header("Number Input")]
	[SerializeField] private GameObject numberInputContainer;
    [SerializeField] private CharacterButton[] phoneButtons = null;

	[Header("Text Input")]
	[SerializeField] private GameObject textInputContainer;
    [SerializeField] private TMP_InputField textInputField;
    private bool inTextInput;

    [Header("End Game")]
    [SerializeField] private GameObject endGameContainer;

    public static event Action<Story> OnCreateStory;
    public Story story;
    private bool queueRunning => running != null && !running.IsCompleted;
    Awaitable running;


    private void Update()
    {
        if(inTextInput && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
        {
            SubmitText();
        }
    }

    #region Set Up
    private void Start()
    {
        for(int ii = 0; ii < phoneButtons.Length; ii++)
        {
			int value = ii;
			phoneButtons[ii].MyButton.onClick.AddListener(() => OnClickChoiceButton(value));
        }
    }

    private void OnEnable()
    {
        if(inTextInput)
        {
            FocusInputField();
        }
    }
    
    public void PlaceCall() 
    {
        callContainer.SetActive(false);
        StartStory(inkJSONAsset);
    }

    private void StartStory(TextAsset newStory) 
	{
		story = new Story (newStory.text);
        story.BindExternalFunction("get_Text", GetTextInput);
        if (OnCreateStory != null) OnCreateStory(story);
		RefreshView();
	}

    private void RefreshView() 
	{
        while (story.canContinue)
        {
            string text = story.Continue().Trim();
			AddTextToStack(text, AITextPrefab, true, int.Parse(story.variablesState.GetVariableWithName("speaker_Number").ToString()));
		}

        SetUpTextInputScreen(story.variablesState.GetVariableWithName("useText").ToString() == "true");

        if (story.currentChoices.Count == 0) 
		{
            callContainer.SetActive(false);
            textInputContainer.SetActive(false);
            numberInputContainer.SetActive(false);
            endGameContainer.SetActive(true);
		}
    }

    private void AddTextToStack(string text, GameObject textPrefab, bool delay, int speakerNo)
    {
        if(!delay)
        {
            texts.Clear();
            running.Cancel();
            running = null;
        }
        texts.Enqueue(new TextData(text, textPrefab, delay, speakerNo));
        if (!queueRunning)
        {
            running = DisplayAllTexts();
        }
    }

    private async Awaitable DisplayAllTexts()
    {
        while (texts.TryDequeue(out TextData data))
        {
            if (data.delay)
            {
                await Awaitable.WaitForSecondsAsync(textPopDelay);
            }
            GameObject storyText = Instantiate(data.textPrefab, textContainer);
            storyText.GetComponentInChildren<TextMeshProUGUI>().text = data.text;
            if(data.speakerNo >= 0)
            {
                storyText.GetComponentInChildren<Image>().color = bubbleColors[data.speakerNo];
            }
            await Awaitable.NextFrameAsync();
            LayoutRebuilder.ForceRebuildLayoutImmediate(textContainer.GetComponent<RectTransform>());
            await Awaitable.NextFrameAsync();
        }
    }

    private void SetUpTextInputScreen(bool setup)
    {
        numberInputContainer.SetActive(!setup);
        textInputContainer.SetActive(setup);
        inTextInput = setup;
        if (setup)
        {
            textInputField.text = "";
            FocusInputField();
        }
    }
    #endregion

    #region Choice selection
    private void OnClickChoiceButton(int index)
	{
        if(index >= story.currentChoices.Count)
        {
            index = story.currentChoices.Count - 1;
        }
		AddTextToStack(phoneButtons[index].myChar, playerTextPrefab, false, -1);
        story.ChooseChoiceIndex(index);
        RefreshView();
	}

    private string GetTextInput()
    {
        return textInputField.text;
    }

    public void SubmitText()
    {
        string submitted = textInputField.text.ToLower();
        string answer = story.variablesState.GetVariableWithName("answer").ToString().ToLower();
        bool pass = answer == "any" || submitted == answer;

        AddTextToStack(textInputField.text, playerTextPrefab, false, -1);
        if (pass)
        {
            story.ChooseChoiceIndex(0);
        }
        else
        {
            story.ChooseChoiceIndex(1);
        }
        RefreshView();
    }

    private void FocusInputField()
    {
        EventSystem.current.SetSelectedGameObject(textInputField.gameObject);
        textInputField.ActivateInputField();
        textInputField.OnPointerClick(new PointerEventData(EventSystem.current));
        textInputField.Select();
    }
    #endregion

    private struct TextData
    {
        public string text;
        public GameObject textPrefab;
        public bool delay;
        public int speakerNo;

        public TextData(string text, GameObject prefab, bool delay, int speakerNo)
        {
            this.text = text;
            textPrefab = prefab;
            this.delay = delay;
            this.speakerNo = speakerNo;
        }
    }
}
