using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/ResourceTypeList")]
public class ResourceTypeListSO : ScriptableObject
{
	#region Fields

	public List<ResourceTypeSO> _list;

	#endregion
}
