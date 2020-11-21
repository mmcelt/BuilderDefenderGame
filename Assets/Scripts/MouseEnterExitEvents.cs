using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseEnterExitEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	#region Fields

	public event EventHandler OnMouseEnter, OnMouseExit;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		
	}
	#endregion

	#region Public Methods

	public void OnPointerEnter(PointerEventData eventData)
	{
		OnMouseEnter?.Invoke(this, EventArgs.Empty);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		OnMouseExit?.Invoke(this, EventArgs.Empty);
	}

	#endregion

	#region Private Methods


	#endregion
}
