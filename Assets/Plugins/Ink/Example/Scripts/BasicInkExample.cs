﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class BasicInkExample : MonoBehaviour {
	
	void Awake () {
		// Remove the default message
		RemoveChildren();
		StartStory();
	}

	// Creates a new Story object with the compiled story which we can then play!
	void StartStory () {
		story = new Story (inkJSONAsset.text);
		RefreshView();
	}
	
	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView () {
		// Remove all the UI on screen
		RemoveChildren ();

        // Read all the content until we can't continue any more
        string text = "";
        if( story.canContinue  )
        {
            // Continue gets the next line of the story
            text += story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
        }
        while ( story.canContinue )
        {
            //add paragraph breaks
            text += "\n\n";
            // Continue gets the next line of the story
            text += story.Continue ();
			// This removes any white space from the text.
			text = text.Trim();
        }
        // Display the text on screen!
        CreateContentView( text );

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				// Tell the button what to do when we press it
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else {
			Button choice = CreateChoiceView("End of story.\nRestart?");
			choice.onClick.AddListener(delegate{
				StartStory();
			});
        }

        // add space at the bottom
        CreateContentView( "" );
    }

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	// Creates a button showing the choice text
	void CreateContentView (string text) {
		Text storyText = Instantiate (textPrefab) as Text;
        storyText.transform.SetParent( base.transform, false );
        storyText.text = text;
	}

	// Creates a button showing the choice text
	Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (base.transform, false);
		
		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		return choice;
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildren () {
		int childCount = base.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			GameObject.Destroy (base.transform.GetChild (i).gameObject);
		}
	}

	[SerializeField]
	private TextAsset inkJSONAsset;
	private Story story;

	//[SerializeField]
    //public Transform this;

    // UI Prefabs
    [SerializeField]
	private Text textPrefab;
	[SerializeField]
	private Button buttonPrefab;
}