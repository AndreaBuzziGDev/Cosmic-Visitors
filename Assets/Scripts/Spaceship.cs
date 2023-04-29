using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//TODO: USE SINGLETON PATTERN? (MonoSingleton)
//TODO: NO SINGLETON, BUT DIRECT REFERENCE?
public class Spaceship : MonoBehaviour
{
    //DATA

    //TODO: USE SCRIPTABLEOBJECTS?
    public Vector3 InitialPosition = new Vector3(0, -3.8f, 0);
    public float MoveSpeed;

    //INPUT - EVENT-DRIVEN IMPLEMENTATION
    private PlayerInput Input = null;
    private float MovementInputFactor = 0.0f;

    //TODO: MAIN CANNON
    //TODO: SECONDARY CANNON (EQUIPABLE/DETATCHABLE) 



    //METHODS

    //TECHNICAL
    void Awake()
    {
        Input = new PlayerInput();
    }

    //EVENT-DRIVEN IMPLEMENTATION
    //TODO: IMPLEMENT EVENT DRIVEN CODE LOGIC ON ANOTHER CLASS? ONE USED BY THIS VERY CLASS?
    private void OnEnable()
    {
        Input.Enable();//ENABLE INPUT WHEN OBJECT DISABLED 

        //ACTION SUBSCRIPTIONS
        //MOVEMENT
        Input.Player.Movement.performed += OnMovementPerformed;
        Input.Player.Movement.canceled += OnMovementCanceled;

        //SHOOT
        Input.Player.ShootMainCannon.performed += OnMainCannonPerformed;
        Input.Player.ShootAdditionalCannon.performed += OnSecondaryCannonPerformed;

        //ESCAPE
        Input.Player.Escape.performed += OnEscapePerformed;
    }

    private void OnDisable()
    {
        Input.Disable();//DISABLE INPUT WHEN OBJECT DISABLED

        //MOVEMENT
        Input.Player.Movement.performed -= OnMovementPerformed;
        Input.Player.Movement.canceled -= OnMovementCanceled;

        //SHOOT
        Input.Player.ShootMainCannon.performed -= OnMainCannonPerformed;
        Input.Player.ShootAdditionalCannon.performed -= OnSecondaryCannonPerformed;

        //ESCAPE
        Input.Player.Escape.performed -= OnEscapePerformed;

    }

    //MOVEMENT
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        MovementInputFactor = value.ReadValue<float>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        MovementInputFactor = value.ReadValue<float>();
    }

    //SHOOT
    //MAIN CANNON
    private void OnMainCannonPerformed(InputAction.CallbackContext value)
    {
        if (!GameStateController.IsPaused)
        {
            //TODO: IMPLEMENT

        }
    }

    //SECONDARY CANNON
    private void OnSecondaryCannonPerformed(InputAction.CallbackContext value)
    {
        if (!GameStateController.IsPaused)
        {
            //TODO: IMPLEMENT

        }
    }



    //ESCAPE
    private void OnEscapePerformed(InputAction.CallbackContext value)
    {
        UIController.Instance.NavigateBack();
    }



    // Update is called once per frame
    void Update()
    {
        if (!GameStateController.IsPaused)
        {
            //TODO: IDENTIFY PLAYER SPACESHIP
            Move(new Vector2(MovementInputFactor, 0));
        }
        else
        {
            //TODO: THERE WILL BE ANOTHER CUSTOM INPUT FOR MENUS USED IN THE APPROPRIATE CLASSES

            //TODO: THIS IS MENU CONTROL MODE
            //STEP 1: FIND ACTIVE MENU (TOP LEVEL UIPanelSequentiable)
            //STEP 2: FIND IF IT IS A MENU THAT CONTAINS AN ADDRESSABLE UI COMPONENT
            //STEP 3: IF CURSOR HAS NOT BEEN MOVED YET, PLACE IT ON THE "HIGHEST" UI ELEMENT'S POSITION
            //STEP 4: BASED ON INPUT, CYCLE MOVEMENT
        }
    }
    
    



    //FUNCTIONALITIES
    public void Move(Vector2 direction) => transform.Translate((direction * Time.deltaTime) * MoveSpeed);

    public void Reset() => transform.position = InitialPosition;

    //TODO: POSSIBLE IMPLEMENTATION OF SHOOTING PRIMARY AND SECONDARY CANNON HERE, BASED ON FUTURE REFACTORS

}
