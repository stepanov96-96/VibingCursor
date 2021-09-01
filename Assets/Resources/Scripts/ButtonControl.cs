using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonControl : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    //public player_AI gameControl;
    public player_AI _player;

    private ButtonControl player;

    public EnumButton enumButton;
    
	// Use this for initialization
	void Start ()
    {
		player = FindObjectOfType<ButtonControl> ();
	}


	public static void Right()
    {
        player_AI.right = true;
        player_AI.left = false;
        //Debug.Log ("MoveUp");
    }


	public static void Left()
    {
        player_AI.right = false;
        player_AI.left = true;
        //Debug.Log ("MoveDown");
    }


	

    

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (enumButton)
        {
            case EnumButton.Right:
                player_AI.right = true;
                //Debug.Log("TrueUp");
                break;
            case EnumButton.Left:
                player_AI.left = true;
                //Debug.Log("TrueDown");
                break;          
                
            default:
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        switch (enumButton)
        {
            case EnumButton.Left:
                player_AI.left = false;
                // Debug.Log("falseUp");
                break;
            case EnumButton.Right:
                player_AI.right = false;
                //Debug.Log("falseDown");
                break;            
            default:
                break;
        }
    }
}
