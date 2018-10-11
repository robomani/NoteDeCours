using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [Comment("This is the player id")]
    public int playerId;

    private void Start()
    {
        //On vas chercher l'information sur le type player controller
        Type monType = typeof(PlayerController);

        //On vas chercher l'information sur le field player id
        FieldInfo monField = monType.GetField("playerId");

        //On vas chercher tout les attributes de type CommentAttribute sur le field playerId
        object[] attributes = monField.GetCustomAttributes(typeof(CommentAttribute), false);

        // On cast le premier attribut en CommentAttribute
        CommentAttribute monAttribut = attributes.FirstOrDefault() as CommentAttribute;

        Debug.Log(monAttribut.Comment);
    }
}
