using UnityEngine;
using System.Collections;

public class BodyPartManager : MonoBehaviour {
	public string ItemName;
	public SpriteRenderer TargertGraphic;
	public Sprite[] ItemSprites;

	private int indexOfWornItem = 0;

	public int IndexOfWornItem
	{
		get
		{
			return indexOfWornItem;
		}
		set
		{
			if (value < 0)
				indexOfWornItem = ItemSprites.Length - 1;
			else if (value > ItemSprites.Length - 1)
				indexOfWornItem = 0;
			else
				indexOfWornItem = value;

			if (ItemSprites [indexOfWornItem] != null) 
			{
				TargertGraphic.enabled = true;
				TargertGraphic.sprite = ItemSprites [indexOfWornItem];
			} 
			else
				TargertGraphic.enabled = false;
		}
	}

	public override string ToString ()
	{
		if (ItemSprites [indexOfWornItem] == null)
			return ItemName + "(None)";
		else
			return ItemName + "(" +
			(indexOfWornItem + 1).ToString () +
				"/"+ ItemSprites.Length+")";
	}
}
