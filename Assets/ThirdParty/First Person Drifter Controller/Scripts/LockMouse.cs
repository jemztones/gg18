// by @torahhorse

using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour
{	
	void Start()
	{
		LockCursor(CursorLockMode.Locked);
	}

	void Update()
	{
		// lock when mouse is clicked
		if( Input.GetMouseButtonDown(0) && Time.timeScale > 0.0f )
		{
			LockCursor(CursorLockMode.Locked);
		}
	
		// unlock when escape is hit
		if  ( Input.GetKeyDown(KeyCode.Escape) )
		{
            if (Cursor.lockState == CursorLockMode.None)
            {
                LockCursor(CursorLockMode.Locked);
            }
            else
            {
                LockCursor(CursorLockMode.None);
            }
		}
	}

    public void LockCursor(CursorLockMode cursorLockMode)
    {
        Cursor.lockState = cursorLockMode;
	}
}