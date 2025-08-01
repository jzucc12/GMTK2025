using System;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class PhoneTextAdventure : MonoBehaviour 
{

    [SerializeField] private TextAsset inkJSONAsset = null;
    [SerializeField] private Transform textContainer = null;
    [SerializeField] private GameObject AITextPrefab = null;
    [SerializeField] private GameObject playerTextPrefab = null;
    [SerializeField] private CharacterButton[] phoneButtons = null;
    [HideInInspector] public Story story;
    public static event Action<Story> OnCreateStory;


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

    private void StartStory(TextAsset newStory) 
	{
		story = new Story (newStory.text);
        if(OnCreateStory != null) OnCreateStory(story);
		RefreshView();
	}

    private void RefreshView() 
	{
		while (story.canContinue)
		{
			CreateContentView(story.Continue().Trim(), AITextPrefab);
		}

		if(story.currentChoices.Count > 0) 
		{
			for (int i = 0; i < story.currentChoices.Count; i++) 
			{
				Choice choice = story.currentChoices[i];
			}
		}
		else 
		{
			Debug.LogError("End of story");
		}
	}

    // When we click the choice button, tell the story to choose that choice!
    private void OnClickChoiceButton(int index)
	{
		CreateContentView(phoneButtons[index].myChar, playerTextPrefab);
        story.ChooseChoiceIndex(index);
        RefreshView();
	}

    // Creates a textbox showing the the line of text
    private void CreateContentView(string text, GameObject textPrefab) 
	{
        GameObject storyText = Instantiate (textPrefab, textContainer);
		storyText.GetComponentInChildren<TextMeshProUGUI>().text = text;
	}

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
