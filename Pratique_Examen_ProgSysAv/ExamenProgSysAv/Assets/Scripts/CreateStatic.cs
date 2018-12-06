using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStatic : MonoBehaviour {

    public Transform prefab;

    private static bool created = false;
    
	void Awake () {
        if (!created)
        {
            created = true;
            var root = Instantiate(prefab);
            var children = new GameObject[root.childCount];
            for (var i = 0; i < root.childCount; i++)
            {
                children[i] = root.GetChild(i).gameObject;
            }
            root.DetachChildren();
            foreach (var child in children)
            {
                DontDestroyOnLoad(child);
            }
            Destroy(root.gameObject);
        }
	}
}
