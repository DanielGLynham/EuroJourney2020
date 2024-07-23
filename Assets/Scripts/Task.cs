using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    private int _storyNum;
    private string _playerTeam, _oppTeam;
    private int _playerTeamGoals, _playerGoals, _oppGoals;
    private string _title;
    private string _brief;
    private string _opOne, _opTwo, _opThree;
    private int _choiceOne, _choiceTwo, _choiceThree;
    private int _date;
    private int opAmount;
    private bool _inputFieldRequired;
    private int _teamScore;
    private int _oppScore;
    private string _newspaperTitle, _newspaperBrief;
    private bool isNewspaper = false;

    private int optionsChosen;

    public Task(int storyNum, string title, string description, int date, string opOne, string opTwo, string opThree, int choiceOne, int choiceTwo, int choiceThree)
    {
        _storyNum = storyNum;
        _title = title;
        _brief = description;
        _date = date;
        _opOne = opOne;
        _opTwo = opTwo;
        _opThree = opThree;
        _choiceOne = choiceOne;
        _choiceTwo = choiceTwo;
        _choiceThree = choiceThree;
        opAmount = 3;
    }
    public Task(int storyNum, string title, string description, int date, string opOne, string opTwo, int choiceOne, int choiceTwo)
    {
        _storyNum = storyNum;
        _title = title;
        _brief = description;
        _date = date;
        _opOne = opOne;
        _opTwo = opTwo;
        _choiceOne = choiceOne;
        _choiceTwo = choiceTwo;
        opAmount = 2;
    }
    public Task(int storyNum, string title, string description, int date, string opOne, int choiceOne, bool iFieldRequired)
    {
        _storyNum = storyNum;
        _title = title;
        _brief = description;
        _date = date;
        _opOne = opOne;
        _choiceOne = choiceOne;
        opAmount = 1;
        _inputFieldRequired = iFieldRequired;
    }
    public Task(string title, string description, string opOne, int choiceOne)
    {
        _title = title;
        _brief = description;
        _opOne = opOne;
        _choiceOne = choiceOne;
    }
    public Task(string title, string brief)
    {
        _newspaperTitle = title;
        _newspaperBrief = brief;
        opAmount = 1;
        isNewspaper = true;
    }
    public bool GetIsNewspaper()
    {
        return isNewspaper;
    }
    public string GetNewspaperTitle()
    {
        return _newspaperTitle;
    }
    public string GetNewspaperBrief()
    {
        return _newspaperBrief;
    }
    public string GetTitle()
    {
        return _title;
    }
    public string GetBrief()
    {
        return _brief;
    }
    public int GetDate()
    {
        return _date;
    }
    public string GetOpOne()
    {
        return _opOne;
    }
    public string GetOpTwo()
    {
        return _opTwo;
    }
    public string GetOpThree()
    {
        return _opThree;
    }
    public int GetChoiceOne()
    {
        return _choiceOne;
    }
    public int GetChoiceTwo()
    {
        return _choiceTwo;
    }
    public int GetChoiceThree()
    {
        return _choiceThree;
    }
    public int GetOpAmount()
    {
        return opAmount;
    }
    public bool GetIFieldRequired()
    {
        return _inputFieldRequired;
    }


}
