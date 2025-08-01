using System;
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
	
	[Header("Number Input")]
	[SerializeField] private GameObject numberInputContainer;
    [SerializeField] private CharacterButton[] phoneButtons = null;

	[Header("Text Input")]
	[SerializeField] private GameObject textInputContainer;
    [SerializeField] private TMP_InputField textInputField;
    private bool inTextInput;

    public static event Action<Story> OnCreateStory;
    public Story story;


    private void Update()
    {
        if(inTextInput && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
        {
            SubmitText();
        }
    }

    #region Set Up
    private void Awake() 
	{
		StartStory(inkJSONAsset);
	}

    private void Start()
    {
        for(int ii = 0; ii < phoneButtons.Length; ii++)
        {
			int value = ii;
			phoneButtons[ii].myButton.onClick.AddListener(() => OnClickChoiceButton(value));
        }
    }

    private void OnEnable()
    {
        if(inTextInput)
        {
            FocusInputField();
        }
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
			CreateContentView(story.Continue().Trim(), AITextPrefab);
		}

        SetUpTextInputScreen(story.variablesState.GetVariableWithName("useText").ToString() == "true");

        //Reset once at end
        if (story.currentChoices.Count == 0) 
		{
			StartStory(inkJSONAsset);
		}
    }

    private void CreateContentView(string text, GameObject textPrefab)
    {
        GameObject storyText = Instantiate(textPrefab, textContainer);
        storyText.GetComponentInChildren<TextMeshProUGUI>().text = text;
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
		CreateContentView(phoneButtons[index].myChar, playerTextPrefab);
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

        CreateContentView(textInputField.text, playerTextPrefab);
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
        textInputField?.OnPointerClick(new PointerEventData(EventSystem.current));
    }
    #endregion

    // Creates a textbox showing the the line of text


    // Creates a button showing the choice text
    //Button CreateChoiceView(string text) 
    //{
    //	// Creates the button from a prefab
    //	Button choice = Instantiate (buttonPrefab) as Button;
    //	choice.transform.SetParent (textContainer, false);

    //	// Gets the text from the button prefab
    //	Text choiceText = choice.GetComponentInChildren<Text> ();
    //	choiceText.text = text;

    //	// Make the button expand to fit the text
    //	HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
    //	layoutGroup.childForceExpandHeight = false;

    //	return choice;
    //}
}
