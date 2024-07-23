using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RelationshipHolder
{
    // Attributes
    private int bond;
    private List<int> milestones;
    private int currentMilestone;
    private int posCurrentMilestone;
    private int negCurrentMilestone;
    private string firstName;
    private string _name;
    private string title;
    private bool male;
    private bool dating = false;
    private int _listNum;
    private bool goodStoryAvalible;
    private bool badStoryAvalible;
    private Utilities utilities = new Utilities();

    public RelationshipHolder(int listNum)
    {
        bond = 50;
        _listNum = listNum;
        currentMilestone = 0;
        posCurrentMilestone = 1;
        negCurrentMilestone = -1;
    }

    void Start()
    {
        CalculateMilestones();
    }
    public string GetTitle()
    {
        return title;
    }
    public void SetTitle(string _title)
    {
        title = _title;
    }
    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }
   
    public void SetBond(int amount)
    {
        bond += amount;
        if (bond > currentMilestone * 10)
        {
            currentMilestone++;
            goodStoryAvalible = true;
        }
        else if (bond < currentMilestone * -10)
        {
            currentMilestone--;
            badStoryAvalible = true;
        }
    }
    public bool GetGoodStoryAvalible()
    {
        return goodStoryAvalible;
    }
    public void SetGoodStoryAvalible(bool avalible)
    {
        goodStoryAvalible = avalible;
    }
    public void SetBadStoryAvalible(bool avalible)
    {
        badStoryAvalible = avalible;
    }
    public bool GetBadStoryAvalible()
    {
        return badStoryAvalible;
    }

    public int GetBondToPlayer()
    {
        return bond;
    }
    public int GetCurrentMilestone()
    {
        return currentMilestone;
    }
    public int GetPosMilestone()
    {
        // TODO: Write this function to iterate through list
        return posCurrentMilestone;
    }
    public int GetNegMilestone()
    {
        // TODO: Write this function to iterate through list
        return negCurrentMilestone;
    }
    private void CalculateMilestones()
    {

    }
    public void SetMale(bool male)
    {
        //Debug.Log(utilities.maleFirstName.Count);
        //Debug.Log(utilities.femaleFirstName.Count);
        //Debug.Log(utilities.secondName.Count);
        this.male = male;
        _name = utilities.GetMaleName() + " " + utilities.GetSecondName();
    }
    public void SetFemale(bool male)
    {
        this.male = male;
        _name = utilities.GetFemaleName() + " " + utilities.GetSecondName();
    }
    public bool GetMale()
    {
        return male;
    }
    public void SetDating(bool yup)
    {
        dating = yup;
    }
    public bool GetDating()
    {
        return dating;
    }
}
