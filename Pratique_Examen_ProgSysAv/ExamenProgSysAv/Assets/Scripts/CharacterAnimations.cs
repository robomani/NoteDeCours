using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour {

    [SerializeField]
    public SpriteAnimation[] animations;

    public string defaultAnimationId;

    private Dictionary<string, SpriteAnimation> animationById = new Dictionary<string, SpriteAnimation>();

    private SpriteAnimation currentAnim = null;
    private SpriteAnimation tempAnim = null;

    void Awake()
    {
        var renderer = GetComponent<SpriteRenderer>();
        foreach (var anim in animations)
        {
            anim.m_Renderer = renderer;
            animationById[anim.m_Id] = anim;
        }

        if(animationById.ContainsKey(defaultAnimationId))
            currentAnim = animationById[defaultAnimationId];
    }

    public Coroutine PlayAnimation(string animId)
    {
        if (animationById.ContainsKey(animId))
        {
            tempAnim = animationById[animId];
            tempAnim.Reset();
        }
        return StartCoroutine(new WaitWhile(() => tempAnim != null));
    }

    public void SetAnimation(string animId)
    {
        SpriteAnimation old = currentAnim;

        if (animationById.ContainsKey(animId))
        {
            currentAnim = animationById[animId];
        }
        else if (animationById.ContainsKey(defaultAnimationId))
        {
            currentAnim = animationById[defaultAnimationId];
        }
        else
        {
            currentAnim = null;
        }

        if (currentAnim != old)
            currentAnim?.Reset();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (tempAnim != null)
        {
            bool completed = tempAnim.DoUpdate();
            if (completed) tempAnim = null;
        }
        else
        {
            currentAnim?.DoUpdate();
        }
    }
}
