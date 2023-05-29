using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: RGSimple
public class RGSimple : RandomGenerator
{
    //DATA


    //METHODS
    //IT CREATES A COLUMN OF DATA BASED ON INPUT
    public override string GenerateColumn()
    {
        string generatedString = "";
        for(int i = 0; i<7; i++)
        {
            //TODO: COULD BE REFACTORED SO THAT IT COULD EASILY REFERENCIATE VisitorColumn CharToSlotType DICTIONARY
            //      HOWEVER, IT WOULD ALSO REQUIRE ANOTHER VisitorColumn CONSTRUCTOR
            //TODO: ANOTHER REFACTOR COULD BE COUPLING IT BETTER WITH THE CONTENT OF VisitorColumn CLASS
            int typeNum = Random.Range(0, 100);//RETURNS NUMBERS BETWEEN 0 AND 5
            if (typeNum <1) generatedString += 'M';
            else if (typeNum < 20) generatedString += 'E';
            else if (typeNum < 45) generatedString += 'F';
            else if (typeNum < 70) generatedString += 'G';
            else if (typeNum < 85) generatedString += 'B';
            else generatedString += 'R';
        }

        //TODO: CONDITIONALLY DEBUG BASED ON VisitorGenerator CLASS
        Debug.Log("RGSimple - generatedString: " + generatedString);

        return generatedString;
    }

}
