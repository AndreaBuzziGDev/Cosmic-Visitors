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
            int typeNum = Random.Range(0, 2);//RETURNS 0 or 1
            if (typeNum <1)
            {
                generatedString += 'E';
            }
            else
            {
                generatedString += 'V';
            }
        }
        Debug.Log("generatedString: " + generatedString);

        return generatedString;
    }

}
