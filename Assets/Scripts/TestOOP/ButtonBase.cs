using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

/*
Parent class of buttons for testing OOP
*/
public abstract class ButtonBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // INHERITANCE
{
	// tooltip for the button descriptions
	public string ButtonTooltip // ENCAPSULATION
	{
		get => _buttonTooltip;
		set
		{
			if (value == "")
			{
				Debug.LogError("Tooltip should not be empty");
			}
			else
			{
				_buttonTooltip = value;
			}
		}
	}
	private string _buttonTooltip;

	protected TMP_Text _cachedTextComponent;

	void Awake()
	{
		_cachedTextComponent = GetComponentInChildren<TMP_Text>();
	}

	// change the color of the button's text to the specified color
	public void ChangeTextColor(Color colorToChange) // POLYMORPHISM
	{
		_cachedTextComponent.color = colorToChange;
	}

	// change the color of the button's text to the specified color
	public void ChangeTextColor(float r, float g, float b, float a) // POLYMORPHISM
	{
		ChangeTextColor(new Color(r, g, b, a));
	}

	public void OnPointerEnter(PointerEventData eventData)

	{
		OnHoverStart();
	}

	public void OnPointerExit(PointerEventData eventData)

	{
		OnHoverEnd();
	}

	// called once when the mouse hovers over the button
	protected virtual void OnHoverStart()
	{
	}

	// called once when the mouse leaves the button
	protected virtual void OnHoverEnd()
	{
	}
}
