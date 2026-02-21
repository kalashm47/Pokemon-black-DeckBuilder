using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{

    public Transform parentToReturnTo  = null;
    public Transform placeholderParent = null;
    GameObject placeholder = null;
    public delegate void ClickCardEventHandler(GameObject card);
    public event ClickCardEventHandler OnCardClicked;
    
    public GameObject GetPlaceHolder()
    {
        return placeholder;
    } 
    public void OnPointerClick(PointerEventData eventData)
    {
        if(GlobalValues.CurrentScene == GlobalValues.Scene.Town)
        {
            OnCardClicked?.Invoke(this.gameObject);
        }   
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(GlobalValues.CurrentScene == GlobalValues.Scene.Battle)
        {
            placeholder = Instantiate(this.gameObject);
            placeholder.transform.SetParent(this.transform.parent);
            placeholder.GetComponent<CanvasGroup>().alpha = 0;
        }
    }
}
