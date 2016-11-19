using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Global_Menu.AddRange (this.GetComponentsInChildren<TweenPosition> ());
	}

	public void MenuTween()
	{
		foreach (TweenPosition tween in Global_Menu) {
			if (!MenuOnOff) {
				tween.PlayForward ();
			} else {
				tween.PlayReverse ();
			}
		}
		MenuOnOff = !MenuOnOff;
	}

	public void GlobalMenuSelect(GameObject _obj)
	{
		ScenesManager.Instance.SceneChange (_obj.name);
		//UIEventListener.Get (_obj).onPress += UIManager.Instance.GlobalButton_OnPress;
	}

	private List<TweenPosition> Global_Menu = new List<TweenPosition> ();
	private bool MenuOnOff = false;
}
