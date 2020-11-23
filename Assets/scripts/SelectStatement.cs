using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectStatement : MonoBehaviour
{
    public Text question, selectedText, result, introText;
    public Button substatementFalse, substatementTrue;
    public Button firstButton, secondButton;
    public Text textFalse, textTrue;
    public Image firstPanel, secondPanel;
    public GameObject buttonPrefab;

    private bool isFirstButton = true;
    private int tutorialClick = 0;

    private System.Random rnd = new System.Random();

    //Used for placing buttons
    private string[] trueExpansions = { "(not False)", "(True and True)", "(True or True)", "(True or False)", "(False or True)"};
    private string[] falseExpansions = {"(not True)", "(False and False)", "(True and False)", "(False and True)", "(False or False)"};
    private string[] bothExpansions = { "(not False)", "(True and True)", "(True or True)", "(True or False)", "(False or True)",
                                        "(not True)", "(False and False)", "(True and False)", "(False and True)", "(False or False)"};
    private int[] expansionWidths = { 100, 140, 125, 130, 130, 90, 150, 145, 145, 140 };

    private int level = 1;
    private string[] subquestions = new string[10];
    private GameObject[] buttons = new GameObject[10];

    private int indexSelected = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInitialClick()
    {
        tutorialClick++;
        if (tutorialClick == 1)
        {
            introText.text = "Click on short statements in the prompt to mark them as 'True' or 'False'.";
        }
        else
        {
            firstPanel.gameObject.SetActive(false);
        }
    }

    // Called when the user clicks on a sub-statement
    public void OnStatementClick()
    {
        selectedText.text = "Not true";

        substatementFalse.image.color = new Color(substatementFalse.image.color.r, substatementFalse.image.color.g, substatementFalse.image.color.b, 255);
        substatementFalse.interactable = true;
        textFalse.text = "Substatement:\nFalse";
        substatementTrue.image.color = new Color(substatementTrue.image.color.r, substatementTrue.image.color.g, substatementTrue.image.color.b, 255);
        substatementTrue.interactable = true;
        textTrue.text = "Substatement:\nTrue";
    }

    public void OnSecondStatementClick()
    {
        selectedText.text = question.text;

        substatementFalse.image.color = new Color(substatementFalse.image.color.r, substatementFalse.image.color.g, substatementFalse.image.color.b, 255);
        substatementFalse.interactable = true;
        textFalse.text = "Substatement:\nFalse";
        substatementTrue.image.color = new Color(substatementTrue.image.color.r, substatementTrue.image.color.g, substatementTrue.image.color.b, 255);
        substatementTrue.interactable = true;
        textTrue.text = "Substatement:\nTrue";
    }

    public void OnTrueClick()
    {
        secondPanel.gameObject.SetActive(false);
    }
    
    public void OnFalseClick()
    {
        secondPanel.gameObject.SetActive(false);
    }

    public void OnSubFalseClick()
    {
        if (level == 1)
        {
            if (isFirstButton)
            {
                question.text = "False and True";
                isFirstButton = false;
                secondButton.interactable = true;
                Destroy(firstButton.gameObject);
            }
            else
            {
                question.text = "False";
                secondButton.interactable = false;
            }
        }
        else
        {
            question.text = question.text.Substring(0, indexSelected) + "False" + question.text.Substring(indexSelected + selectedText.text.Length);
        }

        resetButtons();
    }

    public void OnSubTrueClick()
    {
        if (level == 1)
        { 
            if (isFirstButton)
            {
                question.text = "True and True";
                isFirstButton = false;
                secondButton.interactable = true;
                Destroy(firstButton.gameObject);
            }
            else
            {
                question.text = "True";
                secondButton.interactable = false;
            }
        }
        else
        {
            question.text = question.text.Substring(0, indexSelected) + "True" + question.text.Substring(indexSelected + selectedText.text.Length);
        }

        resetButtons();
    }

    public void nextLevel()
    {
        level = level + 1;
        if(level == 2)
        {
            if (firstButton != null)
            {
                Destroy(firstButton.gameObject);
            }
            Destroy(secondButton.gameObject);
        }

        string wholeQuestion;
        int tVal = rnd.Next(0, 2);

        if(tVal == 0)
        {
            wholeQuestion = "False";
            result.text = "The correct answer is\nFalse";
        }
        else
        {
            wholeQuestion = "True";
            result.text = "The correct answer is\nTrue";
        }

        for (int i = 0; i < 4; i++)
        {
            List<int> indexTrues = CountSubstrings(wholeQuestion, "True");
            List<int> indexFalses = CountSubstrings(wholeQuestion, "False");

            List<int> indexBoth = new List<int>();
            indexBoth.AddRange(indexTrues);
            indexBoth.AddRange(indexFalses);
            
            int valToReplace = rnd.Next(0, indexBoth.Count);
            string replacing;
            string[] validReplacements;

            int value = indexBoth[valToReplace];

            if (indexTrues.Contains(value))
            {
                replacing = "True";
                validReplacements = trueExpansions;
            }
            else
            {
                replacing = "False";
                validReplacements = falseExpansions;
            }

            string replacement = validReplacements[rnd.Next(0, 5)];

            wholeQuestion = wholeQuestion.Substring(0, value) + replacement + wholeQuestion.Substring(value + replacing.Length);
        }

        question.text = wholeQuestion;
        resetButtons();

        secondPanel.gameObject.SetActive(true);
    }

    private void resetButtons()
    {
        selectedText.text = "";

        substatementFalse.image.color = new Color(substatementFalse.image.color.r, substatementFalse.image.color.g, substatementFalse.image.color.b, 0);
        substatementFalse.interactable = false;
        textFalse.text = "";
        substatementTrue.image.color = new Color(substatementTrue.image.color.r, substatementTrue.image.color.g, substatementTrue.image.color.b, 0);
        substatementTrue.interactable = false;
        textTrue.text = "";

        for (int i = 0; i < buttons.Length; i++)
        {
            Destroy(buttons[i]);
            buttons[i] = null;
            subquestions[i] = "";
        }

        List<int> indices = new List<int>();

        int currentNum = 0;
        for(int j = 0; j < 10; j++)
        {
            string s = bothExpansions[j];
            int width = expansionWidths[j];

            List<int> occurances = CountSubstrings(question.text, s);
            for(int i = 0; i < occurances.Count; i++)
            {
                subquestions[currentNum] = s;
                indices.Add(occurances[i]);
                buttons[currentNum] = (GameObject) Instantiate(buttonPrefab);
                buttons[currentNum].transform.parent = question.transform;

                RectTransform rt = buttons[currentNum].GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(width, 30);
                float xPos = (question.text.Length * -4.5f) + (occurances[i] * 9) + (width / 2);
                rt.anchoredPosition = new Vector2(xPos, 0);

                Button button = buttons[currentNum].GetComponent<Button>();
                button.onClick.AddListener(delegate {
                    for(int k = 0; k < indices.Count; k++)
                    {
                        for(int l = 0; l < occurances.Count; l++)
                        {
                            if (occurances[l] == indices[k])
                            {
                                OnSubstatementClick(s, indices[k]);
                            }
                        }
                    }
                } );

                currentNum++;
            }
        }
    }

    public void OnSubstatementClick(string statement, int index)
    {
        Debug.Log(index);

        selectedText.text = statement;
        indexSelected = index;

        substatementFalse.image.color = new Color(substatementFalse.image.color.r, substatementFalse.image.color.g, substatementFalse.image.color.b, 255);
        substatementFalse.interactable = true;
        textFalse.text = "Substatement:\nFalse";
        substatementTrue.image.color = new Color(substatementTrue.image.color.r, substatementTrue.image.color.g, substatementTrue.image.color.b, 255);
        substatementTrue.interactable = true;
        textTrue.text = "Substatement:\nTrue";
    }

    private List<int> CountSubstrings(string input, string key)
    {
        List<int> indices = new List<int>();

        int index = input.IndexOf(key);

        while(index != -1)
        {
            indices.Add(index);
            index = input.IndexOf(key, index + 1);
        }

        return indices;
    }
}
