using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour {

	public InputField NameInputField;
	public RenderTexture AvatarTexture;
	public Sprite ImageForEmptySlot;

	public SlotInfo[] SaveSlots;

	private CharacterManager dresser;

	// Use this for initialization
	void Start () 
	{
		dresser = FindObjectOfType<CharacterManager> ();
	
		if (PlayerPrefs.HasKey ("LastCharName"))
			NameInputField.text = PlayerPrefs.GetString ("LastCharName");

		UpdateSelectors ();

		DisplaySlotsInfo ();
	}

	public void DisplaySlotsInfo()
	{
		// display names and images on Save Slots
		for(int i = 0; i<SaveSlots.Length; i++)
		{
			if (PlayerPrefs.HasKey ("SlotName" + i.ToString ())) 
			{
				SaveSlots [i].SlotName.text = PlayerPrefs.GetString ("SlotName" + i.ToString ());
				SaveSlots [i].AvatarImage.sprite = PNGUtility.LoadSpriteFromFile (
					Application.persistentDataPath + "/avatar" + i.ToString () + ".png", 512, 512);
			}
			else 
			{
				SaveSlots [i].SlotName.text = "Empty Slot";
				SaveSlots [i].AvatarImage.sprite = ImageForEmptySlot;
			}

		}
	}

	public void SaveCharacterToSlot(int slotIndex)
	{
		SaveAvatar (slotIndex);

		SaveSlots [slotIndex].SlotName.text = NameInputField.text;

		PlayerPrefs.SetString ("SlotName" + slotIndex.ToString (), NameInputField.text);
		PlayerPrefs.SetString ("SlotConfiguration" + slotIndex.ToString (), 
			dresser.CurrentConfiguration ());
		PlayerPrefs.Save ();

		SaveSlots [slotIndex].AvatarImage.sprite = PNGUtility.LoadSpriteFromFile (
			Application.persistentDataPath + "/avatar" + slotIndex.ToString () + ".png", 512, 512);
		
	}

	public void LoadCharacterFromSlot(int slotIndex)
	{
		if (PlayerPrefs.HasKey ("SlotName" + slotIndex.ToString ())) 
		{
			dresser.LoadCharacterFromConf (PlayerPrefs.GetString (
				"SlotConfiguration" + slotIndex.ToString ()));
			NameInputField.text = SaveSlots [slotIndex].SlotName.text;

			UpdateSelectors ();
		}

	}

	public void ClearSlot(int slotIndex)
	{
		SaveSlots[slotIndex].SlotName.text = "Empty Slot";
		if (PlayerPrefs.HasKey ("SlotName" + slotIndex.ToString ()))
			PlayerPrefs.DeleteKey ("SlotName" + slotIndex.ToString ());
		if (PlayerPrefs.HasKey ("SlotConfiguration" + slotIndex.ToString ()))
			PlayerPrefs.DeleteKey ("SlotConfiguration" + slotIndex.ToString ());
		
		SaveSlots [slotIndex].AvatarImage.sprite = ImageForEmptySlot;
	}

	public void GenerateRandomCharacter()
	{
		foreach (BodyPartManager bpm in dresser.AllBodyParts)
			bpm.IndexOfWornItem = Random.Range (0, bpm.ItemSprites.Length);

		UpdateSelectors ();
	}

	private void UpdateSelectors()
	{
		AbsSelector[] allSelectors = FindObjectsOfType<AbsSelector> ();
		if (allSelectors.Length > 0)
			foreach (AbsSelector s in allSelectors)
				s.UpdateSelector();
	}

	public void SaveLastEditedCharacter()
	{
		PlayerPrefs.SetString ("LastCharName", NameInputField.text);
		PlayerPrefs.SetString ("LastCharConfiguration", dresser.CurrentConfiguration ());
		PlayerPrefs.Save ();
	}

	void OnApplicationQuit()
	{
		SaveLastEditedCharacter ();
	}

	private void SaveAvatar(int slotIndex)
	{
		string filename = "avatar"+slotIndex.ToString()+".png";
		string filepath = Application.persistentDataPath + "/" + filename;

		PNGUtility.SaveRenderTextureToFile (filepath, AvatarTexture);

		Debug.Log (Application.persistentDataPath);
	}

}

[System.Serializable]
public class SlotInfo
{
	public Text SlotName;
	public Image AvatarImage;
}
