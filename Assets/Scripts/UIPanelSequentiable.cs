using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelSequentiable
{
    //DATA
    protected UIPanelSequentiable previousSequentiable;
    protected GameObject currentPanel;


    //CONSTRUCTOR
    protected UIPanelSequentiable() { }

    public UIPanelSequentiable(GameObject currentPanel)
    {
        this.currentPanel = currentPanel;
    }


    //FUNCTIONALITIES
    public void TakeOver(UIPanelSequentiable previous)
    {
        Debug.Log("TakeOver " + currentPanel.name + ", previous: " + previous?.currentPanel.name);
        if (previous != null) previousSequentiable = previous;
        if (previousSequentiable != null) previousSequentiable.Overtaken(); 
        currentPanel.SetActive(true);

        TakeOverLogic();
    }


    public void Overtaken() => currentPanel.SetActive(false);

    public UIPanelSequentiable GoBack()
    {
        GoBackLogic();
        if (previousSequentiable != null) previousSequentiable.TakeOver(null);
        Overtaken();

        return previousSequentiable;
    }



    //UI BEHAVIOUR LOGIC
    protected virtual void TakeOverLogic(){}//DEFAULT: DO NOTHING
    protected virtual void GoBackLogic(){}//DEFAULT: DO NOTHING

}
