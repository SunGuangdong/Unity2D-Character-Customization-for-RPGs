using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class AbsSelector: MonoBehaviour
{
	public abstract void UpdateSelector ();
}


public class Selector : AbsSelector {

	public Text TargetText;
	public BodyPartManager SelectablePart;

	public void ButtonHandler(int direction)
	{
		// left => direction = 0 right=> direction = 1
		if (direction == 0)
		{
			SelectablePart.IndexOfWornItem--;
		} 
		else 
		{
			SelectablePart.IndexOfWornItem++;
		}

		UpdateText ();
		
	}

	public void UpdateText()
	{
		TargetText.text = SelectablePart.ToString ();
	}

	public override void UpdateSelector()
	{
		UpdateText ();
	}
}
