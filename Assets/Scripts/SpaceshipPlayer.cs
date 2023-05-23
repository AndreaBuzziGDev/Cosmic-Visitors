using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipPlayer : Spaceship
{
    //DATA

    //POSITION ETC
    public Vector3 InitialPosition = new Vector3(-10, 0, 0);
    [SerializeField] private float MoveSpeed = 5;
    Rigidbody2D rb2D;


    //INPUT - EVENT-DRIVEN IMPLEMENTATION
    private PlayerInput Input = null;
    private float MovementInputFactor = 0.0f;

    //BULLETS
    public float BulletCooldown = 0.0f;//UNUSED
    public GameObject BulletPrefab;//TODO: REFECTOR TO ENFORCE MAINCANNONBULLET
    public GameObject RocketPrefab;//TODO: IMPLEMENT




    //AUDIO
    //TODO: CUSTOM AUDIO FOR MOVEMENT?



    //METHODS

    //TECHNICAL
    void Awake()
    {
        Input = new PlayerInput();
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        transform.position = InitialPosition;
    }



    //INPUT - EVENT-DRIVEN IMPLEMENTATION
    //TODO: IMPLEMENT EVENT DRIVEN CODE LOGIC IN A DEDICATED INPUT HANDLER?
    private void OnEnable()
    {
        //ENABLE INPUT WHEN OBJECT ENABLED
        Input.Enable();

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
        //DISABLE INPUT WHEN OBJECT DISABLED
        Input.Disable();

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
        if (!GameStateController.Instance.IsPaused)
        {
            //TODO: IMPLEMENT CANNON COOLDOWN

            //TODO: IMPLEMENT
            //TODO: COMBINE BULLET GAMEOBJECT PREFAB DICTIONARY WITH SCRIPTABLE OBJECTS
            //TODO: BULLET PLACEMENT ON A FACTORY METHOD ON THE BULLET ITSELF
            GameObject.Instantiate(BulletPrefab, this.transform.position, Quaternion.identity, null);
        }
    }

    //SECONDARY CANNON
    private void OnSecondaryCannonPerformed(InputAction.CallbackContext value)
    {
        if (!GameStateController.Instance.IsPaused)
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
        if (!GameStateController.Instance.IsPaused)
        {
            Move(new Vector2(0, MovementInputFactor));
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
    public void Move(Vector2 direction)
    {
        rb2D.velocity = (direction) * MoveSpeed;
    }



    //RESET - USEFUL IN EDITOR
    public void Reset() => transform.position = InitialPosition;


    //OVERRIDES
    public override void HandleDamageReceived()
    {
        //TODO: MAKE SPACESHIP SPRITE FLICKER


        //TODO: GIVE INVINCIBILITY FOR A SMALL FRACTION OF TIME

        //UPDATE GUI HEALTH BAR
        UpdateHealthBar();

        //BASE BEHAVIOUR
        base.HandleDamageReceived();
    }

    public override void HandleZeroHP()
    {
        //UPDATE GUI HEALTH BAR
        UpdateHealthBar();

        //BASE BEHAVIOUR
        base.HandleZeroHP();

        //HANDLE LIVES
        GameController.Instance.LifeLoss();
    }





    //UTILITIES
    public void UpdateHealthBar()
    {
        UIController.Instance.HealthBar.UpdateHealthBar(this);
    }


    //TODO: STATES
    //IN ORDER TO IMPLEMENT SOME MECHANICS, USE INVINCIBILITY STATE AND OTHER THINGS LIKE THAT


}
