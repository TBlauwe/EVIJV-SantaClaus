using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInitiatorScript : MonoBehaviour {

    private float distanceToObj;	// Distance entre le personnage et l'objet saisi
	private Rigidbody attachedObject;	// Objet saisi, null si aucun objet saisi

	public const int RAYCASTLENGTH = 100;	// Longueur du rayon issu de la caméra
	public float ThrowPower = 100f;	// Longueur du rayon issu de la caméra

	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = new Vector2(16, 16);	// Offset du centre du curseur
	public Texture2D cursorOff, cursorDragged, cursorDraggable;	// Textures à appliquer aux curseurs

	void Start () 
	{
		distanceToObj = -1;
		Cursor.SetCursor (cursorOff, hotSpot, cursorMode);
	}
	
	void FixedUpdate () 
	{
        // Le raycast attache un objet cliqué
        RaycastHit hitInfo;
        Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay (ray.origin, ray.direction * RAYCASTLENGTH, Color.blue);
        bool rayCasted = Physics.Raycast (ray, out hitInfo, RAYCASTLENGTH);

        if (rayCasted) 
        {
            rayCasted = hitInfo.transform.CompareTag("Draggable");
        }
        // rayCasted est true si un objet possédant le tag draggable est détécté

        if (Input.GetMouseButtonDown (0))	// L'utilisateur vient de cliquer
        {
            if (rayCasted) 
            {
                attachedObject = hitInfo.rigidbody;
                attachedObject.isKinematic = true;
                distanceToObj = hitInfo.distance;
                Cursor.SetCursor (cursorDragged, hotSpot, cursorMode);
            }
        } 

        else if (Input.GetMouseButtonUp (0) && attachedObject != null) 	// L'utilisateur relache un objet saisi
        {
            attachedObject.isKinematic = false;
            attachedObject = null;
            if (rayCasted) 
            {
                Cursor.SetCursor (cursorDraggable, hotSpot, cursorMode);
            } 
            else 
            {
                Cursor.SetCursor (cursorOff, hotSpot, cursorMode);
            }
        } 

        if (Input.GetMouseButton (0) && attachedObject != null) // L'utilisateur continue la saisie d'un objet
        {
            attachedObject.MovePosition (ray.origin + (ray.direction * distanceToObj));
        } 

        if (Input.GetMouseButton (0) && Input.GetKeyDown(KeyCode.A) && attachedObject != null) 
        {
            if (rayCasted) 
            {
                Cursor.SetCursor (cursorDraggable, hotSpot, cursorMode);
            } 
            else 
            {
                Cursor.SetCursor (cursorOff, hotSpot, cursorMode);
            }
            attachedObject.AddForce(ray.direction * ThrowPower); //this vector should be the player's forward vector
            attachedObject.isKinematic = false;
            attachedObject = null;
        } 

        else  // L'utilisateur bouge la sourie sans cliquer 
        {
            if (rayCasted) 
            {
                Cursor.SetCursor (cursorDraggable, hotSpot, cursorMode);
            } 
            else 
            {
                Cursor.SetCursor (cursorOff, hotSpot, cursorMode);
            }
        }
	}

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorOff, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
