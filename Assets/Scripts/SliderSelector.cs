using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SliderSelector : AbsSelector{

	public BodyPartManager SelectablePart;
	private Slider sl;

	// Use this for initialization
	void Awake () 
	{
		sl = GetComponent<Slider> ();
		sl.minValue = 0;
		sl.maxValue = SelectablePart.ItemSprites.Length;
		sl.wholeNumbers = true;
	}
	
	public void SliderValueChanged()
	{
		SelectablePart.IndexOfWornItem = Mathf.RoundToInt(sl.value);
	}

	public void UpdateValue()
	{
		sl.value = (float)SelectablePart.IndexOfWornItem;
	}

	public override void UpdateSelector()
	{
		UpdateValue ();
	}
}
