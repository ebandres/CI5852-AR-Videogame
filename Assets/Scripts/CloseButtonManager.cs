using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonManager : MonoBehaviour
{
    public void CloseDisasterMenu() { gameObject.transform.parent.gameObject.SetActive(false); }

}
