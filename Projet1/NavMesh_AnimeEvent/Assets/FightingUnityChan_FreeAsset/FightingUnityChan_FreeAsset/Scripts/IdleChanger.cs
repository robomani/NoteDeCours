using UnityEngine;
using System.Collections;

//
// アニメーション簡易プレビュースクリプト
// 2015/4/25 quad arrow
//

// Require these components when using this script
[RequireComponent(typeof(Animator))]

public class IdleChanger : MonoBehaviour
{

	private Animator anim;						// Animatorへの参照
	private AnimatorStateInfo currentState;		// 現在のステート状態を保存する参照
	private AnimatorStateInfo previousState;	// ひとつ前のステート状態を保存する参照

    //ici le type serait le script de mon enemy et non un GameObject
    private GameObject m_Enemy;
	// Use this for initialization
	void Start ()
	{
		// 各参照の初期化
		anim = GetComponent<Animator> ();
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		previousState = currentState;

	}

    private void Damage_AnimEvent()
    {
        Debug.Log("Damage");
    }

    private void Hit_AnimEvent()
    {
        Debug.Log("Hit");
        if (m_Enemy != null)
        {
            //m_Ennemy.ReceiveDamage(m_KickDamage)
        }
    }

    private void OnTriggerEnter(Collider i_Col)
    {
        //assigne mon i_Col.getComponent<Enemy>() a ma variable m_Enemy seulement si j'ai toucher un enemy
    }

    private void OnTriggerExit(Collider i_Col)
    {
        //Si mon i_Col == m_Enemy.collider, donc enemy = null 
    }

    void OnGUI()
	{	
		GUI.Box(new Rect(Screen.width - 200 , 45 ,120 , 350), "");
		if(GUI.Button(new Rect(Screen.width - 190 , 60 ,100, 20), "Jab"))
			anim.SetTrigger ("Jab");
		if(GUI.Button(new Rect(Screen.width - 190 , 90 ,100, 20), "Hikick"))
			anim.SetTrigger("Hikick");
		if(GUI.Button(new Rect(Screen.width - 190 , 120 ,100, 20), "Spinkick"))
			anim.SetTrigger("Spinkick");
		if(GUI.Button(new Rect(Screen.width - 190 , 150 ,100, 20), "Rising_P"))
			anim.SetTrigger("Rising_P");
		if(GUI.Button(new Rect(Screen.width - 190 , 180 ,100, 20), "Headspring"))
			anim.SetTrigger("Headspring");
		if(GUI.Button(new Rect(Screen.width - 190 , 210 ,100, 20), "Land"))
			anim.SetTrigger("Land");
		if(GUI.Button(new Rect(Screen.width - 190 , 240 ,100, 20), "ScrewKick"))
			anim.SetTrigger("ScrewK");
		if(GUI.Button(new Rect(Screen.width - 190 , 270 ,100, 20), "DamageDown"))
			anim.SetTrigger("DamageDown");
		if(GUI.Button(new Rect(Screen.width - 190 , 300 ,100, 20), "Run"))
			anim.SetBool ("Run", true);
		if(GUI.Button(new Rect(Screen.width - 190 , 330 ,100, 20), "Run_end"))
			anim.SetBool("Run", false);


	}
}
