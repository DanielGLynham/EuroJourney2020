using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teammate : Player
{
    // Attributes
    private int bondToTeam;

    protected  virtual void Start()
    {
        base.Start();
    }

    

    public bool SetFieldPosition(int fieldPosition)
    {
        this.fieldPosition = fieldPosition;
        return true;        // Return if the field position has been changed
    }
}
