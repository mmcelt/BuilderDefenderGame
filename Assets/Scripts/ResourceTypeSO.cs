using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/ResourceType")]
public class ResourceTypeSO : ScriptableObject
{
	#region Fields

	public string _name;
	public string _nameShort;
	public Sprite _sprite;
	public string _colorHex;

	#endregion
}
