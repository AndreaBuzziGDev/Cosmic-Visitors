using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGDebug : RandomGenerator
{
    //DATA
    int contentIndex = 0;
    char[] chars = new char[] {
        'E',
        'B',
        'R',
        'F',
        'G',
        'M'
    };

    //METHODS//METHODS
    //IT CREATES A COLUMN OF DATA BASED ON INPUT. SEQUENTIALLY CYCLES BETWEEN TYPES.
    public override string GenerateColumn()
    {
        string firstEmpty = "EEE";
        string lastEmpty = "EEE";

        contentIndex++;
        if (contentIndex >= chars.Length) contentIndex = 0;

        return firstEmpty + chars[contentIndex] + lastEmpty;
    }

}
