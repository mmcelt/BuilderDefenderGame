using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TooltipUI : MonoBehaviour
{
	#region Fields

	public static TooltipUI Instance { get; private set; }

	[SerializeField] TextMeshProUGUI _text;
	[SerializeField] RectTransform _canvas, _background;

	RectTransform _rectTransform;
	TooltipTimer _tooltipTimer;

	#endregion

	#region MonoBehaviour Methods

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);
	}

	void Start() 
	{
		_rectTransform = GetComponent<RectTransform>();

		Hide();
	}
	
	void Update()
	{
		HandleFollowMouse();

		if (_tooltipTimer != null)
		{
			_tooltipTimer._timer -= Time.deltaTime;
			if (_tooltipTimer._timer <= 0)
			{
				Hide();
			}
		}
	}
	#endregion

	#region Public Methods

	public void Show(string tooltipText, TooltipTimer tooltipTimer = null)
	{
		_tooltipTimer = tooltipTimer;
		gameObject.SetActive(true);
		SetTextAndResizeBackground(tooltipText);
		HandleFollowMouse();
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
	#endregion

	#region Private Methods

	void HandleFollowMouse()
	{
		Vector2 anchoredPosition = Input.mousePosition / _canvas.localScale.x;

		if (anchoredPosition.x + _background.rect.width > _canvas.rect.width)
		{
			//tooltip would be off the right side of the screen...
			anchoredPosition.x = _canvas.rect.width - _background.rect.width;
		}
		if (anchoredPosition.y + _background.rect.height > _canvas.rect.height)
		{
			//tooltip would be off the top of the screen...
			anchoredPosition.y = _canvas.rect.height - _background.rect.height;
		}

		_rectTransform.anchoredPosition = anchoredPosition;
	}

	void SetTextAndResizeBackground(string tooltipText)
	{
		_text.SetText(tooltipText);
		_text.ForceMeshUpdate();

		Vector2 textSize = _text.GetRenderedValues(false);
		Vector2 pading = new Vector2(8, 8);
		_background.sizeDelta = textSize + pading;
	}
	#endregion

	public class TooltipTimer
	{
		public float _timer;
	}
}

