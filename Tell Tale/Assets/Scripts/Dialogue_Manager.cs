using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


public class Dialogue_Manager : MonoBehaviour {
    private AudioClip dialogueAudio;
    private string[] fileLines;
    
    //Subtitle variables
    private List<string> subtitleLines = new List<string>();

    private List<string> subtitleTimingStrings = new List<string>();
    public List<float> subtitleTimings = new List<float>();

    public List<string> subtitleText = new List<string>();

    private int nextSubtitle = 0;

    private string displaySubtitle;

    //Trigger variable
    private List<string> triggerLines = new List<string>();

    private List<string> triggerTimingStrings = new List<string>();
    public List<float> triggerTimings = new List<float>();

    private List<string> triggers = new List<string>();
    public List<string> triggerObjectNames = new List<string>();
    public List<string> triggerMethodNames = new List<string>();

    private int nextTrigger = 0;


    //Singleton property
    public static Dialogue_Manager Instance { get; private set; }

	void Awake()
	{
		if (Instance != null && Instance != this) 
		{
			Destroy(gameObject);
		}

		Instance = this;

		gameObject.AddComponent<AudioSource> ();
	}

	public void BeginDialogue (AudioClip passedClip)
	{
        dialogueAudio = passedClip;

        // Reset all lists
        subtitleLines = new List<string>();
        subtitleTimingStrings = new List<string>();
        subtitleTimings = new List<float>();
        subtitleText = new List<string>();

        triggerLines = new List<string>();
        triggerTimingStrings = new List<string>();
        triggerTimings = new List<float>();
        triggers = new List<string>();
        triggerObjectNames = new List<string>();
        triggerMethodNames = new List<string>();

        nextSubtitle = 0;
        nextTrigger = 0;

        //Get everything from the text file
        TextAsset temp = Resources.Load("Dialogues/" + dialogueAudio.name) as TextAsset;
        fileLines = temp.text.Split('\n');

        //Split subtitle and trigger related lines into different lists
        foreach (string line in fileLines)
        {
            if(line.Contains("<trigger/>"))
            {
                triggerLines.Add(line);
            }
            else
            {
                subtitleLines.Add(line);
            }
        }

        //Split out our subtitle elements
        for(int cnt = 0; cnt < subtitleLines.Count; cnt ++)
        {
            string[] splitTemp = subtitleLines[cnt].Split('|');
            subtitleTimingStrings.Add(splitTemp[0]);
            subtitleTimings.Add(float.Parse(CleanTimeString(subtitleTimingStrings[cnt])));
            subtitleText.Add(splitTemp[1]);
        }

        //Split out our trigger elements
        for(int cnt = 0; cnt < subtitleLines.Count; cnt++)
        {
            string[] splitTemp1 = triggerLines[cnt].Split('|');
            triggerTimingStrings.Add(splitTemp1[0]);
            triggerTimings.Add(float.Parse(CleanTimeString(triggerTimingStrings[cnt])));

            triggers.Add(splitTemp1[1]);
            string[] splitTemp2 = triggers[cnt].Split('-');
            splitTemp2[0] = splitTemp2[0].Replace("<trigger/>", "");
            triggerObjectNames.Add(splitTemp2[0]);
            triggerMethodNames.Add(splitTemp2[1]);
        }

        //Set initial subtitle text
        if(subtitleText[0] != null)
        {
            displaySubtitle = subtitleText[0];
        }

        //set and play the audio-clip
        GetComponent<AudioSource>().clip = dialogueAudio;
        GetComponent<AudioSource>().Play();
    }

    //Remove all characters that are not part of the timing float
    private string CleanTimeString(string timeString)
    {
        Regex digitsOnly = new Regex(@"[^\d+(\.\d+)*5]");
        return digitsOnly.Replace(timeString, "");
    }
}
