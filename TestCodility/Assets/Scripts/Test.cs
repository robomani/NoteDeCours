using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	private void Start ()
    {
        string words = "";

        string[] repArray = new string[9];
        string temp = "";
        int rank = -1;
        if (words != "")
        {
            foreach (char letter in words)
            {
                if (int.TryParse(letter.ToString(), out rank))
                {
                    temp += letter;
                }
                else if(letter.ToString() != " ")
                {
                    temp += letter;
                }
                else
                {
                    if (rank != -1)
                    {
                        repArray[rank - 1] = temp;
                        temp = "";
                    }
                    else
                    {
                        //No rank found
                    }
                    rank = -1;
                }
            }
            for (int i = 0; i < repArray.Length; i++)
            {

            }
        }
        return "";
    }
}
