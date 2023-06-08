using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorRaycastAnalyzer : MonoBehaviour
{
    private const string UI_LAYER_NAME = "UI";
    
    public bool IsOverUI()
    {
        List<RaycastResult> listRaycastResult = DoReycast();
        
        foreach (RaycastResult result in listRaycastResult)
        {
            if (result.gameObject.layer == LayerMask.NameToLayer(UI_LAYER_NAME))
            {
                return true;
            }
        }

        return false;
    }

    private List<RaycastResult> DoReycast()
    {
        // create a data container and 
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        // create a list that will be populated
        List<RaycastResult> listRaycastResult = new List<RaycastResult>();

        EventSystem.current.RaycastAll(pointerEventData, listRaycastResult);

        return listRaycastResult;
    }
}
